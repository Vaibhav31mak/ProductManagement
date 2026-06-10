namespace ProductManagement.Application.Features.Products.Handlers;

public class CreateProductHandler(IProductRepository productRepository, IValidator<CreateProductCommand> validator, IMapper mapper) : IRequestHandler<CreateProductCommand, Result<ProductResponse>>
{
    /// <summary>
    /// Creating product by also validating it
    /// </summary>
    /// <param name="createProductCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    async Task<Result<ProductResponse>> IRequestHandler<CreateProductCommand, Result<ProductResponse>>.Handle(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
    {
        var validations = await validator.ValidateAsync(createProductCommand, cancellationToken);
        if (validations.IsValid)
        {
            var product = mapper.Map<Product>(createProductCommand);
            await productRepository.AddAsync(product);
            var prouctResponse = mapper.Map<ProductResponse>(product);
            return Result<ProductResponse>.Success(prouctResponse);
        }
        var errors = validations.Errors.Select(errors => errors.ErrorMessage);
        return Result<ProductResponse>.Failure(string.Join(", ", errors));
    }
}
