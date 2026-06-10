namespace ProductManagement.Application.Features.Products.Validators;

/// <summary>
/// Fluent Validations for Creating product
/// </summary>
public class CreateProductValidators : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidators()
    {
        RuleFor(product => product.Name).NotEmpty();
        RuleFor(product => product.Price).GreaterThan(0m);
        RuleFor(product => product.Quantity).GreaterThanOrEqualTo(0);
    }
}
