using Microsoft.Extensions.DependencyInjection;
using ResourceBroker.Repositories;

namespace ResourceBroker
{
    internal static class Program
    {
        private static ServiceProvider serviceProvider;

        [STAThread]
        private static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            serviceProvider = serviceCollection.BuildServiceProvider();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var scope = serviceProvider.CreateScope();
            var mainForm = scope.ServiceProvider.GetRequiredService<FormMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IAllocateRepository, AllocateRepository>();

            services.AddTransient<FormMain>();
        }
    }
}