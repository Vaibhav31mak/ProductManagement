namespace ProductManagement.Application.DependencyInjection;

/// <summary>
/// DI for services and validators
/// </summary>
public static class ApplicationInjections
{
    extension(IServiceCollection services)
    {
        public void AddApplicationServices()
        {
            services.AddValidatorsFromAssemblyContaining<CreateProductValidators>();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));
            services.AddAutoMapper(cfg => cfg.AddProfile<ProductMappers>());
        }
    }
}
