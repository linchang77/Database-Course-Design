namespace db_course_design.DTOs
{
    public class VehicleResponse
    {
        public string VehicleId { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleModel { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string? DepartureStation { get; set; }
        public string? ArrivalStation { get; set; }
        public decimal TicketId { get; set; }
        public string? TicketType { get; set; }
        public decimal? TicketPrice { get; set; }
        public decimal? TicketRemaining { get; set; }
    }

    public class VehicleScheduleResponse
    {
        public string? ArrivalCity { get; set; }

        public string VehicleId { get; set; } = null!;

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public string? VehicleType { get; set; }

        public string? DepartureCity { get; set; }

        public string? VehicleModel { get; set; }

        public string? ArrivalStation { get; set; }

        public string? DepartureStation { get; set; }
    }

    public class VehicleTicketResponse
    {
        public string? VehicleId { get; set; }

        public string? VehicleType { get; set; }

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
