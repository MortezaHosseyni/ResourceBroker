using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
    }

    public class ServiceRepository(ApplicationDbContext db)
        : GenericRepository<Service>(db), IServiceRepository
    {
    }
}
