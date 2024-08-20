using Microsoft.AspNetCore.Mvc;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Controllers
{
    /*业务逻辑：
         交通工具管理界面
         搜索：按照交通工具的类型（汽车，火车，飞机），出发地，到达地，出发时间进行车票的筛选
    api/
        Vehicle/
            {type},{ArrivalCity},{DepartureCity},{DepartureTime}/
                GET               - 获取该条件下所有的车次信息      
                /Modeltypr/{model}
    */
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("info/{type},{arrivalCity},{departureCity},{departureTime}")]
        public async Task<IActionResult> GetVehicleInfoByFilters(string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var schedules = await _vehicleService.GetVehicleInfoAsync(type, arrivalCity, departureCity, departureTime);
            
            if (schedules == null || schedules.Count == 0)
                return NotFound("No vehicle information found for the given criteria.");
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicleSchedule([FromBody] VehicleSchedule vehicleSchedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _vehicleService.AddVehicleScheduleAsync(vehicleSchedule);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the vehicle schedule.");
            return CreatedAtAction("Get", new { id = target.VehicleId }, target);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicleTicket([FromBody] VehicleTicket vehicleTicket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _vehicleService.AddVehicleTicketAsync(vehicleTicket);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the vehicle ticket.");
            return CreatedAtAction(nameof(GetVehicleInfoByFilters), new { id = target.TicketId }, target);
        }

        [HttpDelete("schedule/{vehicleId}")]
        public async Task<IActionResult> DelVehicleSchedule(string vehicleId)
        {
            var deleted = await _vehicleService.RemoveVehicleScheduleAsync(vehicleId);

            if (!deleted)
                return NotFound("No vehicle schedule to be deleted.");
            return NoContent();
        }

        [HttpDelete("ticket/{ticketId}")]
        public async Task<IActionResult> DelVehicleTicket(decimal ticketId)
        {
            var deleted = await _vehicleService.RemoveVehicleTicketAsync(ticketId);

            if (!deleted)
                return NotFound("No vehicle ticket to be deleted.");
            return NoContent();
        }
    }
}
