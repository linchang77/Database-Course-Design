using AutoMapper;
using db_course_design.DTOs;
using db_course_design.Services.impl;
using EntityFramework.Models;

namespace db_course_design.Profiles
{
    public class GuideProfile : Profile
    {
        public GuideProfile()
        {
            // Guide -> GuideResponse 映射
            CreateMap<Guide, GuideResponse>();

            // GuideRequest -> Guide 映射
            CreateMap<GuideRequest, Guide>();

            CreateMap<GuideOrder, GuideTimeRange>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.ServiceBeginDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.ServiceEndDate));

            CreateMap<TourGroup, GuideTimeRange>();
        }
    }
}
