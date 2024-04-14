using BeautySalon.Models.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    public abstract record BaseEntity<TKey> where TKey : new()
    {
        [Key]
        public TKey Id { get; set; }
        // TODO
        // بهتر است تایپ تاریخ ها چه باشد؟
        // DateTime or DateTimeOffset
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public record Customer : BaseEntity<int>
    {
        public Customer()
        {
            Appointments = [];
        }

        //public int ApplicationUserId { get; set; }

        //[ForeignKey(nameof(ApplicationUser.Id))]
        //public required ApplicationUser ApplicationUser { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }

    public record Operator : BaseEntity<int>
    {
        public Operator()
        {
            SubserviceOperators = [];
        }

        // این پراپرتی رو برای حالتی گذاشته بودم که نشون بدم اپراتور چه مهارت هایی داره و کارهایی رو میتونه انجام بده
        // که با کلید داشتن به جدول ساب سرویس مشخص میشه و نیازی به این پراپرتی نیست
        //public string Expertise { get; set; }

        //public string ApplicationUserId { get; set; }
        //[ForeignKey(nameof(ApplicationUser.Id))]
        //public ApplicationUser ApplicationUser { get; set; }

        public ICollection<SubserviceOperator> SubserviceOperators { get; set; }
    }

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

    public record Subservice : BaseEntity<int>
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

    public record SubserviceOperator : BaseEntity<int>
    {
        public int SubserviceId { get; set; }
        public required Subservice Subservice { get; set; }
        public int OperatorId { get; set; }
        public required Operator Operator { get; set; }
        public int AppointmentId { get; set; }
        public required Appointment Appointment { get; set; }
    }

    public record Appointment : BaseEntity<int>
    {
        public DateTime ReservationDateTime { get; set; } // Added property for reservation date and time

        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }

        public ICollection<SubserviceOperator> SubserviceOperators { get; set; }
    }
}
