using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public abstract record BaseEntity<TKey> where TKey : new()
    {
        [Key]
        public TKey Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset ModificationDate { get; set; }
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
        //public string PhoneNumberConfirmed { get; set;}
        //public string EmailConfirmed { get; set;}
    }

    public record Customer : Human
    {
        public string? Email { get; set; }
    }

    public record Operator : Human
    {

    }

    public record MainService : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
    }

    public record SubService : BaseEntity<int>
    {
        public int MainServiceId { get; set; }
        public string Name { get; set; }
    }

    public record ServiceOperator : BaseEntity<int>
    {
        public int OperatorId { get; set; }
        public int SubServiceId { get; set; }
    }

    public record Appoinnment : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public int ServiceOperatorId { get; set; }
    }
}
