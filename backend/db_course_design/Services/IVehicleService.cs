using AutoMapper;
using db_course_design.DTOs;
using db_course_design.Profiles;
using db_course_design.Services.impl;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IVehicleService
    {
        IMapper _mapper { get; }
        Task<VehicleSchedule?> GetVehicleScheduleAsync(string vehicleId);
        Task<VehicleTicket?> GetVehicleTicketAsync(decimal ticketId);
        Task<List<VehicleTicket>> GetVehicleTicketsAsync(string vehicleId);
        Task<List<VehicleResponse>> GetVehicleInfoAsync(string type, string arrivalCity, string departureCity, DateTime departureDate);
        Task<VehicleSchedule?> AddVehicleScheduleAsync(VehicleScheduleRequest request);
        Task<VehicleTicket?> AddVehicleTicketAsync(VehicleTicketRequest request);
        Task<VehicleOrder?> AddVehicleOrderAsync(VehicleOrderRequest order);
        Task<bool> RemoveVehicleScheduleAsync(string vehicleId);
        Task<bool> RemoveVehicleTicketAsync(decimal ticketId);
        Task<bool> RemoveVehicleOrderAsync(int orderId, decimal ticketId, string ticketUserName);
        Task<OrderDatum?> AddOrderDatumAsync(int userId, decimal price);
    }

}
