namespace ProductManagement.Infrastructure.DependencyInjection;

public static class InfrastructureInjection
{
    // Extension member
    extension(IServiceCollection services)
    {
        /// <summary>
        /// Configuring database with MongoDB Driver.
        /// </summary>
        /// <param name="configuration"></param>
        public void ConfigureDatabase(IConfiguration configuration)
        {
            services.AddSingleton<ProductManagementContext>();
        }

        /// <summary>
        /// DI for Repositories
        /// </summary>
        public void AddInfrastructureServices()
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
