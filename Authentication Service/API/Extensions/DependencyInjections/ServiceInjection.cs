using Authentication_Service.Application.Interfaces;
using Authentication_Service.Infrastructure;

namespace Authentication_Service.API.Extensions.DependencyInjections;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}