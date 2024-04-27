using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.P_ID);
            builder.Property(p => p.P_NAME).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.HasMany(x=>x.ROLE_PERMISSION).WithOne(x=>x.PERMISSION).HasForeignKey(x=>x.RP_PERMISSION_ID).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
