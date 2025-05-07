using CardSignal.Application.Interfaces;
using CardSignal.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardSignal.Application;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICardLinkService, CardLinkService>();
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IOfficeService, OfficeService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}