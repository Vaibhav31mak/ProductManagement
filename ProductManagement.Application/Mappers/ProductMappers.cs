namespace ProductManagement.Application.Mappers;

public class ProductMappers : Profile
{
    public ProductMappers()
    {
        CreateMap<CreateProductCommand, Product>();
    }
}
