namespace ProductManagement.Api.Endpoints;

public class ProductEndpoints(IMediator mediator) : BaseEndpoint
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand productCommand, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(productCommand, cancellationToken);
        return Ok(result.Value);
    }
}
