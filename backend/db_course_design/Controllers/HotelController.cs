using Microsoft.AspNetCore.Mvc;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Controllers
{
    /*业务逻辑：
        根据城市获取酒店信息
        返回某酒店各种房型剩余房间数和房型价格
        接收用户下单信息并分配房间
    */
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /*--根据城市获取酒店信息--*/
        [HttpGet("city")]
        public async Task<IActionResult> GetHotelByCity(string city)
        {
            var hotels = await _hotelService.GetHotelByCityAsync(city);
            if (hotels == null || !hotels.Any())
            {
                return NotFound(new { Message = "No hotel found in the provided City." });
            }
            return Ok(hotels);
        }

        /*--返回某酒店各种房型剩余房间数和房型价格--*/
        [HttpGet("detail/{hotelId}")]
        public async Task<IActionResult> GetRoomDetail(int hotelId)
        {
            var details = await _hotelService.GetHotelRoomDetailsAsync(hotelId);
            if (details == null || !details.Any()) 
            {
                return NotFound(new { Message = "this Hotel is closed" });
            }
            return Ok(details);
        }

        /*--创建一个酒店订单并分配房间--*/
        [HttpPost("create")]
        public async Task<IActionResult> CreateHotelOrder([FromBody] CreateHotelOrderRequest request)
        {
            var result = await _hotelService.CreateHotelOrderAsync(request);

            if (result == null)
            {
                return StatusCode(404, "create failed.");
            }

            var orderData = new OrderDatum
            {
                OrderType = "hotel",
                OrderDate = DateTime.Now,
                UserId = request.userId,
                Status = "Pending",
                Price = result.RoomPrice,
            };

            return Ok();
        }
    }
}
