using EntityFramework.Models;
using static db_course_design.Services.IVehicleService;
using db_course_design.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using db_course_design.Profiles;

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

        public decimal TicketId { get; set; }

        public decimal? TicketRemaining { get; set; }

        public string? TicketDepartureStation { get; set; }

        public string? TicketArrivalStation { get; set; }
    }

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
                       && i.DepartureTime.Date.Equals(departureTime.Date))
                .ToListAsync();

            return schedules;
        }

        public async Task<VehicleSchedule?> AddVehicleScheduleAsync(VehicleScheduleRequest request)
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

        public async Task<VehicleTicket?> AddVehicleTicketAsync(VehicleTicketRequest request)
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

        private VehicleResponse mapInfo(VehicleSchedule schedule, VehicleTicket ticket)
        {
            var info = _mapper.Map<VehicleResponse>(schedule);

            _mapper.Map(ticket, info);
            return info;
        }
    }
}
