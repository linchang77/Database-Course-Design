﻿using EntityFramework.Models;
using static db_course_design.Services.IVehicleService;
using db_course_design.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using db_course_design.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace db_course_design.Services.impl
{
    public class VehicleScheduleRequest
    {
        public string? ArrivalCity { get; set; }

        public string VehicleId { get; set; } = null!;

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public string? VehicleType { get; set; }

        public string? DepartureCity { get; set; }

        public string? VehicleModel { get; set; }

        public string? ArrivalStation { get; set; }

        public string? DepartureStation { get; set; }
    }

    public class VehicleTicketRequest
    {
        public string? VehicleId { get; set; }

        public string? TicketType { get; set; }

        public decimal? TicketPrice { get; set; }

        public DateTime? TicketDepartureTime { get; set; }

        public DateTime? TicketArrivalTime { get; set; }

        public string? TicketDepartureCity { get; set; }

        public string? TicketArrivalCity { get; set; }

        public decimal? TicketRemaining { get; set; }

        public string? TicketDepartureStation { get; set; }

        public string? TicketArrivalStation { get; set; }
    }

    public class VehicleOrderRequest
    {
        public int OrderId { get; set; }

        public decimal TicketId { get; set; }

        public string TicketUserName { get; set; } = null!;
    }

    public class VehicleService : IVehicleService
    {
        private readonly ModelContext _context;
        private readonly MapperConfiguration _config;

        public IMapper _mapper { get; }

        public VehicleService(ModelContext context)
        {
            _context = context;
            _config = new MapperConfiguration(cfg => cfg.AddProfile<VehicleProfile>());
            _mapper = _config.CreateMapper();
        }

        public async Task<VehicleSchedule?> GetVehicleScheduleAsync(string vehicleId)
        {
            var schedule = await _context.VehicleSchedules.FindAsync(vehicleId);

            if (schedule == null)
                return null;
            return schedule;
        }

        public async Task<VehicleTicket?> GetVehicleTicketAsync(decimal ticketId)
        {
            var ticket = await _context.VehicleTickets.FindAsync(ticketId);

            if (ticket == null) 
                return null;
            return ticket;
        }

        public async Task<List<VehicleTicket>> GetVehicleTicketsAsync(string vehicleId)
        {
            var schedule =  await _context.VehicleSchedules
                .Where(v => v.VehicleId == vehicleId)
                .Include(v => v.VehicleTickets)
                .FirstOrDefaultAsync();

            if (schedule == null)
                return new List<VehicleTicket>();
            return schedule.VehicleTickets.ToList();
        }

        public async Task<List<VehicleResponse>> GetVehicleInfoAsync(string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var unmapped = await _context.VehicleSchedules
                .Where(v => v.VehicleType == type)
                .Join(_context.VehicleTickets, s => s.VehicleId, t => t.VehicleId, (s, t) => new
                {
                    Schedule = s,
                    Ticket = t
                })
                .Where(i => i.Ticket.TicketArrivalCity == arrivalCity
                       && i.Ticket.TicketDepartureCity == departureCity
                       && i.Ticket.TicketDepartureTime.Value.Date.Equals(departureTime.Date))
                .ToListAsync();
            var schedules = unmapped
                .Select(i => mapInfo(i.Schedule, i.Ticket))
                .ToList();

            return schedules;
        }

        public async Task<VehicleSchedule?> AddVehicleScheduleAsync([FromBody] VehicleScheduleRequest request)
        {
            try
            {
                var schedule = _mapper.Map<VehicleSchedule>(request);
                _context.VehicleSchedules.Add(schedule);
                await _context.SaveChangesAsync();
                return schedule;
            }
            catch
            {
                return null;
            }
        }

        public async Task<VehicleTicket?> AddVehicleTicketAsync([FromBody] VehicleTicketRequest request)
        {
            try
            {
                var ticket = _mapper.Map<VehicleTicket>(request);
                _context.VehicleTickets.Add(ticket);
                await _context.SaveChangesAsync();
                return ticket;
            }
            catch
            {
                return null;
            }
        }

        public async Task<VehicleOrder?> AddVehicleOrderAsync(VehicleOrderRequest request)
        {
            try
            {
                var order = _mapper.Map<VehicleOrder>(request);
                _context.VehicleOrders.Add(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveVehicleScheduleAsync(string vehicleId)
        {
            var target = await _context.VehicleSchedules.FindAsync(vehicleId);

            if (target == null)
                return false;

            _context.VehicleSchedules.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveVehicleTicketAsync(decimal ticketId)
        {
            var target = await _context.VehicleTickets.FindAsync(ticketId);

            if (target == null)
                return false;

            _context.VehicleTickets.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveVehicleOrderAsync(int orderId, decimal ticketId, string ticketUserName)
        {
            var target = await _context.VehicleOrders.FindAsync(orderId, ticketId, ticketUserName);

            if (target == null)
                return false;

            _context.VehicleOrders.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OrderDatum?> AddOrderDatumAsync(int userId, decimal price)
        {
            IOrderService orderService = new OrderService(_context);
            var order = new OrderDatum
            {
                OrderType = "vehicle",
                OrderDate = DateTime.Now,
                UserId = userId,
                Status = "Pending",
                Price = price
            };

            return await orderService.CreateOrderAsync(order);
        }

        private VehicleResponse mapInfo(VehicleSchedule schedule, VehicleTicket ticket)
        {
            var info = _mapper.Map<VehicleResponse>(schedule);

            _mapper.Map(ticket, info);
            return info;
        }
    }
}
