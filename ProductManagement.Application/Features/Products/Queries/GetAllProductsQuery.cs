namespace ProductManagement.Application.Features.Products.Queries;

/// <summary>
/// Get all Products query
/// </summary>
public class GetAllProductsQuery() : IRequest<Result<IReadOnlyList<ProductResponse>>>;
