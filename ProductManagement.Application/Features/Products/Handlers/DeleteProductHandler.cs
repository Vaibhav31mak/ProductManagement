namespace ProductManagement.Application.Features.Products.Handlers;

/// <summary>
/// Delete product handler
/// </summary>
/// <param name="productRepository"></param>
/// <param name="mapper"></param>
public class DeleteProductHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);
        if(product is null)
        {
            return false;
        }
        await productRepository.DeleteAsync(product);
        return true;
    }
}
