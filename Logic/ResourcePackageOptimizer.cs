using ResourceBroker.Enums;
using ResourceBroker.Models;

namespace ResourceBroker.Logic
{
    public class ResourcePackageOptimizer(Gwo gwoOptimizer)
    {
        private const double QOS_THRESHOLD = 0.75; // 75% QoS satisfaction

        public ResourcePackage CreateOptimalResourcePackage(
            Request request,
            List<Resource> availableResources)
        {
            // Group resources by type
            var resourceGroups = availableResources
                .GroupBy(r => r.Type)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Validate resource type availability
            var requiredTypes = new[] {
            ResourceType.Cpu,
            ResourceType.Gpu,
            ResourceType.Ram,
            ResourceType.Ssd,
            ResourceType.Hdd
        };

            foreach (var type in requiredTypes)
            {
                if (!resourceGroups.ContainsKey(type) || !resourceGroups[type].Any())
                {
                    throw new InvalidOperationException(
                        $"No resources available for type: {type}"
                    );
                }
            }

            // Optimize resource selection for each type
            var packageResources = new Dictionary<ResourceType, Resource>();

            foreach (var type in requiredTypes)
            {
                // Create a mock request for each resource type
                var typeRequest = new Request
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId,
                    ResourceId = request.ResourceId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Use GWO to select the best resource of each type
                var optimizedResources = gwoOptimizer.OptimizeResourceAllocation(
                    typeRequest,
                    resourceGroups[type]
                );

                // Select the top resource
                packageResources[type] = optimizedResources.First();
            }

            // Calculate QoS for the package
            var qosScore = CalculatePackageQoS(packageResources, request);

            // Create and return the resource package
            return new ResourcePackage
            {
                Resources = packageResources,
                QosScore = qosScore,
                IsQosCompliant = qosScore >= QOS_THRESHOLD,
                Request = request
            };
        }

        private static double CalculatePackageQoS(
            Dictionary<ResourceType, Resource> packageResources,
            Request request)
        {
            // QoS calculation considers multiple factors
            var qosComponents = packageResources.Values.Select(resource => resource.Service.Id == request.Resource.Service.Id
                    ? 1.0
                    : 0.5)
                .ToList();

            // Check resource compatibility with service

            // Check resource availability
            var availabilityScore = packageResources.Values
                .All(r => !r.IsAllocated) ? 1.0 : 0.5;
            qosComponents.Add(availabilityScore);

            // Compute overall QoS score
            return qosComponents.Average();
        }
    }

    // Supporting classes
    public class ResourcePackage
    {
        public Dictionary<ResourceType, Resource> Resources { get; set; }
        public double QosScore { get; set; }
        public bool IsQosCompliant { get; set; }
        public Request Request { get; set; }
    }
}
