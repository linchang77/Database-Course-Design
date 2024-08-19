using EntityFramework.Models;
using static db_course_design.Services.IVehicleService;
using db_course_design.Returns;
using Microsoft.EntityFrameworkCore;


namespace db_course_design.Services.impl
{
    public class VehicleService : IVehicleService
    {
        private readonly ModelContext _context;

        public VehicleService(ModelContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleScheduleResponse>> GetVehicleSchedulesAsync(string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var schedules = await _context.VehicleSchedules
                .Where(v => v.VehicleType == type
                            && v.ArrivalCity == arrivalCity
                            && v.DepartureCity == departureCity
                            && v.DepartureTime.Value.Date == departureTime.Date)
                .Select(v => new VehicleScheduleResponse
                {
                    VehicleId = v.VehicleId,
                    VehicleType = v.VehicleType,
                    DepartureCity = v.DepartureCity,
                    ArrivalCity = v.ArrivalCity,
                    DepartureTime = v.DepartureTime,
                    ArrivalTime = v.ArrivalTime,
                    DepartureStation = v.DepartureStation,
                    ArrivalStation = v.ArrivalStation
                })
                .ToListAsync();

            return schedules;
        }

        public async Task<List<VehicleScheduleResponse>> SearchSchedulesByModelAsync(string model,string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var schedules = await _context.VehicleSchedules
                .Where(v => v.VehicleType == type
                            && v.ArrivalCity == arrivalCity
                            && v.DepartureCity == departureCity
                            && v.DepartureTime.Value.Date == departureTime.Date
                            && v.VehicleModel==model)
                .Select(v => new VehicleScheduleResponse
                {
                    VehicleId = v.VehicleId,
                    VehicleType = v.VehicleType,
                    DepartureCity = v.DepartureCity,
                    ArrivalCity = v.ArrivalCity,
                    DepartureTime = v.DepartureTime,
                    ArrivalTime = v.ArrivalTime,
                    DepartureStation = v.DepartureStation,
                    ArrivalStation = v.ArrivalStation
                })
                .ToListAsync();

            return schedules;
        }
    }
}
