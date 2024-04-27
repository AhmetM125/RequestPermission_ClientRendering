using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.D_ID);
        builder.Property(x => x.D_NAME).IsRequired().HasMaxLength(50);
        builder.Property(x => x.InsertUser).IsRequired(false).HasColumnType("nvarchar(50)");
        builder.Property(x => x.InsertDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(x => x.UpdateDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(x => x.UpdateUser).IsRequired(false).HasColumnType("nvarchar(50)");

        builder.HasMany(d => d.EMPLOYEES)
        .WithOne(e => e.DEPARTMENT)
        .HasForeignKey(e => e.E_DEPARTMENT)
         .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x=>x.DepartmentDto).WithOne().HasForeignKey<Department>(x=>x.D_PARENT_ID).OnDelete(DeleteBehavior.NoAction);
        //builder.HasOne(x=>x.Manager).WithOne(x=>x.DEPARTMENT).HasForeignKey<Department>(x=>x.D_MANAGER_ID).OnDelete(DeleteBehavior.NoAction); 

    }
}
