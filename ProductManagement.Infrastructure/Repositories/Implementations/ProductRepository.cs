namespace ProductManagement.Infrastructure.Repositories.Implementations;

/// <summary>
/// Product Repository for Product Data Access.
/// </summary>
public class ProductRepository(IMongoDatabase db) : GenericReposiroty<Product>(db)
{
}
