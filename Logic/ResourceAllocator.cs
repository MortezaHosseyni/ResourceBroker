using ResourceBroker.Enums;
using ResourceBroker.Models;
using ResourceBroker.Repositories;
using ResourceBroker.Utilities;

namespace ResourceBroker.Logic
{
    public class ResourceAllocator(
        Gwo optimizer,
        IResourceRepository resourceRepository,
        IRequestRepository requestRepository)
    {
        public async Task<AllocationResult> AllocateResourceAsync(Request request)
        {
            try
            {
                // Validate request
                if (!ValidateRequest(request))
                {
                    request.Status = RequestStatus.Rejected;
                    requestRepository.Update(request);

                    return CreateFailedAllocation(
                        AllocationFailureReason.InvalidRequest,
                        "Request validation failed"
                    );
                }

                // Check direct resource availability
                var directAllocation = await TryDirectAllocationAsync(request);
                if (directAllocation.IsSuccessful)
                {
                    return directAllocation;
                }

                // Find alternative resources using GWO
                return await FindAlternativeResourceAsync(request);
            }
            catch (Exception ex)
            {
                request.Status = RequestStatus.Rejected;
                requestRepository.Update(request);

                await Logger.Log($"Resource allocation failed: {ex.Message}");
                return CreateFailedAllocation(
                    AllocationFailureReason.SystemError,
                    ex.Message
                );
            }
        }

        private static bool ValidateRequest(Request request)
        {
            return request is { User: not null, Resource.IsAllocated: false };
        }

        private async Task<AllocationResult> TryDirectAllocationAsync(Request request)
        {
            var availableResource = await resourceRepository.GetAvailableResourceAsync(
                request.Resource.Service.Id,
                request.Resource.Id
            );

            if (availableResource == null) return AllocationResult.Failed();
            var allocation = CreateAllocation(request, availableResource);
            await resourceRepository.SaveAllocationAsync(allocation);

            request.Status = RequestStatus.Allocated;
            requestRepository.Update(request);

            return new AllocationResult
            {
                IsSuccessful = true,
                AllocatedResource = availableResource,
                Allocation = allocation
            };

        }

        private async Task<AllocationResult> FindAlternativeResourceAsync(Request request)
        {
            // Fetch available resources in the same service
            var availableResources = await resourceRepository.GetAvailableResourcesAsync(
                request.Resource.Service.Id
            );

            if (!availableResources.Any())
            {
                return CreateFailedAllocation(
                    AllocationFailureReason.NoResourcesAvailable,
                    "No alternative resources found"
                );
            }

            // Use Gray Wolf Optimization to find best alternatives
            var alternatives = optimizer.OptimizeResourceAllocation(request, availableResources);

            if (!alternatives.Any())
            {
                return CreateFailedAllocation(
                    AllocationFailureReason.NoSuitableAlternative,
                    "No suitable alternative resources found"
                );
            }

            // Select the best alternative resource
            var selectedResource = alternatives.First();
            var allocation = CreateAllocation(request, selectedResource);

            await resourceRepository.SaveAllocationAsync(allocation);

            request.Status = RequestStatus.SuggestedAnother;
            requestRepository.Update(request);

            return new AllocationResult
            {
                IsSuccessful = true,
                AllocatedResource = selectedResource,
                Allocation = allocation,
                IsAlternative = true
            };
        }

        private static Allocate CreateAllocation(Request request, Resource resource)
        {
            return new Allocate
            {
                Id = Guid.NewGuid(),
                UserId = request.User!.Id,
                ResourceId = resource.Id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private static AllocationResult CreateFailedAllocation(
            AllocationFailureReason reason,
            string message)
        {
            _ = Logger.Log($"Allocation failed: {reason} - {message}");

            return new AllocationResult
            {
                IsSuccessful = false,
                FailureReason = reason,
                FailureMessage = message
            };
        }
    }

    // Supporting classes for allocation result
    public class AllocationResult
    {
        public bool IsSuccessful { get; set; }
        public Resource AllocatedResource { get; set; }
        public Allocate Allocation { get; set; }
        public bool IsAlternative { get; set; }
        public AllocationFailureReason FailureReason { get; set; }
        public string FailureMessage { get; set; }

        public static AllocationResult Failed() =>
            new AllocationResult { IsSuccessful = false };
    }

    public enum AllocationFailureReason
    {
        InvalidRequest,
        NoResourcesAvailable,
        NoSuitableAlternative,
        SystemError
    }
}
