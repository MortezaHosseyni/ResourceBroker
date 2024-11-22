using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IResourceRepository : IGenericRepository<Resource>
    {
        Task<Resource> GetAvailableResourceAsync(Guid serviceId, Guid resourceId);
        Task<List<Resource>> GetAvailableResourcesAsync(Guid serviceId);
        Task SaveAllocationAsync(Allocate allocation);
    }

    public class ResourceRepository(
        ApplicationDbContext context,
        ILogger<ResourceRepository> logger) : GenericRepository<Resource>(context), IResourceRepository
    {
        public async Task<Resource> GetAvailableResourceAsync(Guid serviceId, Guid resourceId)
        {
            try
            {
                return await Context.Resources
                    .Include(r => r.Service)
                    .FirstOrDefaultAsync(r =>
                        r.Id == resourceId &&
                        r.Service.Id == serviceId &&
                        !r.IsAllocated);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving available resource");
                throw;
            }
        }

        public async Task<List<Resource>> GetAvailableResourcesAsync(Guid serviceId)
        {
            try
            {
                return await Context.Resources
                    .Include(r => r.Service)
                    .Where(r =>
                        r.Service.Id == serviceId &&
                        !r.IsAllocated)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving available resources");
                throw;
            }
        }

        public async Task SaveAllocationAsync(Allocate allocation)
        {
            try
            {
                var resource = await Context.Resources
                    .FirstOrDefaultAsync(r => r.Id == allocation.Resource.Id);

                if (resource != null)
                {
                    resource.IsAllocated = true;
                }

                Context.Allocates.Add(allocation);

                await Context.SaveChangesAsync();

                logger.LogInformation(
                    $"Resource {allocation.Resource.Id} " +
                    $"allocated to User {allocation.User.Id}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error saving allocation");
                throw;
            }
        }

        public async Task<List<Resource>> SearchResourcesAsync(
            ResourceSearchCriteria criteria)
        {
            try
            {
                var query = Context.Resources
                    .Include(r => r.Service)
                    .AsQueryable();

                if (criteria.ServiceId.HasValue)
                {
                    query = query.Where(r => r.Service.Id == criteria.ServiceId.Value);
                }

                if (criteria.IsAvailable.HasValue)
                {
                    query = query.Where(r => r.IsAllocated != criteria.IsAvailable.Value);
                }

                if (!string.IsNullOrEmpty(criteria.ResourceName))
                {
                    query = query.Where(r =>
                        r.Name.Contains(criteria.ResourceName,
                        StringComparison.OrdinalIgnoreCase));
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error searching resources");
                throw;
            }
        }

        public class ResourceSearchCriteria
        {
            public Guid? ServiceId { get; set; }
            public bool? IsAvailable { get; set; }
            public string ResourceName { get; set; }
        }
    }
}
