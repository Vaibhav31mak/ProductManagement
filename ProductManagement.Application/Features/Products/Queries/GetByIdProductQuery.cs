namespace ProductManagement.Application.Features.Products.Queries;

/// <summary>
/// Get a product by id query
/// </summary>
/// <param name="Id"></param>
public record GetByIdProductQuery(string Id) : IRequest<Result<ProductResponse>>;
