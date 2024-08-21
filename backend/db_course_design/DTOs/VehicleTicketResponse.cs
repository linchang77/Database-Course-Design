namespace db_course_design.DTOs
{
    public class VehicleTicketResponse
    {
        public string? VehicleId { get; set; }

        public string? TicketType { get; set; }

        public decimal? TicketPrice { get; set; }

        public DateTime? TicketDepartureTime { get; set; }

        public DateTime? TicketArrivalTime { get; set; }

        public string? TicketDepartureCity { get; set; }

        public string? TicketArrivalCity { get; set; }

        public decimal TicketId { get; set; }

        public decimal? TicketRemaining { get; set; }

        public string? TicketDepartureStation { get; set; }

        public string? TicketArrivalStation { get; set; }
    }
}
