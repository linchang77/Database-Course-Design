using db_course_design.DTOs;

namespace db_course_design.Services
{
    public interface IGuideService
    {
        // 获取全部导游信息
        Task<List<GuideResponse>> GetAllGuideAsync();
        // 根据导游id、姓名筛选
        Task<List<GuideResponse>> GetGuideByPersonAsync(byte? GuideId, string? name);
        // 根据价格区间、级别筛选
        Task<List<GuideResponse>> GetGuideByAbilityAsync(decimal? minCost, decimal? maxCost, string? grade);
    }
}
