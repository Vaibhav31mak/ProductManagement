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
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var getAllProductsResult = await mediator.Send(new GetAllProductsQuery(), cancellationToken);
        if (!getAllProductsResult.IsSuccess)
        {
            return BadRequest(getAllProductsResult.ErrorMessage);
        }
        return Ok(getAllProductsResult.Value);
    }

    /// <summary>
    /// Get by Id product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var productResponseResult = await mediator.Send(new GetByIdProductQuery(id), cancellationToken);
        if (!productResponseResult.IsSuccess)
        {
            return NotFound(productResponseResult.ErrorMessage);
        }
        return Ok(productResponseResult.Value);
    }


}
