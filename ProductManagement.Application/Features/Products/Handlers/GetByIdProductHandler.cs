namespace ProductManagement.Application.Features.Products.Handlers;

public class GetByIdProductHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetByIdProductQuery, Result<ProductResponse>>
{
    /// <summary>
    /// Get By id handler
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<ProductResponse>> Handle(GetByIdProductQuery query, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(query.Id);
        if(product is null)
        {
            return Result<ProductResponse>.Failure("no product exist with specified id");
        }
        var productResponse = mapper.Map<ProductResponse>(product);
        return Result<ProductResponse>.Success(productResponse);
    }
}
