namespace ProductManagement.Application.Features.Products.Handlers;

public class GetAllProductsHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, Result<IReadOnlyList<ProductResponse>>>
{
    public async Task<Result<IReadOnlyList<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync();
        var productResponse = mapper.Map<IReadOnlyList<ProductResponse>>(products);
        return Result<IReadOnlyList<ProductResponse>>.Success(productResponse);
    }
}
