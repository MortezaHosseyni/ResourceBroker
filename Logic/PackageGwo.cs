using ResourceBroker.Enums;
using ResourceBroker.Models;

namespace ResourceBroker.Logic
{
    public class PackageGwo
    {
        private const int PopulationSize = 50;
        private const int MaxIterations = 200;
        private const int RequiredResourceTypes = 5; // Cpu, Gpu, Ram, Ssd, Hdd

        public List<Package> CreatePackages(List<Resource> availableResources)
        {
            var packages = new List<Package>();

            // Filter only unallocated resources
            var unallocatedResources = availableResources
                .Where(r => r.PackageId == null)
                .ToList();

            // Group resources by type
            var resourcesByType = unallocatedResources
                .GroupBy(r => r.Type)
                .ToDictionary(g => g.Key, g => g.ToList());

            if (!ValidateResourceAvailability(resourcesByType))
                return packages;

            // Initialize and optimize wolves
            var wolves = InitializeWolfPopulation(resourcesByType);

            for (var iteration = 0; iteration < MaxIterations; iteration++)
            {
                var rankedWolves = RankWolves(wolves);
                var alpha = rankedWolves[0];
                var beta = rankedWolves[1];
                var delta = rankedWolves[2];
                UpdateWolfPositions(wolves, alpha, beta, delta, iteration);
            }

            // Select best packages, ensuring resources are not reused
            return SelectBestPackages(wolves, unallocatedResources);
        }

