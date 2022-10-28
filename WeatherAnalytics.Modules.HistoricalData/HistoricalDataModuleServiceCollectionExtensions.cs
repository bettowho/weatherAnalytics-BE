namespace Microsoft.Extensions.DependencyInjection;

public static class ProductModuleServiceCollectionExtensions
{
    public static IServiceCollection AddHistoricalDataModule(this IServiceCollection services)
    {
        return services;
    }

    public static IMvcBuilder AddHistoricalDataModule(this IMvcBuilder builder)
    {
        return builder.AddApplicationPart(Assembly.GetExecutingAssembly());
    }
}
