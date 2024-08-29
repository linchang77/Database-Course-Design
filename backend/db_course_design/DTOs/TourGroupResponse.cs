using EntityFramework.Models;

namespace db_course_design.DTOs
{
    public class TourGroupResponse
    {
        public byte GroupId { get; set; }

        public byte? GuideId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? GroupName { get; set; }

        public decimal? GroupPrice { get; set; }

        public decimal? GoTicketId { get; set; }

        public decimal? ReturnTicketId { get; set; }

        public string? Departure { get; set; }

        public string? Destination { get; set; }
        public string? guidename { get; set; }

        public List<TourItineraryResponse> TourItineraries { get; set; }

        public List<HotelResponse> Hotels { get; set; }
    }

    public class TourItineraryResponse
    {
        public byte ItineraryId { get; set; }

        public byte? GroupId { get; set; }

        public DateTime? ItineraryTime { get; set; }

        public TimeSpan? ItineraryDuration { get; set; }

        public decimal? ScenicSpotId { get; set; }

        public string? Activities { get; set; }
    }
}
