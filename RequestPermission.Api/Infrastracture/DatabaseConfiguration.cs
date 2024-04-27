using Microsoft.EntityFrameworkCore;

namespace RequestPermission.Api.Infrastracture;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<RequestPermissionContext>().AddDbContext<RequestPermissionContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        //services.AddDbContext<RequestPermissionContext>(options =>
        //{
        //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //});
    }
}

