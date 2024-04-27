using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.DataLayer.Generic;
using RequestPermission.Api.Entity;
using RequestPermission.Api.Infrastracture;

namespace RequestPermission.Api.DataLayer.Concrete;

public class EfEmployeeDal : GenericRepository<Employee>, IEfEmployeeDal
{
    public EfEmployeeDal(DbContextOptions<RequestPermissionContext> options,RequestPermissionContext permissionContext) : base(options, permissionContext)
    {
    }
}
