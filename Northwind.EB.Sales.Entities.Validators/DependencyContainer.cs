namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthwindValidators(this IServiceCollection services)
    {
        services.AddScoped<IModelValidator<CreateOrderDto>, CreateOrderDtoValidator>();

        services.AddDefaultModelValidatorServices();

        return services;
    }
}
