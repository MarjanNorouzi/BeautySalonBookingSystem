using BeautySalon.Domain.Entities.IdentityModels;

namespace BeautySalon.Domain.Entities
{
    public sealed class Customer : BaseEntity<int>
    {
        public Customer()
        {
            Appointments = [];
        }

        public Guid UserId { get; set; }

        public required ApplicationUser ApplicationUser { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}