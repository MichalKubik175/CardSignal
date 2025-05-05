using CardSignal.DataAccess.Interfaces;
using CardSignal.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardSignal.DataAccess;

public static class ServiceExtensions
{
    public static void AddMySqlContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<DataBaseContext>(options => 
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                mysqlOptions =>
                {
                    mysqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }
            ));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICardLinkRepository, CardLinkRepository>();
        services.AddScoped<IOfficeRepository, OfficeRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
    }
}