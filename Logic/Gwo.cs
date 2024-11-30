using ResourceBroker.Models;

namespace ResourceBroker.Logic
{
    public class Gwo
    {
        private const int PopulationSize = 50;
        private const int MaxIterations = 100;

        public List<Resource> OptimizeResourceAllocation(Request request, List<Resource> availableResources)
        {
            var wolves = InitializeWolfPopulation(availableResources);

            for (var iteration = 0; iteration < MaxIterations; iteration++)
            {
                var rankedWolves = RankWolves(wolves, request);

                var alpha = rankedWolves[0];
                var beta = rankedWolves[1];
                var delta = rankedWolves[2];

                UpdateWolfPositions(wolves, alpha, beta, delta, iteration);
            }

            return wolves
                .OrderBy(w => CalculateFitness(w, request))
                .Take(3)
                .Select(w => w.Resource)
                .ToList();
        }

        private static List<Wolf> InitializeWolfPopulation(List<Resource> resources)
        {
            var random = new Random();
            var wolves = new List<Wolf>();

            for (var i = 0; i < PopulationSize; i++)
            {
                wolves.Add(new Wolf
                {
                    Resource = resources[random.Next(resources.Count)],
                    Fitness = 0 // Initial fitness
                });
            }

            return wolves;
        }

        private static List<Wolf> RankWolves(List<Wolf> wolves, Request request)
        {
            // Calculate fitness for each wolf
            foreach (var wolf in wolves)
            {
                wolf.Fitness = CalculateFitness(wolf, request);
            }

            // Sort wolves by fitness in descending order
            var rankedWolves = wolves
                .OrderByDescending(w => w.Fitness)
                .ToList();

            // Ensure we have at least 3 wolves
            if (rankedWolves.Count < 3)
            {
                throw new InvalidOperationException("Not enough wolves to rank. Population too small.");
            }

            // Return top 3 wolves (alpha, beta, delta)
            return
            [
                rankedWolves[0], // Alpha wolf (best solution)
                rankedWolves[1], // Beta wolf (second-best solution)
                rankedWolves[2]
            ];
        }

        private static void UpdateWolfPositions(List<Wolf> wolves, Wolf alpha, Wolf beta, Wolf delta, int iteration)
        {
            var a = 2 * (1 - iteration / (double)MaxIterations);

            foreach (var wolf in wolves)
            {
                // Skip the best wolves (alpha, beta, delta)
                if (wolf == alpha || wolf == beta || wolf == delta)
                    continue;

                // Compute new position using alpha, beta, delta
                var random = new Random();

                // Compute A vector
                var A = new double[3];
                for (var i = 0; i < 3; i++)
                {
                    A[i] = 2 * a * random.NextDouble() - a;
                }

                // Compute C vector
                var C = new double[3];
                for (var i = 0; i < 3; i++)
                {
                    C[i] = 2 * random.NextDouble();
                }

                // Compute D vector for alpha, beta, delta
                var DAlpha = ComputeDistance(wolf, alpha);
                var DBeta = ComputeDistance(wolf, beta);
                var DDelta = ComputeDistance(wolf, delta);

                // Update wolf's resource based on top three wolves
                wolf.UpdateResourcePosition(A, C, alpha.Resource, beta.Resource, delta.Resource);
            }
        }

        private static double CalculateFitness(Wolf wolf, Request request)
        {
            // Fitness evaluation considers multiple factors
            var serviceSimilarity = wolf.Resource.ServiceId == request.Resource.ServiceId
                ? 1.0 : 0.5;

            var availabilityFactor = wolf.Resource.IsAllocated ? 0.2 : 1.0;

            // Resource type compatibility
            var typeSimilarity = AreSimilarResourceTypes(wolf.Resource, request.Resource)
                ? 0.8 : 0.3;

            // Compute overall fitness
            var fitness = (serviceSimilarity * 0.4) +
                             (availabilityFactor * 0.3) +
                             (typeSimilarity * 0.3);

            return fitness;
        }

        // Helper method to check resource type similarity
        private static bool AreSimilarResourceTypes(Resource r1, Resource r2)
        {
            return r1.Type == r2.Type;
        }

        // Internal method to compute distance between wolves
        private static double[] ComputeDistance(Wolf currentWolf, Wolf targetWolf)
        {
            return new double[]
            {
                Math.Abs(currentWolf.Resource.Id.GetHashCode() - targetWolf.Resource.Id.GetHashCode()),
                Math.Abs(currentWolf.Resource.Service.Id.GetHashCode() - targetWolf.Resource.Service.Id.GetHashCode()),
                currentWolf.Resource.IsAllocated != targetWolf.Resource.IsAllocated ? 1 : 0
            };
        }

        // Wolf class extension
        private class Wolf
        {
            public Resource Resource { get; set; }
            public double Fitness { get; set; }

            public void UpdateResourcePosition(
                double[] A,
                double[] C,
                Resource alphaResource,
                Resource betaResource,
                Resource deltaResource)
            {
                // Compute new resource position based on alpha, beta, delta resources
                var candidates = new[] { alphaResource, betaResource, deltaResource };

                // Simple selection strategy
                var bestIndex = FindBestResourceIndex(candidates, A, C);

                // Update current resource
                Resource = candidates[bestIndex];
            }

            private static int FindBestResourceIndex(Resource[] candidates, double[] A, double[] C)
            {
                // Compute scores for each candidate
                var scores = new double[candidates.Length];

                for (var i = 0; i < candidates.Length; i++)
                {
                    // Compute a score based on A, C vectors and resource characteristics
                    scores[i] = ComputeResourceScore(candidates[i], A[i], C[i]);
                }

                // Return index of best resource
                return Array.IndexOf(scores, scores.Max());
            }

            private static double ComputeResourceScore(Resource resource, double a, double c)
            {
                // Compute a score based on resource properties
                var serviceScore = resource.Service.Id.GetHashCode() * c;
                var availabilityScore = resource.IsAllocated ? 0.2 : 1.0;

                return serviceScore * availabilityScore * (1 - a);
            }
        }
    }
}
