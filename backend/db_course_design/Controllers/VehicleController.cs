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
            schedules/
                GET                   - 获取所有班次信息
            tickets/
                GET                   - 获取所有车票列表
                {vehicleId}/
                    GET               - 获取指定班号的所有车票列表
            info/
                {type},{ArrivalCity},{DepartureCity},{DepartureTime}/
                    GET               - 获取该条件下所有的车次信息
      业务逻辑（管理交通工具班次和车票信息）：
         交通工具管理界面
    api/
        Vehicle/
            schedule/
                POST                - 添加交通工具班次信息
                delete/{vehicleId}/
                    DELETE          - 删除交通工具班次信息
            ticket/
                POST                - 添加车票信息
                delete/{ticketId}/
                    DELETE          - 删除车票信息
      业务逻辑（车票购买）：
         交通工具查询界面
    api/
        Vehicle/
            ticket/
                purchase/{userId},{vehicleId},{type}/
                    POST            - 购买指定班次的指定种类的票
                refund/
                    one/{orderId},{passengerId}/
                        DELETE          - 退订单个乘客的车票
                    all/{orderId}/
                        DELETE          - 退订这一单所有的车票
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
            return Ok(_vehicleService._mapper.Map<VehicleScheduleResponse>(schedule));
        }

        [HttpGet("ticket/{ticketId}")]
        public async Task<IActionResult> GetVehicleTicketByTicketId(decimal ticketId)
        {
            var ticket = await _vehicleService.GetVehicleTicketAsync(ticketId);

            if (ticket == null)
                return NotFound("No vehicle ticket with id " + ticketId);
            return Ok(_vehicleService._mapper.Map<VehicleTicketResponse>(ticket));
        }

        [HttpGet("schedules")]
        public async Task<IActionResult> GetAllVehicleSchedules()
        {
            var list = await _vehicleService.GetAllVehicleSchedulesAsync();

            return Ok(list.Select(v => _vehicleService._mapper.Map<VehicleScheduleResponse>(v)));
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetAllVehicleTickets()
        {
            var list = await _vehicleService.GetAllVehicleTicketsAsync();

            return Ok(list.Select(v => _vehicleService._mapper.Map<VehicleTicketResponse>(v)));
        }

        [HttpGet("tickets/{vehicleId}")]
        public async Task<IActionResult> GetVehicleTicketsByVehicleId(string vehicleId)
        {
            var tickets = await _vehicleService.GetVehicleTicketsAsync(vehicleId);

            if (tickets == null || tickets.Count == 0)
                return NotFound("No vehicle ticket for " + vehicleId);
            return Ok(tickets.Select(t => _vehicleService._mapper.Map<VehicleTicketResponse>(t)).ToList());
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
            return CreatedAtAction(nameof(GetVehicleScheduleById), 
                                   new { vehicleId = target.VehicleId }, 
                                   _vehicleService._mapper.Map<VehicleScheduleResponse>(target));
        }

        [HttpPost("ticket")]
        public async Task<IActionResult> AddVehicleTicket([FromBody] VehicleTicketRequest vehicleTicket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var target = await _vehicleService.AddVehicleTicketAsync(vehicleTicket);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the vehicle ticket.");
            return CreatedAtAction(nameof(GetVehicleTicketByTicketId), 
                                   new { ticketId = target.TicketId },
                                   _vehicleService._mapper.Map<VehicleTicketResponse>(target));
        }

        [HttpDelete("schedule/delete/{vehicleId}")]
        public async Task<IActionResult> DelVehicleSchedule(string vehicleId)
        {
            var deleted = await _vehicleService.RemoveVehicleScheduleAsync(vehicleId);

            if (!deleted)
                return NotFound("No vehicle schedule to be deleted.");
            return NoContent();
        }

        [HttpDelete("ticket/delete/{ticketId}")]
        public async Task<IActionResult> DelVehicleTicket(decimal ticketId)
        {
            var deleted = await _vehicleService.RemoveVehicleTicketAsync(ticketId);

            if (!deleted)
                return NotFound("No vehicle ticket to be deleted.");
            return NoContent();
        }

        [HttpPost("ticket/purchase/{userId},{vehicleId},{type}")]
        public async Task<IActionResult> PurchaseTicket(int userId, string vehicleId, string type, [FromBody] List<VehiclePassengerRequest> passengers)
        {
            var tickets = await _vehicleService.GetVehicleTicketsAsync(vehicleId);
            VehicleTicket? ticket;

            if (tickets == null || tickets.Count == 0)
                return BadRequest("No vehicle ticket for " + vehicleId);

            try
            {
                ticket = tickets.SingleOrDefault(t => t.TicketType == type);
                if (ticket == null)
                    throw new Exception();
            }
            catch
            {
                return BadRequest("Unable to purchase the ticket. This type of ticket doesn't exist.");
            }

            if (ticket.TicketRemaining <= 0)
                return BadRequest("Unable to purchase the ticket. This type of ticket has been sold out.");
            ticket.TicketRemaining--;

            var orderDatum = await _vehicleService.AddOrderDatumAsync(userId, ticket.TicketPrice.Value * passengers.Count);

            if (orderDatum == null) 
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the order datum.");

            var vehicleOrder = new VehicleOrderRequest
            {
                OrderId = orderDatum.OrderId,
                TicketId = ticket.TicketId,
            };
            var orderTarget = await _vehicleService.AddVehicleOrderAsync(vehicleOrder);

            foreach (var passenger in passengers)
            {
                var passengerTarget = await _vehicleService.AddVehiclePassengerAsync(passenger, orderDatum.OrderId);
                if (passengerTarget == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the vehicle order.");
            }
            if (orderTarget == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the vehicle order.");
            return Ok("Ticket purchased successfully.");
        }

        [HttpDelete("ticket/refund/one/{orderId},{passengerId}")]
        public async Task<IActionResult> RefundTicketForOne(int orderId, string passengerId)
        {
            var deleted = await _vehicleService.RemoveVehiclePassengerAsync(orderId, passengerId);

            if (!deleted)
                return NotFound("No passenger to be deleted");
            return NoContent();
        }

        [HttpDelete("ticket/refund/all/{orderId}")]
        public async Task<IActionResult> RefundTicketForAll(int orderId)
        {
            var detailDeleted = await _vehicleService.RemoveVehicleOrderAsync(orderId);
            var datumDeleted = await _vehicleService.RemoveOrderDatumAsync(orderId);

            if (!datumDeleted || !detailDeleted)
                return NotFound("No order to be deleted.");
            return NoContent();
        }
    }
}
