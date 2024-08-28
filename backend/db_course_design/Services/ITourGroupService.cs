using db_course_design.DTOs;
using db_course_design.Services.impl;
using db_course_design.Common;
using EntityFramework.Models;
using AutoMapper;
/*--旅行团管理的服务抽象类，简化控制器逻辑--*/
namespace db_course_design.Services
{
    public interface ITourGroupService
    {
        IMapper _mapper { get; }
        Task<IEnumerable<TourGroupResponse>> GetAllTourGroupsAsync();
        Task<IEnumerable<TourGroupResponse>> SearchTourGroupsByCityAsync(SearchTourGroupRequest request);
        //Task<IEnumerable<TourGroupResponse>> SearchTourGroupsByIdAsync(byte id);
        //Task<IEnumerable<TourGroupResponse>> SearchTourGroupsByNameAsync(SearchTourGroupRequest request);
        Task<IEnumerable<TourGroupResponse>> GetRecommendedTourGroupsAsync();
        Task<bool> PurchaseTourGroupOrderAsync(PurchaseTourOrderRequest request, int number = 1);
        //Task<TourGroupResponse> AddTourGroupAsync();
        //Task<bool> DeleteTourGroupAsync(byte id);
        //Task<TourGroupResponse> UpdateTourGroupAsync();
        //Task<IEnumerable<GuideResponse>> GetAllGuidesAsync();
    }
}


