using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }

    public class UserRepository(ApplicationDbContext db)
        : GenericRepository<User>(db), IUserRepository
    {
    }
}
