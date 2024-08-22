using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrdersAsync(int userId);
        Task<List<GuideOrderDetail>> GetGuideOrdersAsync(int userId);
        Task<List<HotelOrderDetail>> GetHotelOrdersAsync(int userId);
        Task<List<ScenicOrderDetail>> GetScenicOrdersAsync(int userId);
        Task<List<TourOrderDetail>> GetTourOrdersAsync(int userId);
        Task<List<VehicleOrderDetail>> GetVehicleOrdersAsync(int userId);
        Task<List<OrderResponse>> GetOrdersByCategoryAsync(int userId, string orderType);
        Task<List<OrderResponse>> GetOrdersByStatusAsync(int userId, string status);
        Task<OrderResponse> GetOrderByIdAsync(int userId, int orderId);
        Task<bool> DelOrderByIdAsync(int userId, int orderId);
        Task<List<OrderResponse>> GetOrdersByTimeAsync(int userId, DateTime start, DateTime end);
        Task<OrderDatum> CreateOrderAsync(OrderDatum orderData);
    }
}
