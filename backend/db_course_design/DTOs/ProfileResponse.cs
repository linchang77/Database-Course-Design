using EntityFramework.Models;

namespace db_course_design.DTOs
{
    public class ProfileResponse
    {
        public decimal Id { get; set; }

        public string? Name { get; set; }

        public string? Password { get; set; }
    }

    public class UserProfileResponse : ProfileResponse 
    {
        public DateTime? RegistrationTime { get; set; }

        public string? ProfilePicture { get; set; }

        public string? Gender { get; set; }

        public virtual ICollection<string> PhoneNumbers { get; set; } = new List<string>();
    }

    public class GuideProfileResponse : ProfileResponse
    {
        public string? Gender { get; set; }

        public bool? Free { get; set; }

        public string? Introduction { get; set; }

        public decimal? Salary { get; set; }

        public string? PerformanceLevel { get; set; }

        public string? Seniority { get; set; }

        public decimal? Price { get; set; }

        public string? ProfilePicture { get; set; }

        public virtual ICollection<string> PhoneNumbers { get; set; } = new List<string>();

        public virtual ICollection<string> Regions { get; set; } = new List<string>();
    }

    public class AdminProfileResponse : ProfileResponse { }
}
