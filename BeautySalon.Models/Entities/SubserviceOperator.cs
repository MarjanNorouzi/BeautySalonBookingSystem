namespace BeautySalon.Domain.Entities
{
    public sealed class SubserviceOperator : BaseEntity<int>
    {
        public int SubserviceId { get; set; }
        public required Subservice Subservice { get; set; }
        public int OperatorId { get; set; }
        public required Operator Operator { get; set; }
        public int AppointmentId { get; set; }
        public required Appointment Appointment { get; set; }
    }
}