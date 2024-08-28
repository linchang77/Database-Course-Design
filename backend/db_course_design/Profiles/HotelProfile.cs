using AutoMapper;
using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile() 
        {
            CreateMap<HotelRequest, Hotel>();
            CreateMap<HotelRoomTypeRequest, HotelRoomType>();
            CreateMap<HotelRoomRequest, HotelRoom>();
            CreateMap<Hotel, HotelResponse>();
            CreateMap<HotelRoomType, HotelRoomDetail>();
            CreateMap<HotelRoom, HotelRoomResponse>();
        }
    }
}
