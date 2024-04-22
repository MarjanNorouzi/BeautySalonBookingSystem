using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Domain.Entities
{
    public sealed class MainService : BaseEntity<int>
    {
        public MainService()
        {
            Subservices = [];
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(512)]
        public string? Description { get; set; }
        public ICollection<Subservice> Subservices { get; set; }

        //public static ValueTask<PrimitiveResult<MainService>> Create()
        //{
        //    return new ValueTask<PrimitiveResult<MainService>>();
        //}
    }
}