        private static List<Wolf> InitializeWolfPopulation(Dictionary<ResourceType, List<Resource>> resourcesByType)
        {
            var wolves = new List<Wolf>();
            var random = new Random();

            for (var i = 0; i < PopulationSize; i++)
            {
                var packageResources = new Dictionary<ResourceType, Resource>();

                foreach (var resourceType in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
                {
                    if (!resourcesByType.TryGetValue(resourceType, out var typeResources)) continue;
                    var unallocatedTypeResources = typeResources.Where(r => r.PackageId == null).ToList();
                    if (unallocatedTypeResources.Any())
                    {
                        packageResources[resourceType] = unallocatedTypeResources[random.Next(unallocatedTypeResources.Count)];
                    }
                }

                if (packageResources.Count == RequiredResourceTypes)
                {
                    wolves.Add(new Wolf
                    {
                        Resources = packageResources,
                        Fitness = 0
                    });
                }
            }

            return wolves;
        }

        private static List<Wolf> RankWolves(List<Wolf> wolves)
        {
            // Calculate fitness for each wolf (package)
            foreach (var wolf in wolves)
            {
                wolf.Fitness = CalculateFitness(wolf);
            }

            // Sort wolves by fitness in descending order
            return wolves
                .OrderByDescending(w => w.Fitness)
                .ToList();
        }

        private static void UpdateWolfPositions(
            List<Wolf> wolves,
            Wolf alpha,
            Wolf beta,
            Wolf delta,
            int iteration)
        {
            var a = 2 * (1 - iteration / (double)MaxIterations);

            foreach (var wolf in wolves)
            {
                // Skip the best wolves
                if (wolf == alpha || wolf == beta || wolf == delta)
                    continue;

                var random = new Random();

                // Compute A and C vectors
                var A = new double[3];
                var C = new double[3];
                for (var i = 0; i < 3; i++)
                {
                    A[i] = 2 * a * random.NextDouble() - a;
                    C[i] = 2 * random.NextDouble();
                }

                // Update wolf's resources based on top three wolves
                wolf.UpdateResourcePositions(A, C, alpha, beta, delta);
            }
        }

        private static double CalculateFitness(Wolf wolf)
        {
            // Positive Criteria
            var capacityScore = wolf.Resources.Values.Sum(r => r.Capacity) / 100.0;
            var uploadScore = wolf.Resources.Values.Sum(r => r.Service?.Upload) / 100.0;
            var downloadScore = wolf.Resources.Values.Sum(r => r.Service?.Download) / 100.0;
            var bandwidthScore = wolf.Resources.Values.Sum(r => r.Service?.Bandwidth) / 100.0;

            // Negative Criteria (to be minimized)
            var responseTimeScore = 1.0 / (1 + wolf.Resources.Values.Average(r => r.ResponseTime)); // Inverse for minimization
            var costScore = 1.0 / (1 + wolf.Resources.Values.Sum(r => r.Cost)); // Inverse for minimization

            // Diversity Score (positive)
            var diversityScore = wolf.Resources.Keys.Count == RequiredResourceTypes ? 1.0 : 0.0;

            // Availability Score (positive)
            var availabilityScore = wolf.Resources.Values
                .Count(r => !r.IsAllocated) / (double)RequiredResourceTypes;

            // Service Consistency Score (positive)
            var serviceConsistencyScore = wolf.Resources.Values
                .Select(r => r.Service?.Id)
                .Distinct()
                .Count() == 1 ? 1.0 : 0.5;

            // Weighted Sum of Scores
            var rawScore = (0.25 * diversityScore +
                            0.2 * availabilityScore +
                            0.15 * serviceConsistencyScore +
                            0.1 * capacityScore +
                            0.1 * uploadScore +
                            0.1 * downloadScore +
                            0.1 * bandwidthScore) -
                           (0.05 * responseTimeScore +
                            0.05 * costScore);

            return Math.Round((double)rawScore!, 2);
        }

        private static List<Package> SelectBestPackages(List<Wolf> wolves, List<Resource> unallocatedResources)
        {
            var selectedPackages = new List<Package>();

            foreach (var wolf in wolves.OrderByDescending(w => w.Fitness))
            {
                var startTime = DateTime.Now;

                var resourcesForPackage = wolf.Resources.Values
                    .Where(unallocatedResources.Contains) // Ensure resources are unallocated
                    .ToList();

                if (resourcesForPackage.Count != RequiredResourceTypes) continue;

                // Calculate Efficiency
                var totalCapacity = resourcesForPackage.Sum(r => r.Capacity);
                var utilizedUpload = resourcesForPackage.Sum(r => r.Service?.Upload ?? 0);
                var utilizedDownload = resourcesForPackage.Sum(r => r.Service?.Download ?? 0);
                var totalBandwidth = resourcesForPackage.Sum(r => r.Service?.Bandwidth ?? 0);
                var totalCost = resourcesForPackage.Sum(r => r.Cost);
                var avgResponseTime = resourcesForPackage.Average(r => r.ResponseTime);

                var efficiency = totalCapacity > 0
                    ? (utilizedUpload + utilizedDownload + totalBandwidth) / totalCapacity
                    : 0;

                // Calculate Complexity
                var uniqueResourceTypes = resourcesForPackage.Select(r => r.Type).Distinct().Count();
                var complexity = 0.5 * (uniqueResourceTypes / (double)RequiredResourceTypes) +
                                 0.3 * (1.0 / (1 + totalCost)) +
                                 0.2 * (1.0 / (1 + avgResponseTime));

                // Measure creation time
                var endTime = DateTime.Now;
                var creationTime = (endTime - startTime).TotalMilliseconds;

                selectedPackages.Add(new Package
                {
                    Id = Guid.NewGuid(),
                    Title = $"Package #{DateTime.Now:yyyyMMdd-HHmmss}",
                    Description = "Optimized multi-resource package (GWO)",
                    QosScore = wolf.Fitness,
                    IsQosCompliant = wolf.Fitness >= 0.75,
                    Resources = resourcesForPackage,
                    TakenTimeForCreation = creationTime,
                    Efficiency = Math.Round(efficiency, 2),
                    Complexity = Math.Round(complexity, 2),
                    Algorithm = PackageAlgorithmType.Gwo,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                // Mark resources as allocated
                foreach (var resource in resourcesForPackage)
                {
                    resource.PackageId = selectedPackages.Last().Id;
                    unallocatedResources.Remove(resource); // Remove from unallocated list
                }
            }

            return selectedPackages;
        }

        private static bool ValidateResourceAvailability(Dictionary<ResourceType, List<Resource>> resourcesByType)
        {
            return Enum.GetValues(typeof(ResourceType))
                .Cast<ResourceType>()
                .All(type =>
                    resourcesByType.ContainsKey(type) &&
                    resourcesByType[type].Count >= 1
                );
        }

        // Wolf class to represent package candidates
        private class Wolf
        {
            public Dictionary<ResourceType, Resource> Resources { get; init; }
            public double Fitness { get; set; }

            public void UpdateResourcePositions(
                double[] A,
                double[] C,
                Wolf alpha,
                Wolf beta,
                Wolf delta)
            {
                // Update resources based on top wolves
                foreach (var resourceType in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
                {
                    var candidates = new[]
                    {
                        alpha.Resources[resourceType],
                        beta.Resources[resourceType],
                        delta.Resources[resourceType]
                    };

                    // Simple selection strategy
                    var bestIndex = FindBestResourceIndex(candidates, A, C);
                    Resources[resourceType] = candidates[bestIndex];
                }
            }

            private static int FindBestResourceIndex(Resource[] candidates, double[] A, double[] C)
            {
                var scores = new double[candidates.Length];

                for (var i = 0; i < candidates.Length; i++)
                {
                    // Compute a score based on A, C vectors and resource characteristics
                    scores[i] = ComputeResourceScore(candidates[i], A[i], C[i]);
                }

                return Array.IndexOf(scores, scores.Max());
            }

            private static double ComputeResourceScore(Resource resource, double a, double c)
            {
                // Compute a score based on resource properties
                var serviceScore = resource.Service?.Id.GetHashCode() * c ?? 0;
                var availabilityScore = resource.IsAllocated ? 0.2 : 1.0;

                return serviceScore * availabilityScore * (1 - a);
            }
        }
    }
}
