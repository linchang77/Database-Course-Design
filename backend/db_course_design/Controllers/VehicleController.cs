using Microsoft.AspNetCore.Mvc;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Controllers
{
    /*业务逻辑（车票信息查询）：
         交通工具管理界面/查询界面
         班次搜索：按照班号查询
         车票搜索：按照车票编号查询
         信息搜索：按照交通工具的类型（汽车，火车，飞机），出发地，到达地，出发时间进行车票的筛选
    api/
        Vehicle/
            schedule/
                {vehicleId}/
                    GET               - 获取指定班号的班次信息
            ticket/
                {ticketId}/
                    GET               - 获取指定车票编号的车票信息
            tickets/
                {vehicleId}/
                    GET               - 获取指定班号的所有车票列表
            info/
                {type},{ArrivalCity},{DepartureCity},{DepartureTime}/
                    GET               - 获取该条件下所有的车次信息
      业务逻辑（管理交通工具班次和车票信息）
         交通工具管理界面
    api/
        Vehicle/
            schedule/
                POST                - 添加交通工具班次信息
                {vehicleId}/
                    DELETE          - 删除交通工具班次信息
            ticket/
                POST                - 添加车票信息
                {ticketId}/
                    DELETE          - 删除车票信息
        
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

        [HttpGet("schedule/{vehicleId}")]
        public async Task<IActionResult> GetVehicleScheduleById(string vehicleId)
        {
            var schedule = await _vehicleService.GetVehicleScheduleAsync(vehicleId);

            if (schedule == null)
                return NotFound("No vehicle schedule of " + vehicleId);
            return Ok(schedule);
        }

        [HttpGet("ticket/{ticketId}")]
        public async Task<IActionResult> GetVehicleTicketByTicketId(decimal ticketId)
        {
            var ticket = await _vehicleService.GetVehicleTicketAsync(ticketId);

            if (ticket == null)
                return NotFound("No vehicle ticket with id " + ticketId);
            return Ok(ticket);
        }

        [HttpGet("tickets/{vehicleId}")]
        public async Task<IActionResult> GetVehicleTicketsByVehicleId(string vehicleId)
        {
            var tickets = await _vehicleService.GetVehicleTicketsAsync(vehicleId);

            if (tickets == null || tickets.Count == 0)
                return NotFound("No vehicle ticket for " + vehicleId);
            return Ok(tickets);
        }

        [HttpGet("info/{type},{arrivalCity},{departureCity},{departureTime}")]
        public async Task<IActionResult> GetVehicleInfoByFilters(string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var schedules = await _vehicleService.GetVehicleInfoAsync(type, arrivalCity, departureCity, departureTime);

            if (schedules == null || schedules.Count == 0)
                return NotFound("No vehicle information found for the given criteria.");
            return Ok(schedules);
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> AddVehicleSchedule([FromBody] VehicleScheduleRequest vehicleSchedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _vehicleService.AddVehicleScheduleAsync(vehicleSchedule);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the vehicle schedule.");
            return CreatedAtAction(nameof(GetVehicleInfoByFilters), target);
        }

        [HttpPost("ticket")]
        public async Task<IActionResult> AddVehicleTicket([FromBody] VehicleTicketRequest vehicleTicket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _vehicleService.AddVehicleTicketAsync(vehicleTicket);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the vehicle ticket.");
            return CreatedAtAction(nameof(GetVehicleInfoByFilters), target);
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
