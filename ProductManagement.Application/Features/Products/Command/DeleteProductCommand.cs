namespace ProductManagement.Application.Features.Products.Command;

/// <summary>
/// Delete Command
/// </summary>
/// <param name="Id"></param>
public record DeleteProductCommand(string Id) : IRequest<bool>;