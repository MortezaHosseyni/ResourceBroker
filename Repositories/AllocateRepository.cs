using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IAllocateRepository : IGenericRepository<Allocate>
    {
    }

    public class AllocateRepository(ApplicationDbContext db)
        : GenericRepository<Allocate>(db), IAllocateRepository
    {
    }
}
