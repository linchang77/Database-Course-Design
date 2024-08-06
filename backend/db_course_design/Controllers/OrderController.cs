using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;
using db_course_design.Common;
using System.Net.Sockets;
using db_course_design.Services;
namespace db_course_design.Controllers
{
    public enum UserType
    {
        User,
        Guide,
        Admin,
    }
    public enum OrderType
    {
        GuideOrder,
        HotelOrder,
        ScenicOrder,
        TourOrder,
        VehicleOrder,
    }

    /*业务逻辑：
        订单管理界面
         可以看到所有与自己相关的订单(管理员是全部订单)，
         搜索：按订单ID搜索唯一对应的订单
         删除：通过删除按钮删除某个订单
         筛选：1.分类：全部订单/酒店/出行/景点/导游/旅行团
               2.状态：全部订单/待出行/已完成/已取消
               3.按时间段搜索订单
               4.根据user/guide_id搜索
        订单修改界面(only管理员)
         订单所有属性以输入框中文字的形式呈现，可更改
         点保存键保存，点取消键退出，均返回订单管理界面
    api/
        Order/
            {userId}/
                GET               - 获取所有与自己相关的订单
                category/
                    {orderType}/
                        GET       - 按订单分类筛选
                status/
                    {statusType}/
                        GET       - 按订单状态筛选
                order/
                    {orderId}/
                        GET       - 按订单ID搜索
                        DELETE    - 删除某个订单
                date-range/
                    GET           - 按时间段筛选
    */
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        /*--获取所有userId的订单信息--*/
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllOrders(int userId)
        {
            var orders = await _orderService.GetAllOrdersAsync(userId);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found for the provided user ID." });
            }
            return Ok(orders);
        }

        /*--按订单分类筛选--*/
        [HttpGet("{userId}/category/{orderType}")]
        public async Task<IActionResult> GetOrdersByCategory(int userId, string orderType)
        {
            var orders = await _orderService.GetOrdersByCategoryAsync(userId, orderType);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found in category " + orderType + "." });
            }
            return Ok(orders);
        }

        /*--按订单状态筛选--*/
        [HttpGet("{userId}/status/{statusType}")]
        public async Task<IActionResult> GetOrdersByStatus(int userId, string statusType)
        {
            var orders = await _orderService.GetOrdersByStatusAsync(userId, statusType);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found in status " + statusType + "." });
            }
            return Ok(orders);
        }

        /*--按订单ID搜索--*/
        [HttpGet("{userId}/order/{orderId}")]
        public async Task<IActionResult> GetOrderById(int userId, int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(userId, orderId);
            if(order == null)
            {
                return NotFound(new { Message = "Not found or you have no permission." });
            }
            return Ok(order);
        }

        /*--删除某个订单--*/
        [HttpDelete("{userId}/order/{orderId}")]
        public async Task<IActionResult> DelOrderById(int userId, int orderId)
        {
            bool flag = await _orderService.DelOrderByIdAsync(userId, orderId);
            if(flag)
                return Ok(new { Message = "订单号为"+ orderId + "的订单已取消." });
            return NotFound(new { Message = "Not found or you have no permission." });
        }

        /*--按时间段筛选--*/
        [HttpGet("{userId}/date-range")]
        public async Task<IActionResult> GetOrdersByTime(int userId, DateTime start, DateTime end)
        {
            var orders = await _orderService.GetOrdersByTimeAsync(userId, start, end);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found in range " + start + "-" + end + " ." });
            }
            return Ok(orders);
        }
    }
}
