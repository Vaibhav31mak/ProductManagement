namespace ProductManagement.Application.Features.Products.Command;

/// <summary>
/// CreateProduct command which is a record for immutability. Returns Id.
/// </summary>
public record CreateProductCommand(
    string Name, string? Description, decimal Price, int Quantity, string? Category)
    : IRequest<Result<ProductResponse>>;