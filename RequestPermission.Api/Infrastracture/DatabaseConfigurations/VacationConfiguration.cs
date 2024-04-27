using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations;

public class VacationConfiguration : IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        builder.HasKey(v => v.V_ID);
        builder.Property(v => v.V_START_DATE).HasColumnType("datetime");
        builder.Property(v => v.V_END_DATE).HasColumnType("datetime");
        builder.Property(v => v.V_REASON).HasMaxLength(100);
        builder.Property(v => v.V_TYPE).HasMaxLength(50);
        builder.Property(v => v.InsertUser).IsRequired(false).HasColumnType("nvarchar(50)");
        builder.Property(v => v.InsertDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(v => v.UpdateDate).IsRequired(false).HasColumnType("datetime");
        builder.Property(v => v.UpdateUser).IsRequired(false).HasColumnType("nvarchar(50)");

        builder.HasOne(v => v.V_EMP)
            .WithMany(e => e.VACATIONS)
            .HasForeignKey(v => v.V_EMP_ID)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
