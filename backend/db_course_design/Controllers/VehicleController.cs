using Microsoft.AspNetCore.Mvc;
using db_course_design.Services;
using db_course_design.Services.impl;


namespace db_course_design.Controllers
{
    /*业务逻辑：
         交通工具管理界面
         搜索：按照交通工具的类型（汽车，火车，飞机），出发地，到达地，出发时间进行车票的筛选
    api/
        Vehicle/
            {type},{ArrivalCity},{DepartureCity},{DepartureTime}/
                GET               - 获取该条件下所有的车次信息      
                /Modeltypr/{model}
    */
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleScheduleService;

        public VehicleController(IVehicleService vehicleScheduleService)
        {
            _vehicleScheduleService = vehicleScheduleService;
        }

        [HttpGet("{type},{arrivalCity},{departureCity},{departureTime}")]
        public async Task<IActionResult> GetVehicleSchedules(string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var schedules = await _vehicleScheduleService.GetVehicleSchedulesAsync(type, arrivalCity, departureCity, departureTime);
            if (schedules == null || schedules.Count == 0)
            {
                return NotFound("No vehicle schedules found for the given criteria.");
            }
            return Ok(schedules);
        }

        [HttpGet("{type},{arrivalCity},{departureCity},{departureTime}/ ModelType /{model}")]
        public async Task<IActionResult> GetVehicleSchedulesByModel(string model, string type, string arrivalCity, string departureCity, DateTime departureTime)
        {
            var schedules = await _vehicleScheduleService.SearchSchedulesByModelAsync(model,type, arrivalCity, departureCity, departureTime);
            if (schedules == null || schedules.Count == 0)
            {
                return NotFound("No vehicle schedules found for the given criteria.");
            }
            return Ok(schedules);
        }
    }
}
