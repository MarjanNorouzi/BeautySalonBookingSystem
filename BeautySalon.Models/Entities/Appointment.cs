namespace BeautySalon.Domain.Entities
{
    public record Appointment : BaseEntity<int>
    {
        public DateTime ReservationDateTime { get; set; } // Added property for reservation date and time

        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }

        public required ICollection<SubserviceOperator> SubserviceOperators { get; set; }
    }
}