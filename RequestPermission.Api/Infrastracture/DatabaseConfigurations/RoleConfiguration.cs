using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.R_ID);
            builder.Property(x => x.R_NAME).IsRequired().HasMaxLength(50);
            builder.HasMany(x=>x.USER_ROLES).WithOne(x=>x.ROLE).HasForeignKey(x=>x.UR_ROLE_ID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ROLE_PERMISSIONS).WithOne(x=>x.ROLE).HasForeignKey(x=>x.RP_ROLE_ID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
