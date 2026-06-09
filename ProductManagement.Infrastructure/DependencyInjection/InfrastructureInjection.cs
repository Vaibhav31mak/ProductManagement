namespace ProductManagement.Infrastructure.DependencyInjection;

public static class InfrastructureInjection
{
    extension(IServiceCollection services)
    {
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
