using BeautySalon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace BeautySalon.InfraStructure.EntityTypeConfigurations
{
    public class BeautySalonEntityTypeConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TKey>
    where TKey : new()
    {

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.UpdatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType(nameof(SqlDbType.DateTime));

            builder.Property(b => b.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType(nameof(SqlDbType.DateTime));

            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);
        }
    }
}
