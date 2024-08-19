namespace db_course_design.Returns
{
    public class VehicleScheduleResponse
    {
        public string VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
    }
}
