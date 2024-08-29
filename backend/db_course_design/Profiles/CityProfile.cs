using AutoMapper;
using EntityFramework.Models;
using db_course_design.DTOs;
using db_course_design.Services.impl;

namespace db_course_design.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityResponse>();
            CreateMap<Climate, ClimateResponse>();
            CreateMap<Hotel, HotelResponse>();
            CreateMap<ScenicSpot, ScenicSpotResponse>();
            CreateMap<VehicleSchedule, VehicleScheduleResponse>();
            CreateMap<VehicleTicket, VehicleTicketResponse>();
            CreateMap<City, CityDetail>()
                .ForMember(dst => dst.TodayTemperature, opt => opt.MapFrom(src => src.Climate.TodayTemperature))
                .ForMember(dst => dst.TodayWeather, opt => opt.MapFrom(src => src.Climate.TodayWeather))
                .ForMember(dst => dst.TomorrowTemperature, opt => opt.MapFrom(src => src.Climate.TomorrowTemperature))
                .ForMember(dst => dst.TomorrowWeather, opt => opt.MapFrom(src => src.Climate.TomorrowWeather));
            
            CreateMap<CityRequest, City>();
            CreateMap<CityRequest, Climate>();
        }
    }
}
