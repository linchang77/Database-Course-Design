using AutoMapper;
using db_course_design.DTOs;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace db_course_design.Services
{
    public interface IHotelService
    {
        // 映射器
        IMapper _mapper { get; }
        // 返回所有酒店信息
        Task<List<HotelResponse>> GetAllHotelsAsync();
        // 根据城市获取酒店信息
        Task<List<HotelResponse>> GetHotelByCityAsync(string city);
        // 查询酒店房型和价格
        Task<List<HotelTypeDetail>> GetHotelTypeDetailAsync(decimal hotelId);
        // 返回某酒店各种房型剩余房间数和房型价格
        Task<HotelRoomDetail?> GetHotelRoomDetailsAsync(decimal hotelId, string roomType, DateTime? StartDate, DateTime? EndDate);
        // 返回某酒店指定房型的所有房间
        Task<List<HotelRoomResponse>> GetAllHotelRoomsAsync(decimal hotelId, string roomType);
        // 创建一个酒店订单并分配房间
        Task<string> CreateHotelOrderAsync(CreateHotelOrderRequest request);
        // 添加酒店信息
        Task<HotelResponse?> AddHotelAsync(HotelRequest request);
        // 删除酒店信息
        Task<bool> DeleteHotelAsync(decimal hotelId);
        // 更新酒店信息
        Task<HotelResponse?> UpdateHotelAsync(HotelResponse request);
        // 添加酒店房型信息
        Task<HotelRoomDetail?> AddHotelRoomTypeAsync(HotelRoomTypeRequest request);
        // 删除酒店房型信息
        Task<bool> DeleteHotelRoomTypeAsync(decimal hotelId, string roomType);
        // 更新酒店房型信息
        Task<HotelRoomDetail?> UpdateHotelRoomTypeAsync(HotelRoomDetail request);
        // 添加酒店房间信息
        Task<HotelRoomResponse?> AddHotelRoomAsync(HotelRoomRequest request);
        // 删除酒店房间信息
        Task<bool> DeleteHotelRoomAsync(string roomNumber, decimal hotelId);
        // 更新酒店房间信息
        Task<HotelRoomResponse?> UpdateHotelRoomAsync(HotelRoomResponse request);
        // 推荐酒店
        Task<IEnumerable<HotelResponse>> GetRecommendedHotels();
    }
}
