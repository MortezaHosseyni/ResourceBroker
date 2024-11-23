using Microsoft.EntityFrameworkCore;
using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<List<Request>> GetAllRequests();
    }

    public class RequestRepository(ApplicationDbContext db)
        : GenericRepository<Request>(db), IRequestRepository
    {

        public async Task<List<Request>> GetAllRequests()
        {
            return await Context.Requests.Include(r => r.User).Include(r => r.Resource).ThenInclude(r => r.Service)
                .ToListAsync();
        }
    }
}
