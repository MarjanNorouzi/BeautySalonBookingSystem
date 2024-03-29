using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public abstract record BaseEntity<TKey> where TKey : new()
    {
        [Key]
        public TKey Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public record Human : BaseEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Family { get; set; }

        [Required]
        [Length(10, 10)]
        public string PhoneNumber { get; set; }
    }
    
    public record Customer : Human
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }

    public record Operator : Human
    {
        public string Expertise { get; set; }
        public ICollection<SubserviceOperator> SubserviceOperators { get; set; }
    }

    public record MainService : BaseEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Subservice> Subservices { get; set; }
    }

    public record Subservice : BaseEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } // Price in toman (avoid floating-point issues)
        public int EstimatedDuration { get; set; } // Duration in minutes
        public int MainServiceId { get; set; }
        public MainService MainService { get; set; }
        public ICollection<SubserviceOperator> SubserviceOperators { get; set; }
    }

    public record SubserviceOperator
    {
        public int SubserviceId { get; set; }
        public Subservice Subservice { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
    }

    public record Appointment
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SubserviceOperatorId { get; set; }
        public SubserviceOperator SubserviceOperator { get; set; }
        public DateTime ReservationDateTime { get; set; } // Added property for reservation date and time
    }
}
