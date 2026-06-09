namespace ProductManagement.Api.Endpoints.Contracts;

/// <summary>
/// This is the base endpoint to extend ControllerBase and specify ApiController Data Annotation.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public abstract class BaseEndpoint : ControllerBase
{
}
