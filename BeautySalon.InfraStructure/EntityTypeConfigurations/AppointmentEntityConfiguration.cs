using BeautySalon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace BeautySalon.InfraStructure.EntityTypeConfigurations
{
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
