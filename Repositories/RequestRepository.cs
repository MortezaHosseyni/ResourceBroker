using Microsoft.EntityFrameworkCore;
using ResourceBroker.Context;
using ResourceBroker.Enums;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<List<Request>> GetAllRequests();
        Task<List<Request>> GetAllPendingRequests();
    }

    public class RequestRepository(ApplicationDbContext db)
        : GenericRepository<Request>(db), IRequestRepository
    {

        public async Task<List<Request>> GetAllRequests()
        {
            return await Context.Requests.OrderByDescending(r => r.CreatedAt).Include(r => r.User).Include(r => r.Resource).ThenInclude(r => r.Service)
                .ToListAsync();
        }

        public async Task<List<Request>> GetAllPendingRequests()
        {
            return await Context.Requests.Where(r => r.Status == RequestStatus.Pending).OrderByDescending(r => r.CreatedAt).Include(r => r.User).Include(r => r.Resource).ThenInclude(r => r.Service)
                .ToListAsync();
        }
    }
}
