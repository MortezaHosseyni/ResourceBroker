using Microsoft.EntityFrameworkCore;
using ResourceBroker.Models;

namespace ResourceBroker.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Allocate> Allocates { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databasePath = Path.Combine(Directory.GetCurrentDirectory(), "ResourceBroker.db");
            optionsBuilder.UseSqlite($"Data Source={databasePath};");

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
