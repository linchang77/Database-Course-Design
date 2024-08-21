using db_course_design.DTOs;
using db_course_design.Services.impl;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IVehicleService
    {
        Task<VehicleScheduleResponse?> GetVehicleScheduleAsync(string vehicleId);
        Task<VehicleTicketResponse?> GetVehicleTicketAsync(decimal ticketId);
        Task<List<VehicleTicketResponse>> GetVehicleTicketsAsync(string vehicleId);
        Task<List<VehicleInfoResponse>> GetVehicleInfoAsync(string type, string arrivalCity, string departureCity, DateTime departureDate);
        Task<VehicleScheduleResponse?> AddVehicleScheduleAsync(VehicleScheduleRequest request);
        Task<VehicleTicketResponse?> AddVehicleTicketAsync(VehicleTicketRequest request);
        Task<bool> RemoveVehicleScheduleAsync(string vehicleId);
        Task<bool> RemoveVehicleTicketAsync(decimal ticketId);
    }

}
