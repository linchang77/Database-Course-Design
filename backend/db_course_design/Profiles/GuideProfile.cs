using AutoMapper;
using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Profiles
{
    public class GuideProfile : Profile
    {
        public GuideProfile()
        {
            CreateMap<Guide, GuideResponse>();
        }
    }
}
