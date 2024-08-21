namespace db_course_design.DTOs
{
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
}
