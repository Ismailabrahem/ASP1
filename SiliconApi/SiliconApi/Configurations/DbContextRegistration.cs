using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SiliconApi.Configurations;

public static class DbContextRegistration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(x => x.UseSqlServer(config.GetConnectionString("SqlServer")));
    }
}
