using ResourceBroker.Enums;
using ResourceBroker.Models;

namespace ResourceBroker.Logic
{
    public class Automaton
    {
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

            // Initialize action probabilities for each resource type
            var probabilities = InitializeProbabilities(resourcesByType);

            for (var iteration = 0; iteration < MaxIterations; iteration++)
            {
                // Select a candidate package
                var candidateResources = SelectCandidatePackage(resourcesByType, probabilities);

                if (candidateResources.Count != RequiredResourceTypes) continue;

                // Calculate fitness for the candidate
                var fitness = CalculateFitness(candidateResources);

                // Update probabilities based on fitness
                UpdateProbabilities(probabilities, candidateResources, resourcesByType, fitness);

                // Add the candidate as a package if it improves QoS
                if (!(fitness >= 0.75)) continue;

                var package = CreatePackage(candidateResources, fitness);
                packages.Add(package);

                // Mark resources as allocated
                foreach (var resource in candidateResources.Values)
                    resource.PackageId = package.Id;
            }

            return packages;
        }

        private static Dictionary<ResourceType, List<double>> InitializeProbabilities(Dictionary<ResourceType, List<Resource>> resourcesByType)
        {
            var probabilities = new Dictionary<ResourceType, List<double>>();

            foreach (var type in resourcesByType.Keys)
            {
                probabilities[type] = Enumerable.Repeat(1.0 / resourcesByType[type].Count, resourcesByType[type].Count).ToList();
            }

            return probabilities;
        }

        private static Dictionary<ResourceType, Resource> SelectCandidatePackage(
            Dictionary<ResourceType, List<Resource>> resourcesByType,
            Dictionary<ResourceType, List<double>> probabilities)
        {
            var candidateResources = new Dictionary<ResourceType, Resource>();
            var random = new Random();

            foreach (var type in resourcesByType.Keys)
            {
                var resourceList = resourcesByType[type];
                var probList = probabilities[type];

                // Select a resource based on probabilities
                var selectedIndex = SelectByProbability(probList, random);
                candidateResources[type] = resourceList[selectedIndex];
            }

            return candidateResources;
        }

        private static int SelectByProbability(List<double> probabilities, Random random)
        {
            var cumulative = probabilities.Sum();
            var roll = random.NextDouble() * cumulative;
            var cumulativeSum = 0.0;

            for (var i = 0; i < probabilities.Count; i++)
            {
                cumulativeSum += probabilities[i];
                if (roll <= cumulativeSum)
                    return i;
            }

            return probabilities.Count - 1; // Fallback
        }

        private static void UpdateProbabilities(
            Dictionary<ResourceType, List<double>> probabilities,
            Dictionary<ResourceType, Resource> candidateResources,
            Dictionary<ResourceType, List<Resource>> resourcesByType,
            double fitness)
        {
            const double rewardFactor = 0.1;
            const double penaltyFactor = 0.1;

            foreach (var type in candidateResources.Keys)
            {
                var resource = candidateResources[type];

                // Find the index of the resource in the list for its type
                var resourceIndex = resourcesByType[type].IndexOf(resource);
                if (resourceIndex == -1) continue; // Skip if resource not found

                // Apply reward or penalty
                probabilities[type] = probabilities[type]
                    .Select((p, index) =>
                        index == resourceIndex
                            ? p + rewardFactor * fitness
                            : p - penaltyFactor * fitness)
                    .ToList();

                // Normalize probabilities
                var sum = probabilities[type].Sum();
                probabilities[type] = probabilities[type].Select(p => p / sum).ToList();
            }
        }

        private static double CalculateFitness(Dictionary<ResourceType, Resource> resources)
        {
            var capacityScore = resources.Values.Sum(r => r.Capacity) / 100.0;
            var uploadScore = resources.Values.Sum(r => r.Service?.Upload ?? 0) / 100.0;
            var downloadScore = resources.Values.Sum(r => r.Service?.Download ?? 0) / 100.0;
            var bandwidthScore = resources.Values.Sum(r => r.Service?.Bandwidth ?? 0) / 100.0;

            var responseTimeScore = 1.0 / (1 + resources.Values.Average(r => r.ResponseTime));
            var costScore = 1.0 / (1 + resources.Values.Sum(r => r.Cost));

            var diversityScore = resources.Keys.Count == RequiredResourceTypes ? 1.0 : 0.0;
            var availabilityScore = resources.Values.Count(r => !r.IsAllocated) / (double)RequiredResourceTypes;
            var serviceConsistencyScore = resources.Values.Select(r => r.Service?.Id).Distinct().Count() == 1 ? 1.0 : 0.5;

            var positiveCriteria = 0.25 * diversityScore +
                                   0.2 * availabilityScore +
                                   0.15 * serviceConsistencyScore +
                                   0.1 * capacityScore +
                                   0.1 * uploadScore +
                                   0.1 * downloadScore +
                                   0.1 * bandwidthScore;

            var negativeCriteria = 0.05 * responseTimeScore +
                                   0.05 * costScore;

            var rawScore = positiveCriteria - negativeCriteria;

            return Math.Round(rawScore!, 2);
        }

        private static Package CreatePackage(Dictionary<ResourceType, Resource> resources, double fitness)
        {
            var startTime = DateTime.Now;

            // Total metrics
            var totalCapacity = resources.Values.Sum(r => r.Capacity);
            var utilizedUpload = resources.Values.Sum(r => r.Service?.Upload ?? 0);
            var utilizedDownload = resources.Values.Sum(r => r.Service?.Download ?? 0);
            var totalBandwidth = resources.Values.Sum(r => r.Service?.Bandwidth ?? 0);
            var totalCost = resources.Values.Sum(r => r.Cost);
            var avgResponseTime = resources.Values.Average(r => r.ResponseTime);

            // Efficiency calculation
            var efficiency = totalCapacity > 0
                ? (utilizedUpload + utilizedDownload + totalBandwidth) / totalCapacity
                : 0;

            // Complexity calculation
            var uniqueResourceTypes = resources.Keys.Distinct().Count();
            var complexity = 0.5 * (uniqueResourceTypes / (double)RequiredResourceTypes) +
                             0.3 * (1.0 / (1 + totalCost)) +
                             0.2 * (1.0 / (1 + avgResponseTime));

            var endTime = DateTime.Now;
            var creationTime = (endTime - startTime).TotalMilliseconds;

            return new Package
            {
                Id = Guid.NewGuid(),
                Title = $"Package #{DateTime.Now:yyyyMMdd-HHmmss}",
                Description = "Optimized multi-resource package (Automaton)",
                QosScore = fitness,
                IsQosCompliant = fitness >= 0.75,
                Resources = resources.Values.ToList(),
                TakenTimeForCreation = creationTime,
                Efficiency = Math.Round(efficiency, 2),
                Complexity = Math.Round(complexity, 2),
                Algorithm = PackageAlgorithmType.Automaton,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private static bool ValidateResourceAvailability(Dictionary<ResourceType, List<Resource>> resourcesByType)
        {
            return Enum.GetValues(typeof(ResourceType))
                .Cast<ResourceType>()
                .All(type => resourcesByType.ContainsKey(type) && resourcesByType[type].Count >= 1);
        }
    }
}
