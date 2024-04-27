using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.E_ID);
        builder.Property(x => x.E_NAME).IsRequired().HasMaxLength(50);
        builder.Property(x => x.E_SURNAME).IsRequired().HasMaxLength(50);
        builder.Property(x => x.E_DEPARTMENT).IsRequired(false);
        builder.Property(x => x.E_TITLE).HasColumnType("nvarchar(50)").HasMaxLength(50);
        builder.Property(x => x.InsertUser).IsRequired(false).HasColumnType("nvarchar(50)");
        builder.Property(x => x.InsertDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(x => x.UpdateDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(x => x.UpdateUser).IsRequired(false).HasColumnType("nvarchar(50)");
        builder.Property(x => x.E_EMP_COMM_ID).IsRequired(false);

        builder.HasOne(x => x.EMPLOYEE_COMMUNICATION)
            .WithOne().HasForeignKey<Employee>(x => x.E_EMP_COMM_ID).OnDelete(DeleteBehavior.NoAction);
       
    }
}
