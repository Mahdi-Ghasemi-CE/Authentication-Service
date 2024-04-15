using Authentication_Service.Application.Interfaces;
using Authentication_Service.Application.Services.User;
using Authentication_Service.Infrastructure;

namespace Authentication_Service.Extensions.DependencyInjections;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // user service
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}