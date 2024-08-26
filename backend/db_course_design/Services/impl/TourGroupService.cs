using db_course_design.DTOs;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.Common;
namespace db_course_design.Services.impl
{
    public class TourGroupService : ITourGroupService
    {
        private readonly ModelContext _context;
        public TourGroupService(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TourGroupResponse>> SearchTourGroupsByCityAsync(SearchTourGroupRequest request)
        {
            var query = _context.TourGroups
                .Include(tg => tg.Guide)
                .Include(tg => tg.TourItineraries)
                .Include(tg => tg.Hotels)
                .Where(tg => tg.Departure == request.Departure &&
                       tg.Destination == request.Destination &&
                       (request.Departure_Time == null || tg.StartDate >= request.Departure_Time) &&
                       (request.Days_of_Travel == 0 || tg.EndDate <= tg.StartDate.Value.AddDays(request.Days_of_Travel))
                             );

            var tourGroups = await query.ToListAsync();

            return tourGroups.Select(tg => new TourGroupResponse
            {
                GroupId = tg.GroupId,
                GroupName = tg.GroupName,
                GroupPrice = tg.GroupPrice,
                StartDate = tg.StartDate,
                EndDate = tg.EndDate,
                GuideName = tg.Guide?.GuideName,
                TourItineraries = tg.TourItineraries.Select(ti => new TourItinerary
                {
                    ItineraryId = ti.ItineraryId,
                    ItineraryTime = ti.ItineraryTime,
                    ItineraryDuration = ti.ItineraryDuration,
                    Activities = ti.Activities,
                    ScenicSpotId = ti.ScenicSpotId
                }).ToList(),
                Hotels = tg.Hotels.Select(h => new Hotel
                {
                    HotelId = h.HotelId,
                    HotelName = h.HotelName,
                    CityName = h.CityName,
                    HotelGrade = h.HotelGrade,
                    HotelLocation = h.HotelLocation,
                    HotelIntroduction = h.HotelIntroduction
                }).ToList()
            });
        }

        public async Task<IEnumerable<TourGroupResponse>> GetRecommendedTourGroupsAsync()
        {
            var recommendedGroups = await _context.TourGroups
                .Include(tg => tg.Guide)
                .Include(tg => tg.TourItineraries)
                .Include(tg => tg.Hotels)
                .OrderBy(tg => tg.GroupPrice) // 假设推荐规则是按最低价格排序
                .ToListAsync();

            return recommendedGroups.Select(tg => new TourGroupResponse
            {
                GroupId = tg.GroupId,
                GroupName = tg.GroupName,
                GroupPrice = tg.GroupPrice,
                StartDate = tg.StartDate,
                EndDate = tg.EndDate,
                GuideName = tg.Guide?.GuideName,
                TourItineraries = tg.TourItineraries.Select(ti => new TourItinerary
                {
                    ItineraryId = ti.ItineraryId,
                    ItineraryTime = ti.ItineraryTime,
                    ItineraryDuration = ti.ItineraryDuration,
                    Activities = ti.Activities,
                    ScenicSpotId = ti.ScenicSpotId
                }).ToList(),
                Hotels = tg.Hotels.Select(h => new Hotel
                {
                    HotelId = h.HotelId,
                    HotelName = h.HotelName,
                    CityName = h.CityName,
                    HotelGrade = h.HotelGrade,
                    HotelLocation = h.HotelLocation,
                    HotelIntroduction = h.HotelIntroduction
                }).ToList()
            });
        }
    }
}
