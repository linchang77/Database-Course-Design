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
}
