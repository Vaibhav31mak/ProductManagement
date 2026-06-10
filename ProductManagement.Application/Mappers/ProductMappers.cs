namespace ProductManagement.Application.Mappers;

/// <summary>
/// Mappers
/// </summary>
public class ProductMappers : Profile
{
    public ProductMappers()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, ProductResponse>();
        CreateMap<UpdateProductCommand, Product>();
    }
}
