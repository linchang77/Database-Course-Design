using db_course_design.DTOs;
using db_course_design.Services.impl;
using EntityFramework.Models;

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
        // 获取某个导游可预约时间
        Task<List<GuideTimeRange>> GetGuideFreeTimesAsync(byte guideId);
        // 创建一个导游订单
        Task<bool> CreateGuideOrderAsync(GuideReservationRequest request);
        
        // 按条件筛选
        Task<List<OrderResponseOfGuide>> OrderFilterofGuide(byte GuideId, string? OrderType, int? UserId, DateTime? StartDate, DateTime? EndDate);
        Task<List<GuideOrderDetailOfGuide>> GuideOrderFilter(byte GuideId, int? UserId, DateTime? StartDate, DateTime? EndDate);
        Task<GuideResponse> GetGuideByIdAsync(byte GuideId);
        Task<GuideResponse> AddGuideAsync(GuideRequest guideRequest);
        Task<bool> AddGuidePictureAsync(byte GuideId, string? Url);
        Task<GuideResponse> UpdateGuideAsync(byte GuideId, GuideRequest guideRequest);
        Task<bool> DeleteGuideAsync(byte GuideId);
    }
}
