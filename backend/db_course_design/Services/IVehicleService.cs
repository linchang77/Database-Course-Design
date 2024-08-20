using db_course_design.DTOs;
using db_course_design.Services.impl;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleResponse>> GetVehicleInfoAsync(string type, string arrivalCity, string departureCity, DateTime departureDate);
        Task<VehicleSchedule?> AddVehicleScheduleAsync(VehicleScheduleRequest request);
        Task<VehicleTicket?> AddVehicleTicketAsync(VehicleTicketRequest request);
        Task<bool> RemoveVehicleScheduleAsync(string vehicleId);
        Task<bool> RemoveVehicleTicketAsync(decimal ticketId);
    }

}
