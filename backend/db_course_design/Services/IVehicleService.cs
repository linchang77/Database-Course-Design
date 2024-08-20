using db_course_design.DTOs;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleResponse>> GetVehicleInfoAsync(string type, string arrivalCity, string departureCity, DateTime departureDate);
        Task<VehicleSchedule?> AddVehicleScheduleAsync(VehicleSchedule vehicleSchedule);
        Task<VehicleTicket?> AddVehicleTicketAsync(VehicleTicket vehicleTicket);
        Task<bool> RemoveVehicleScheduleAsync(string vehicleId);
        Task<bool> RemoveVehicleTicketAsync(decimal ticketId);
    }

}
