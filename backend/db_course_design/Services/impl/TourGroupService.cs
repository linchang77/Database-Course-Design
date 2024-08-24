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

        public async Task<IEnumerable<ScenicSpotResponse>> GetTourGroupByCityAsync(string city)
        {
            var scenicSpots = await _context.ScenicSpots
                .Where(s => s.CityName == city)
                .Select(s => new ScenicSpotResponse
                {
                    ScenicSpotId = s.ScenicSpotId,
                    ScenicSpotName = s.ScenicSpotName,
                    CityName = s.CityName,
                    ScenicSpotGrade = s.ScenicSpotGrade,
                    ScenicSpotIntroduction = s.ScenicSpotIntroduction,
                    ScenicSpotLocation = s.ScenicSpotLocation,
                    CityNameNavigation = s.CityNameNavigation,
                    ScenicSpotTickets = s.ScenicSpotTickets
                })
                .ToListAsync();

            return scenicSpots.Any() ? scenicSpots : null;
        }

    }
}
