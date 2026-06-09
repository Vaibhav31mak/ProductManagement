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
            var productManagementDbSettings = configuration.GetSection("ProductManagementDatabase")
                .Get<ProductManagementSettings>()!;
            var client = new MongoClient(productManagementDbSettings.ConnectionString);
            var database = client.GetDatabase(productManagementDbSettings.DatabaseName);

            services.AddSingleton<IMongoDatabase>(database);
        }
    }
}
