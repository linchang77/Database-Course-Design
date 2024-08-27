using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IHotelService
    {
        // 根据城市获取酒店信息
        Task<List<HotelResponse>> GetHotelByCityAsync(string city);
        // 返回某酒店各种房型剩余房间数和房型价格
        Task<List<HotelRoomDetail>> GetHotelRoomDetailsAsync(int hotelId);
        // 创建一个酒店订单并分配房间
        Task<CreateHotelOrderResponse> CreateHotelOrderAsync(CreateHotelOrderRequest request);
        // 添加酒店信息
        Task<HotelResponse> AddHotelAsync(HotelRequest request);
        // 删除酒店信息
        Task<bool> DeleteHotelAsync(decimal hotelId);
        // 更新酒店信息
        Task<HotelResponse> UpdateHotelAsync(HotelRequest request);
        // 添加酒店房型信息
        Task<HotelRoomDetail> AddHotelRoomTypeAsync(HotelRoomTypeRequest request);
        // 删除酒店房型信息
        Task<bool> DeleteHotelRoomTypeAsync(decimal hotelId, string roomType);
        // 更新酒店房型信息
        Task<HotelRoomDetail> UpdateHotelRoomTypeAsync(HotelRoomTypeRequest request);
        // 添加酒店房间信息
        Task<HotelRoomResponse> AddHotelRoomAsync(HotelRoomRequest request);
        // 删除酒店房间信息
        Task<bool> DeleteHotelRoomAsync(string roomNumber, decimal hotelId);
        // 更新酒店房间信息
        Task<HotelRoomResponse> UpdateHotelRoomTypeAsync(HotelRoomRequest request);
    }
}
