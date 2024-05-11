using BeautySalon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace BeautySalon.InfraStructure.EntityTypeConfigurations
{
    public class MainServiceEntityConfiguration : BeautySalonEntityTypeConfiguration<MainService, int>
    {
        // TODO
        // بررسی شود که با توجه به وجود داشتن این متد در کلاس والد، آیا بهتر است مدیفایر دیگری مانند
        // new, override, ..
        // استفاده شود یا خیر
        public new void Configure(EntityTypeBuilder<MainService> builder)
        {
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
}
