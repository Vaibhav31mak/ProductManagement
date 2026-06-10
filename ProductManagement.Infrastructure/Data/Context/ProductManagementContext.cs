namespace ProductManagement.Infrastructure.Data.Context;

/// <summary>
/// MongoDB database context for using MongoDB context using MongoDB Driver.
/// </summary>
public class ProductManagementContext
{
    private readonly IMongoDatabase? _database;

    public ProductManagementContext(IConfiguration configuration)
    {
        var productManagementDbSettings = configuration.GetSection("ProductManagementDatabase")
                                            .Get<ProductManagementSettings>()!;
        var client = new MongoClient(productManagementDbSettings.ConnectionString);
        _database = client.GetDatabase(productManagementDbSettings.DatabaseName);
    }

    public IMongoDatabase Datrabase => _database!;
}
