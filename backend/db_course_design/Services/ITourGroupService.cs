using db_course_design.DTOs;
using db_course_design.Services.impl;
using db_course_design.Common;
/*--旅行团管理的服务抽象类，简化控制器逻辑--*/
namespace db_course_design.Services
{
    public interface ITourGroupService
    {
        Task<IEnumerable<ScenicSpotResponse>> GetTourGroupByCityAsync(string city);
    }
}
