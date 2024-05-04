using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Department.Abstract;
using RequestPermission_ClientRendering.Services.Department.Concrete;
using RequestPermission_ClientRendering.Services.Employee.Abstract;
using RequestPermission_ClientRendering.Services.Employee.Concrete;
using RequestPermission_ClientRendering.Services.RequestPermission.Abstract;
using RequestPermission_ClientRendering.Services.RequestPermission.Concrete;
using RequestPermission_ClientRendering.Services.Security.Abstract;
using RequestPermission_ClientRendering.Services.Security.Concrete;

namespace RequestPermission_ClientRendering.DependencyInjection;

public static class DependencyConfigurations
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<MainLayoutCascadingValue>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IRequestPermissionService,RequestPermissionService>();
    }
}
