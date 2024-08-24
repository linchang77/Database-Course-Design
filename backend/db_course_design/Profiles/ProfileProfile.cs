using AutoMapper;
using EntityFramework.Models;
using db_course_design.DTOs;

namespace db_course_design.Profiles
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile() 
        {
            CreateMap<User, UserProfileResponse>()
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.UserPhoneNumbers.Select(x => x.PhoneNumber).ToList()));
            CreateMap<Guide, GuideProfileResponse>()
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.GuidePhoneNumbers.Select(x => x.PhoneNumber).ToList()))
                .ForMember(dest => dest.Regions, opt => opt.MapFrom(src => src.GuideRegions.Select(x => x.GuidedRegion).ToList()));
            CreateMap<Admin, AdminProfileResponse>();
            
            RecognizePrefixes("User");
            RecognizePrefixes("Guide");
            RecognizePrefixes("Admin");
        }
    }
}
