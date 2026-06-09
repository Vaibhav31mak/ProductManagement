namespace ProductManagement.Api.ApiExtensions;

/// <summary>
/// Middleware Pipleline extension method.
/// </summary>
public static class MiddlewarePipleline
{
    /// <summary>
    /// .NET 10 extension members to make code readable.
    /// </summary>
    /// <param name="app"></param>
    extension(WebApplication app)
    {
        /// <summary>
        /// Middleware Pipeline.
        /// </summary>
        public void AddMiddlewarePipeline()
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
