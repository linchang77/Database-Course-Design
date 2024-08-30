using EntityFramework.Models;

namespace db_course_design.DTOs
{
    public class CityResponse
    {
        public string CityName { get; set; } = null!;

        public string? Province { get; set; }

        public string? CityIntroduction { get; set; }
    }

    public class CityDetail
    {
        public string CityName { get; set; } = null!;

        public string? Province { get; set; }

        public string? CityIntroduction { get; set; }

        public decimal? TodayTemperature { get; set; }

        public string? TodayWeather { get; set; }

        public decimal? TomorrowTemperature { get; set; }

        public string? TomorrowWeather { get; set; }

        public virtual ICollection<HotelResponse> Hotels { get; set; } = new List<HotelResponse>();

        public virtual ICollection<ScenicSpotResponse> ScenicSpots { get; set; } = new List<ScenicSpotResponse>();

        public virtual ICollection<VehicleScheduleResponse> VehicleScheduleArrivalCityNavigations { get; set; } = new List<VehicleScheduleResponse>();

        public virtual ICollection<VehicleScheduleResponse> VehicleScheduleDepartureCityNavigations { get; set; } = new List<VehicleScheduleResponse>();

        public virtual ICollection<VehicleTicketResponse> VehicleTicketTicketArrivalCityNavigations { get; set; } = new List<VehicleTicketResponse>();

        public virtual ICollection<VehicleTicketResponse> VehicleTicketTicketDepartureCityNavigations { get; set; } = new List<VehicleTicketResponse>();
    }

    public class ClimateResponse
    {
        public decimal? TodayTemperature { get; set; }

        public string? TodayWeather { get; set; }

        public decimal? TomorrowTemperature { get; set; }

        public string? TomorrowWeather { get; set; }
    }
}
