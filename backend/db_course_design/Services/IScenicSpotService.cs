using db_course_design.DTOs;
using db_course_design.Services.impl;
using db_course_design.Common;
/*--景点管理的服务抽象类，简化控制器逻辑--*/
namespace db_course_design.Services
{
    public interface IScenicSpotService
    {
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByCityAsync(string city);
        Task<ScenicSpotResponse> GetScenicSpotByIdAsync(decimal scenicSpotId);
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByNameAsync(string scenicSpotName);
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByGradeAsync(string city, string grade);
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByDistance(string city, int mindis,int maxdis);
        Task<bool> DeleteScenicSpotAsync(decimal scenicSpotId);
        Task<ScenicSpotResponse> AddScenicSpotAsync(ScenicSpotRequest request);
        Task<AdultChildTicketResponse> GetTodayTicketInfoAsync(string scenicSpotName);
        Task<AdultChildTicketResponse> GetTicketInfoByDateAsync(string scenicSpotName, DateTime date);
        Task<bool> PurchaseTicketAsync(string scenicSpotName, string type, DateTime date, CreateScenicSpotOrderRequest orderRequest);
    }
}
