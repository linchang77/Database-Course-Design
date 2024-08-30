﻿using AutoMapper;
using db_course_design.DTOs;
using db_course_design.Services.impl;
using EntityFramework.Models;

namespace db_course_design.Profiles
{
    public class TourGroupProfile : Profile
    {
        public TourGroupProfile()
        {
            CreateMap<TourItinerary, TourItineraryResponse>();
            CreateMap<Hotel, HotelResponse>();
            CreateMap<TourGroup, TourGroupResponse>()
           .ForMember(dest => dest.guidename, opt => opt.MapFrom(src => src.Guide.GuideName))
           .ForMember(dest => dest.GoTicket, opt => opt.MapFrom(src => src.GoTicket))
           .ForMember(dest => dest.ReturnTicket, opt => opt.MapFrom(src => src.ReturnTicket)); 
            CreateMap<TourGroupRequest, TourGroup>();
            CreateMap<TourItineraryRequest, TourItinerary>();
            CreateMap<Guide, GuideResponse>();
            CreateMap<VehicleTicket, tourTicket>();
        }
    }
}
