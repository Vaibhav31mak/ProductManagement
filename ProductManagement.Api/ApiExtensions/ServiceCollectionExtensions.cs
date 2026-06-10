namespace ProductManagement.Api.ApiExtensions;

/// <summary>
/// A class for extension methods of service collections to configure APIs.
/// This class is added to make program.cs clean.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Using .NET 10 extension members for readability.
    /// </summary>
    /// <param name="services"></param>
    extension(IServiceCollection services)
    {
        /// <summary>
        /// Adding Controllers and EndpointsApiExplorer for swagger documentation.
        /// </summary>
        public void BuildApiWithSwagger()
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
        }

        public void AddGlobalException()
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
        }
    }
}
