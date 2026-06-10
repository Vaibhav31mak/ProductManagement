namespace ProductManagement.Application.Features.Products.Command;

/// <summary>
/// update product command
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
/// <param name="Quantity"></param>
/// <param name="Category"></param>
public record UpdateProductCommand(
    string Id, string Name, string? Description, decimal Price, int Quantity, string? Category) : IRequest<Result<ProductResponse>>;