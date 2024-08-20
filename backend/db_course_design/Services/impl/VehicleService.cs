using EntityFramework.Models;
using static db_course_design.Services.IVehicleService;
using db_course_design.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using db_course_design.Profiles;

namespace db_course_design.Services.impl
{
    public class VehicleService : IVehicleService
    {
        private readonly ModelContext _context;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;

        public VehicleService(ModelContext context)
        {
            _context = context;
            _config = new MapperConfiguration(cfg => cfg.AddProfile<VehicleProfile>());
            _mapper = _config.CreateMapper();
        }

        public async Task<List<VehicleResponse>> GetVehicleInfoAsync(string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var schedules = await _context.VehicleSchedules
                .Where(v => v.VehicleType == type)
                .Join(_context.VehicleTickets, s => s.VehicleId, t => t.VehicleId, (s, t) => mapInfo(s, t))
                .Where(i => i.ArrivalCity == arrivalCity
                       && i.DepartureCity == departureCity
                       && i.DepartureTime.GetValueOrDefault().Date.Equals(departureTime.Date))
                .ToListAsync();

            return schedules;
        }

        public async Task<List<VehicleOrderDetail>> GetVehicleOrdersAsync(int userId)
        {
            var orders = await _context.VehicleOrders
                .Include(v => v.Order)
                .Include(v => v.Ticket)
                .ThenInclude(t => t.Vehicle)
                .Where(v => v.Order.UserId == userId)
                .Select(v => mapOrder(v))
                .ToListAsync();

            return orders;
        }

        public async Task<VehicleSchedule?> AddVehicleScheduleAsync(VehicleSchedule vehicleSchedule)
        {
            try
            {
                _context.VehicleSchedules.Add(vehicleSchedule);
                await _context.SaveChangesAsync();
                return vehicleSchedule;
            }
            catch
            {
                return null;
            }
        }

        public async Task<VehicleTicket?> AddVehicleTicketAsync(VehicleTicket vehicleTicket)
        {
            try
            {
                _context.VehicleTickets.Add(vehicleTicket);
                await _context.SaveChangesAsync();
                return vehicleTicket;
            }
            catch
            {
                return null;
            }
        }

        public async Task<VehicleOrder?> AddVehicleOrderAsync(VehicleOrder vehicleOrder)
        {
            try
            {
                _context.VehicleOrders.Add(vehicleOrder);
                await _context.SaveChangesAsync();
                return vehicleOrder;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveVehicleScheduleAsync(string vehicleId)
        {
            var target = await _context.VehicleSchedules.SingleOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (target == null)
                return false;

            _context.VehicleSchedules.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveVehicleTicketAsync(decimal ticketId)
        {
            var target = await _context.VehicleTickets.SingleOrDefaultAsync(v => v.TicketId == ticketId);

            if (target == null)
                return false;

            _context.VehicleTickets.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveVehicleOrderAsync(int orderId, decimal ticketId, string ticketUserName)
        {
            var target = await _context.VehicleOrders.SingleOrDefaultAsync(v => v.OrderId == orderId
                                                                           && v.TicketId == ticketId
                                                                           && v.TicketUserName == ticketUserName);

            if (target == null)
                return false;

            _context.VehicleOrders.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        private VehicleResponse mapInfo(VehicleSchedule schedule, VehicleTicket ticket)
        {
            var info = _mapper.Map<VehicleResponse>(schedule);

            _mapper.Map(ticket, info);
            return info;
        }

        private VehicleOrderDetail mapOrder(VehicleOrder order)
        {
            var ticket = order.Ticket;
            var schedule = ticket.Vehicle;
            var detail = _mapper.Map<VehicleOrderDetail>(order);

            _mapper.Map(ticket, detail);
            _mapper.Map(schedule, detail);
            return detail;
        }
    }
}
