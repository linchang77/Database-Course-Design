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
    路由：
    api/Hotel/
        all/
            Get
        {city}/
            Get
        detail/
            {hotelId}/
                Get
        rooms/
            {hotelId},{roomType}
        create/
            Post
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

        /*--获取全部酒店信息--*/
        [HttpGet("all")]
        public async Task<IActionResult> GetAllHotels()
        {
            return Ok(await _hotelService.GetAllHotelsAsync());
        }

        /*--根据城市获取酒店信息--*/
        [HttpGet("{city}")]
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
        public async Task<IActionResult> GetRoomDetail(decimal hotelId)
        {
            var details = await _hotelService.GetHotelRoomDetailsAsync(hotelId);
            if (details == null || !details.Any()) 
            {
                return NotFound(new { Message = "this Hotel is closed" });
            }
            return Ok(details);
        }

        /*--返回某酒店指定房型的所有房间信息--*/
        [HttpGet("rooms/{hotelId},{roomType}")]
        public async Task<IActionResult> GetAllRooms(decimal hotelId, string roomType)
        {
            var rooms = await _hotelService.GetAllHotelRoomsAsync(hotelId, roomType);
            if (!rooms.Any())
            {
                return NotFound("Hotel " + hotelId + " doesn't have " + roomType);
            }
            return Ok(rooms);
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

            return Ok();
        }

        /*
         * 业务逻辑：管理员可以在管理员界面可以对酒店及其房型、房间进行增删改
         * api/Hotel/
         *          add/
         *              hotel/
         *              POST    - 添加酒店信息
         *              roomtype/
         *              POST    - 添加房型信息
         *              room/
         *              POST    - 添加房间信息
         *          del/
         *              hotel/{hotelId}/
         *              DELETE  - 删除酒店信息
         *              roomtype/{hotelId},{roomType}/
         *              DELETE  - 删除房型信息
         *              room/{roomNumber},{hotelId}/
         *              DELETE  - 删除房间信息
         *          mod/
         *              hotel/
         *              PUT     - 更新酒店信息
         *              roomtype/
         *              PUT     - 更新房型信息
         *              room/
         *              PUT     - 更新房间信息
         */
        [HttpPost("add/hotel")]
        public async Task<IActionResult> AddHotel([FromBody] HotelRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _hotelService.AddHotelAsync(request);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the hotel.");
            return Ok(target);
        }

        [HttpPost("add/roomtype")]
        public async Task<IActionResult> AddHotelRoomType([FromBody] HotelRoomTypeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _hotelService.AddHotelRoomTypeAsync(request);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the hotel room type.");
            return Ok(target);
        }

        [HttpPost("add/room")]
        public async Task<IActionResult> AddHotelRoom([FromBody] HotelRoomRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _hotelService.AddHotelRoomAsync(request);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the hotel room.");
            return Ok(target);
        }

        [HttpDelete("del/hotel/{hotelId}")]
        public async Task<IActionResult> DeleteHotel(decimal hotelId)
        {
            var deleted = await _hotelService.DeleteHotelAsync(hotelId);

            if (!deleted)
                return NotFound("Hotel " + hotelId + " doesn't exist");
            return NoContent();
        }

        [HttpDelete("del/roomtype/{hotelId},{roomType}")]
        public async Task<IActionResult> DeleteHotelRoomType(decimal hotelId, string roomType)
        {
            var deleted = await _hotelService.DeleteHotelRoomTypeAsync(hotelId, roomType);

            if (!deleted)
                return NotFound("Hotel " + hotelId + " doesn't have " + roomType);
            return NoContent();
        }

        [HttpDelete("del/room/{roomNumber},{hotelId}")]
        public async Task<IActionResult> DeleteHotelRoom(string roomNumber, decimal hotelId)
        {
            var deleted = await _hotelService.DeleteHotelRoomAsync(roomNumber, hotelId);

            if (!deleted)
                return NotFound("Hotel " + hotelId + " doesn't have room " + roomNumber);
            return NoContent();
        }

        [HttpPut("mod/hotel")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelResponse request)
        {
            var target = await _hotelService.UpdateHotelAsync(request);

            if (target == null)
                return BadRequest("Cannot update hotel " + request.HotelId);
            return Ok(target);
        }

        [HttpPut("mod/roomtype")]
        public async Task<IActionResult> UpdateHotelRoomType([FromBody] HotelRoomDetail request)
        {
            var target = await _hotelService.UpdateHotelRoomTypeAsync(request);

            if (target == null) 
                return BadRequest("Cannot update " + request.RoomType + " of hotel " + request.HotelId);
            return Ok(target);
        }

        [HttpPut("mod/room")]
        public async Task<IActionResult> UpdateHotelRoom([FromBody] HotelRoomResponse request)
        {
            var target = await _hotelService.UpdateHotelRoomAsync(request);

            if (target == null)
                return BadRequest("Cannot update room " + request.RoomNumber + " of hotel " + request.HotelId);
            return Ok(target);
        }
    }
}
