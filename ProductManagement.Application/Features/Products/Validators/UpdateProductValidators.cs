namespace ProductManagement.Application.Features.Products.Validators;

/// <summary>
/// Update product validations
/// </summary>
public class UpdateProductValidators : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidators()
    {
        RuleFor(product => product.Name).NotEmpty();
        RuleFor(product => product.Price).GreaterThan(0m);
        RuleFor(product => product.Quantity).GreaterThanOrEqualTo(0);
    }
}
