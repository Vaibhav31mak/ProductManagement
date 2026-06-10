using ProductManagement.Application.Features.Products.Queries;

namespace ProductManagement.Api.Endpoints;

public class ProductEndpoints(IMediator mediator) : BaseEndpoint
{
    /// <summary>
    /// Create a product POST request
    /// </summary>
    /// <param name="productCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand productCommand, CancellationToken cancellationToken = default)
    {
        var createProductResult = await mediator.Send(productCommand, cancellationToken);
        if (!createProductResult.IsSuccess)
        {
            return BadRequest(createProductResult.ErrorMessage);
        }
        return Ok(createProductResult.Value);
    }

    /// <summary>
    /// Get all products response
    /// </summary>
    /// <param name="getAllProductsQuery"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(GetAllProductsQuery getAllProductsQuery, CancellationToken cancellationToken)
    {
        var getAllProductsResult = await mediator.Send(getAllProductsQuery, cancellationToken);
        if (!getAllProductsResult.IsSuccess)
        {
            return BadRequest(getAllProductsResult.ErrorMessage);
        }
        return Ok(getAllProductsResult.Value);
    }

    
}
