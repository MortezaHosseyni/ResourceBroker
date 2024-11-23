using Microsoft.EntityFrameworkCore;
using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IAllocateRepository : IGenericRepository<Allocate>
    {
        Task<List<Allocate>> GetAllAllocations();
    }

    public class AllocateRepository(ApplicationDbContext db)
        : GenericRepository<Allocate>(db), IAllocateRepository
    {
        public async Task<List<Allocate>> GetAllAllocations()
        {
            return await Context.Allocates.Include(a => a.User).Include(a => a.Resource).ThenInclude(a => a.Service)
                .ToListAsync();
        }
    }
}
