namespace ProductManagement.Application.Features.Products.Handlers;

public class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, Result<ProductResponse>>
{
    Task<Result<ProductResponse>> IRequestHandler<CreateProductCommand, Result<ProductResponse>>.Handle(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
    {
        if(createProductCommand.)
    }
}
