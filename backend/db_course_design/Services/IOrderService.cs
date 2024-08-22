using db_course_design.DTOs;
using db_course_design.Services.impl;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IOrderService
    {
        // 获取所有userId的订单信息
        Task<List<OrderResponse>> GetAllOrdersAsync(string role, int Id);
        // 按订单分类筛选
        Task<List<OrderResponse>> GetOrdersByCategoryAsync(string role, int Id, string orderType);
        // 按订单状态筛选
        Task<List<OrderResponse>> GetOrdersByStatusAsync(string role, int Id, string status);
        // 按订单ID搜索
        Task<OrderResponse> GetOrderByIdAsync(string role, int Id, int orderId);
        // 删除某个订单(其实是改状态属性)
        Task<bool> DelOrderByIdAsync(string role, int Id, int orderId);
        // 按时间段筛选
        Task<List<OrderResponse>> GetOrdersByTimeAsync(string role, int Id, DateTime start, DateTime end);
        // 创建一个订单
        Task<OrderDatum> CreateOrderAsync(OrderDatum orderData);
    }
}
