using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Domain.Entities
{
    public sealed class Subservice : BaseEntity<int>
    {
        public Subservice()
        {
            SubserviceOperators = [];
        }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(512)]
        public string? Description { get; set; }

        public decimal Price { get; set; } = 0; // Price in toman (avoid floating-point issues)

        public int EstimatedDuration { get; set; } // Duration in minutes

        public int MainServiceId { get; set; }
        public required MainService MainService { get; set; }

        public ICollection<SubserviceOperator> SubserviceOperators { get; set; }
    }
}