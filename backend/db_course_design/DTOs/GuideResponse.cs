using EntityFramework.Models;

namespace db_course_design.DTOs
{
    public class GuideResponse
    {
        public byte GuideId { get; set; }
        public string? GuideName { get; set; }

        public string? GuideGender { get; set; }

        public string? GuideIntroduction { get; set; }

        public decimal? GuideSalary { get; set; }

        public string? GuidePerformanceLevel { get; set; }

        public string? GuideSeniority { get; set; }

        public decimal? GuidePrice { get; set; }

        public string? ProfilePicture { get; set; }

        public virtual ICollection<GuideSalaryRecord> GuideSalaryRecords { get; set; } = new List<GuideSalaryRecord>();

    }
    public class GuideTimeRange
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class GuideReservationRequest
    {
        public int userId { get; set; }
        public byte GuideId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Service { get; set; }
    }
    public class GuidePictureRequest
    {
        public byte GuideId { get; set; }
        public string? Url { get; set; }
    }
}
