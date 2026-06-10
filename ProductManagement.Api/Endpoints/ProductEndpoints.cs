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
        var result = await mediator.Send(productCommand, cancellationToken);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }
        return Ok(result.Value);
    }
}
