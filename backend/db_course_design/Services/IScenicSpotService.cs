using db_course_design.Returns;
using db_course_design.Services.impl;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
