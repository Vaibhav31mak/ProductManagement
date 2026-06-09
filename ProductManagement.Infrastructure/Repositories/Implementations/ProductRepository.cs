namespace ProductManagement.Infrastructure.Repositories.Implementations;

/// <summary>
/// Product Repository for Product Data Access. Using C# 12 Primary Constructor.
/// </summary>
public class ProductRepository(ProductManagementContext context) 
    : GenericReposiroty<Product>(context), IProductRepository
{
}
