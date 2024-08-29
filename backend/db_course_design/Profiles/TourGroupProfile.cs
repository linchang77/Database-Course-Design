using AutoMapper;
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
            CreateMap<TourGroup, TourGroupResponse>();
            CreateMap<TourGroupRequest, TourGroup>();
            CreateMap<TourItineraryRequest, TourItinerary>();
            CreateMap<Guide, GuideResponse>();
        }
    }
}
