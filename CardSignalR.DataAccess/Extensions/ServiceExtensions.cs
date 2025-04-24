using CardSignalR.DataAccess.Interface;
using CardSignalR.DataAccess.Interfaces;
using CardSignalR.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<DataBaseContext>(options => 
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            ));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICardLinkRepository, CardLinkRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
    }
}