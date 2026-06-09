namespace ProductManagement.Api.Exceptions;

/// <summary>
/// A Global Exception Handler for InterServer Error 500. Other logical errors would be handled with Result Pattern.
/// </summary>
/// <param name="logger"></param>
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
        Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An inter servcer error occured. Please checkout.",
            Type = StatusCodes.Status500InternalServerError.ToString(),
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };

        logger.LogError("Internal error happened");

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
