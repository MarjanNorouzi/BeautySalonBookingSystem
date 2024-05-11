using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Domain.Entities
{
    public record MainService : BaseEntity<int>
    {
        public MainService()
        {
            Subservices = [];
        }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(512)]
        public string? Description { get; set; }
        public ICollection<Subservice> Subservices { get; set; }
    }
}