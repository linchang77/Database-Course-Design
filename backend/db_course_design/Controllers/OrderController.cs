using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;
using db_course_design.Common;
using System.Net.Sockets;
using db_course_design.Services.impl;

namespace db_course_design.Controllers
{
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
            role/                   - 包含:role&Id
                GET                 - 获取所有与自己相关的订单
                category    ------- 防止路由冲突
                    {orderType}/
                        GET         - 按订单分类筛选
                status
                    {statusType}/
                        GET         - 按订单状态筛选
                {orderId}/
                    GET             - 按订单ID搜索
                    DELETE          - 取消某个订单(软删除)
                    Patch           - 某个订单完成付款(更新资源的部分字段)
                date-range/         - 包含：start&end
                    GET             - 按时间段筛选
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

        /*--获取角色&Id相关的订单--*/
        [HttpGet("role")]
        public async Task<IActionResult> GetAllOrders(string role, int Id)
        {
            var orders = await _orderService.GetAllOrdersAsync(role, Id);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found for the provided ID." });
            }
            return Ok(orders);
        }

        /*--按订单分类筛选--*/
        [HttpGet("role/category/{orderType}")]
        public async Task<IActionResult> GetOrdersByCategory(string role, int Id, string orderType)
        {
            var orders = await _orderService.GetOrdersByCategoryAsync(role, Id, orderType);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found in category " + orderType + "." });
            }
            return Ok(orders);
        }

        /*--按订单状态筛选--*/
        [HttpGet("role/status/{statusType}")]
        public async Task<IActionResult> GetOrdersByStatus(string role, int Id, string statusType)
        {
            var orders = await _orderService.GetOrdersByStatusAsync(role, Id, statusType);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found in status " + statusType + "." });
            }
            return Ok(orders);
        }

        /*--按订单ID搜索--*/
        [HttpGet("role/{orderId}")]
        public async Task<IActionResult> GetOrderById(string role, int Id, int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(role, Id, orderId);
            if(order == null)
            {
                return NotFound(new { Message = "Not found or you have no permission." });
            }
            return Ok(order);
        }

        /*--取消某个订单(软删除)--*/
        [HttpDelete("role/{orderId}")]
        public async Task<IActionResult> DelOrderById(string role, int Id, int orderId)
        {
            bool flag = await _orderService.StatusUpdateAsync(role, Id, orderId, "Cancelled");
            if(flag)
                return Ok(new { Message = "订单号为"+ orderId + "的订单已取消." });
            return NotFound(new { Message = "Not found or you have no permission." });
        }

        /*--某个订单完成付款(更新资源的部分字段)--*/
        [HttpPatch("role/{orderId}")]
        public async Task<IActionResult> OrderPayedStatus(string role, int Id, int orderId)
        {
            bool flag = await _orderService.StatusUpdateAsync(role, Id, orderId, "Completed");
            if (flag)
                return Ok(new { Message = "订单号为" + orderId + "的订单已支付." });
            return NotFound(new { Message = "Not found or you have no permission." });
        }

        /*--按时间段筛选--*/
        [HttpGet("role/date-range")]
        public async Task<IActionResult> GetOrdersByTime(string role, int Id, DateTime start, DateTime end)
        {
            var orders = await _orderService.GetOrdersByTimeAsync(role, Id, start, end);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found in range " + start + "-" + end + " ." });
            }
            return Ok(orders);
        }

        /*--创建订单--*/
        [HttpPost("creation")]
        public async Task<ActionResult<OrderDatum>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Order data is required.");
            }

            // 将请求数据映射到 OrderDatum
            var orderData = new OrderDatum
            {
                OrderType = request.OrderType,
                OrderDate = request.OrderDate,
                UserId = request.UserId,
                Status = request.Status,
                Price = request.Price
            };

            // 调用服务层来创建订单
            var newOrder = await _orderService.CreateOrderAsync(orderData);

            return CreatedAtAction(nameof(GetOrderById), new { orderId = newOrder.OrderId }, newOrder);
        }
    }
}
