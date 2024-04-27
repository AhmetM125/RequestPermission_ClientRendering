using RequestPermission.Api.DataLayer.Concrete;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Services.Concrete;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.DependencyInjection;

public static class ConfigureDI
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IEfEmployeeDal, EfEmployeeDal>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEfEmployeeDal, EfEmployeeDal>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEfDepartmentDal, EfDepartmentDal>();
        services.AddScoped<ISecurityService, SecurityService>();
        services.AddScoped<IEfSecurityDal, EfSecurityDal>();
    }
}
