using AutoMapper;
using db_course_design.DTOs;
using db_course_design.Services.impl;
using EntityFramework.Models;

namespace db_course_design.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleSchedule, VehicleResponse>()
                .ForMember(dest => dest.DepartureTime, opt => opt.Ignore())
                .ForMember(dest => dest.ArrivalTime, opt => opt.Ignore())
                .ForMember(dest => dest.DepartureCity, opt => opt.Ignore())
                .ForMember(dest => dest.ArrivalCity, opt => opt.Ignore())
                .ForMember(dest => dest.DepartureStation, opt => opt.Ignore())
                .ForMember(dest => dest.ArrivalStation, opt => opt.Ignore());
            CreateMap<VehicleTicket, VehicleResponse>()
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(src => src.TicketDepartureTime))
                .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.TicketArrivalTime))
                .ForMember(dest => dest.DepartureCity, opt => opt.MapFrom(src => src.TicketDepartureCity))
                .ForMember(dest => dest.ArrivalCity, opt => opt.MapFrom(src => src.TicketArrivalCity))
                .ForMember(dest => dest.DepartureStation, opt => opt.MapFrom(src => src.TicketDepartureStation))
                .ForMember(dest => dest.ArrivalStation, opt => opt.MapFrom(src => src.TicketArrivalStation));
            CreateMap<VehicleScheduleRequest, VehicleSchedule>();
            CreateMap<VehicleTicketRequest, VehicleTicket>();
        }
    }
}
