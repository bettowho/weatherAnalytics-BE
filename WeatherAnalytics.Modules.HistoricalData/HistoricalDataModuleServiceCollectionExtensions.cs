using WeatherAnalytics.Modules.HistoricalData.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ProductModuleServiceCollectionExtensions
{
    public static IServiceCollection AddHistoricalDataModule(this IServiceCollection services)
    {
        services.AddScoped<IHistoricalDataService, HistoricalDataService>();
        return services;
    }

    public static IMvcBuilder AddHistoricalDataModule(this IMvcBuilder builder)
    {
        var services = builder.Services;
        services.AddHistoricalDataModule();
        return builder.AddApplicationPart(Assembly.GetExecutingAssembly());
    }
}
