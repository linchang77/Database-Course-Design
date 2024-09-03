using EntityFramework.Models;

namespace db_course_design.DTOs
{
    public class ScenicSpotResponse
    {
        public string? ScenicSpotName { get; set; }

        public decimal ScenicSpotId { get; set; }

        public string? CityName { get; set; }

        public string? ScenicSpotGrade { get; set; }

        public string? ScenicSpotIntroduction { get; set; }

        public string? ScenicSpotLocation { get; set; }

        public decimal? ScenicSpotRemoteness { get; set; }
    }
    public class ScenicSpotTicketResponse
    {
        public decimal ScenicSpotId { get; set; }

        public string TicketType { get; set; } = null!;

        public decimal? TicketPrice { get; set; }

        public decimal? TicketRemaining { get; set; }

        public DateTime TicketDate { get; set; }
    }

    public class AdultChildTicketResponse
    {
        public ScenicSpotTicketResponse? AdultTicket;

        public ScenicSpotTicketResponse? ChildTicket;
    }
}
