using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
    }

    public class RequestRepository(ApplicationDbContext db)
        : GenericRepository<Request>(db), IRequestRepository
    {
    }
}
