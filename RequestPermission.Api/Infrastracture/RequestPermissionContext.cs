using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture
{
    public class RequestPermissionContext : DbContext
    {
        public RequestPermissionContext(DbContextOptions<RequestPermissionContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RequestPermissionContext).Assembly);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<EmployeeCommunication> EmployeeCommunication { get; set; }

    }
}
