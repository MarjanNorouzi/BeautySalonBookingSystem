using BeautySalon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace BeautySalon.InfraStructure.Mapping
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

    // TODO
    // آیا به کانفیگوریشن های مانند زیر که اطلاعات زیاد در خود ندارند، احتیاجی است؟
    public class CustomerEntityConfiguration : BeautySalonEntityTypeConfiguration<Customer, int>
    {
        public new void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
        }
    }

    public class OperatorEntityConfiguration : BeautySalonEntityTypeConfiguration<Operator, int>
    {
        public new void Configure(EntityTypeBuilder<Operator> builder)
        {
            base.Configure(builder);
        }
    }

    public class MainServiceEntityConfiguration : BeautySalonEntityTypeConfiguration<MainService, int>
    {
        // TODO
        // بررسی شود که با توجه به وجود داشتن این متد در کلاس والد، آیا بهتر است مدیفایر دیگری مانند
        // new, override, ..
        // استفاده شود یا خیر
        public new void Configure(EntityTypeBuilder<MainService> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnType(nameof(SqlDbType.NVarChar))
                .HasMaxLength(50)
                .IsRequired();

            // TODO
            // وارنینگ بررسی شود که چرا وقتی نال ایبل هست وارنینگ میده
            builder.Property(x => x.Description)
                .HasColumnType<string>(nameof(SqlDbType.NVarChar))
                .HasMaxLength(512)
                .IsRequired(false);

            base.Configure(builder);
        }
    }

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
                .HasDefaultValue(Decimal.Zero)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.EstimatedDuration)
                .HasColumnType(nameof(SqlDbType.Int))
                .IsRequired();

            base.Configure(builder);
        }
    }

    public class AppointmentEntityConfiguration : BeautySalonEntityTypeConfiguration<Appointment, int>
    {
        public new void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(x => x.ReservationDateTime)
            .HasColumnType(nameof(SqlDbType.DateTime))
            .IsRequired();

            base.Configure(builder);
        }
    }
}
