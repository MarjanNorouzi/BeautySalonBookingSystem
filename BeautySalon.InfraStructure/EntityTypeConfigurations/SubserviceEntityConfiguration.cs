using BeautySalon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace BeautySalon.InfraStructure.EntityTypeConfigurations
{
    public class SubserviceEntityConfiguration : BeautySalonEntityTypeConfiguration<Subservice, int>
    {
        public new void Configure(EntityTypeBuilder<Subservice> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType(nameof(SqlDbType.NVarChar))
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType<string>(nameof(SqlDbType.NVarChar))
                .HasMaxLength(512)
                .IsRequired(false);

            builder.Property(x => x.Price)
                .HasColumnType(nameof(SqlDbType.Decimal))
                .HasPrecision(18, 4)
                .HasDefaultValue(decimal.Zero)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.EstimatedDuration)
                .HasColumnType(nameof(SqlDbType.Int))
                .IsRequired();

            base.Configure(builder);
        }
    }
}
