using Authentication_Service.Application.Utils;

namespace Authentication_Service.API.Extensions.DependencyInjections;

public static class OptionConfiguration
{
    public static IServiceCollection AddOptionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // Option Configuration
        services.Configure<Options>(configuration.GetSection(nameof(Options)));
        return services;
    }
}