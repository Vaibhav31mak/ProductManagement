namespace ProductManagement.Application.Features.Products.Handlers;

/// <summary>
/// Update product handler
/// </summary>
public class UpdateProductHandler(IValidator<UpdateProductCommand> validator, IProductRepository productRepository, IMapper mapper) : IRequestHandler<UpdateProductCommand, Result<ProductResponse>>
{
    public async Task<Result<ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validations = await validator.ValidateAsync(request);
        if (!validations.IsValid)
        {
            var errors = validations.Errors.Select(validation => validation.ErrorMessage);
            return Result<ProductResponse>.Failure(string.Join(", ", errors));
        }
        var product = mapper.Map<Product>(request);
        var productFound = await productRepository.GetByIdAsync(product.Id);
        if(productFound is null)
        {
            return Result<ProductResponse>.Failure("no product exists for the id");
        }
        await productRepository.UpdateAsync(product);
        var productResponse = mapper.Map<ProductResponse>(product);
        return Result<ProductResponse>.Success(productResponse);
    }
}
