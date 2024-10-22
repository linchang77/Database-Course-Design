﻿using db_course_design.DTOs;
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
        Task<TourGroupResponse?> SearchTourGroupsByIdAsync(byte id);
        Task<IEnumerable<TourGroupResponse>> SearchTourGroupsByNameAsync(string name);
        Task<IEnumerable<TourGroupResponse>> GetRecommendedTourGroupsAsync();
        Task<bool> PurchaseTourGroupOrderAsync(PurchaseTourOrderRequest request, int number = 1);
        Task<TourGroupResponse?> AddTourGroupAsync(TourGroupRequest request);
        Task<bool> DeleteTourGroupAsync(byte id);
        Task<TourGroupResponse?> UpdateTourGroupAsync(byte id, TourGroupRequest request);
        Task<IEnumerable<TourItineraryResponse>> GetAllTourItinerarysAsync(byte groupId);
        Task<TourItineraryResponse?> GetTourItineraryByIdAsync(decimal itineraryId);
        Task<TourItineraryResponse?> AddTourItineraryAsync(TourItineraryRequest request);
        Task<bool> DeleteTourItineraryAsync(decimal id);
        Task<TourItineraryResponse?> UpdateTourItineraryAsync(decimal id, TourItineraryRequest request);
        Task<IEnumerable<HotelResponse>> GetAllTourHotelsAsync(byte groupId);
        Task<HotelResponse?> AddTourHotelAsync(byte groupId, decimal hotelId);
        Task<bool> DeleteTourHotelAsync(byte groupId, decimal hotelId);
        Task<HotelResponse?> UpdateTourHotelAsync(byte groupId, decimal oldHotelId, decimal newHotelId);
        Task<IEnumerable<GuideResponse>> GetAllGuidesAsync();
    }
}


