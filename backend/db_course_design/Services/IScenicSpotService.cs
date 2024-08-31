using db_course_design.DTOs;
using db_course_design.Services.impl;
using db_course_design.Common;
using Microsoft.AspNetCore.Mvc;
/*--景点管理的服务抽象类，简化控制器逻辑--*/
namespace db_course_design.Services
{
    public interface IScenicSpotService
    {
        Task<IEnumerable<ScenicSpotResponse>> GetAllScenicSpotsAsync();
        Task<IEnumerable<ScenicSpotTicketResponse>> GetAllScenicSpotTicketsAsync();
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByCityAsync(string city);
        Task<ScenicSpotResponse?> GetScenicSpotByIdAsync(decimal scenicSpotId);
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByNameAsync(string scenicSpotName);
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByGradeAsync(string city, string grade);
        Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByDistance(string city, int mindis,int maxdis);
        Task<bool> DeleteScenicSpotAsync(decimal scenicSpotId);
        Task<ScenicSpotResponse?> AddScenicSpotAsync(ScenicSpotRequest request);
        Task<ScenicSpotResponse?> UpdateScenicSpotAsync(decimal scenicSpotId, ScenicSpotRequest request);
        Task<bool> DeleteScenicSpotTicketAsync(decimal scenicSpotId, string ticketType, DateTime ticketDate);
        Task<ScenicSpotTicketResponse?> AddScenicSpotTicketAsync(ScenicSpotTicketRequest request);
        Task<ScenicSpotTicketResponse?> UpdateScenicSpotTicketAsync(ScenicSpotTicketRequest request);
        Task<ScenicSpotTicketResponse?> GetScenicSpotTicketAsync(decimal scenicSpotId, string ticketType, DateTime ticketDate);
        Task<AdultChildTicketResponse?> GetTodayTicketInfoAsync(string scenicSpotName);
        Task<AdultChildTicketResponse?> GetTicketInfoByDateAsync(string scenicSpotName, DateTime date);
        Task<bool> PurchaseTicketAsync(string scenicSpotName, string type, DateTime date, CreateScenicSpotOrderRequest orderRequest, int number=1);
        Task<IEnumerable<ScenicSpotResponse>> GetRecommendedScenicSpotsAsync();
    }
}
