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
    }
}
