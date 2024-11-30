using Microsoft.EntityFrameworkCore;
using ResourceBroker.Context;
using ResourceBroker.Models;

namespace ResourceBroker.Repositories
{
    public interface IPackageRepository : IGenericRepository<Package>
    {
        Task<List<Package>> GetAllPackages();
    }

    public class PackageRepository(ApplicationDbContext db)
        : GenericRepository<Package>(db), IPackageRepository
    {
        public async Task<List<Package>> GetAllPackages()
        {
            return await Context.Packages.OrderByDescending(r => r.CreatedAt).Include(r => r.Resources).ThenInclude(r => r.Service)
                .ToListAsync();
        }
    }
}
