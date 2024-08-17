using db_course_design.Returns;
using EntityFramework.Models;

namespace db_course_design.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleScheduleResponse>> GetVehicleSchedulesAsync(string type, string arrivalCity, string departureCity, DateTime departureTime);
        Task<List<VehicleScheduleResponse>> SearchSchedulesByModelAsync(string model, string type, string arrivalCity, string departureCity, DateTime departureTime);
    }

}
