using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations;

public class EmployeeComminucationConfiguration : IEntityTypeConfiguration<EmployeeCommunication>
{
    public void Configure(EntityTypeBuilder<EmployeeCommunication> builder)
    {
        builder.HasKey(e => e.EC_ID);
        builder.Property(e => e.EC_ADDRESS).HasColumnType("nvarchar(50)");
        builder.Property(e => e.EC_COUNTRY).HasColumnType("nvarchar(50)");
        builder.Property(e => e.EC_PHONE).HasColumnType("nvarchar(50)");
        builder.Property(e => e.EC_EMAIL).HasColumnType("nvarchar(50)");
        builder.Property(e => e.InsertUser).IsRequired(false).HasColumnType("nvarchar(50)");
        builder.Property(e => e.InsertDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(e => e.UpdateDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(e => e.UpdateUser).IsRequired(false).HasColumnType("nvarchar(50)");
    }
}
