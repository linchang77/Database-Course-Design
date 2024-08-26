using EntityFramework.Models;

namespace db_course_design.DTOs
{
    public class TourGroupResponse
    {
        public byte GroupId { get; set; }
        public string GroupName { get; set; }
        public decimal? GroupPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string GuideName { get; set; }
        public List<TourItinerary> TourItineraries { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
