using db_course_design.Returns;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace db_course_design.Services.impl
{
    public class ScenicSpotRequest
    {
        public string? ScenicSpotName { get; set; }

        public string? CityName { get; set; }

        public string? ScenicSpotGrade { get; set; }

        public string? ScenicSpotIntroduction { get; set; }

        public string? ScenicSpotLocation { get; set; }
    }

    public class ScenicSpotService : IScenicSpotService
    {
        private readonly ModelContext _context;

        public ScenicSpotService(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByCityAsync(string city)
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

        public async Task<ScenicSpotResponse> GetScenicSpotByIdAsync(decimal scenicSpotId)
        {
            var scenicSpot = await _context.ScenicSpots
                .FirstOrDefaultAsync(s => s.ScenicSpotId == scenicSpotId);

            if (scenicSpot == null)
            {
                return null;
            }
            else
                return new ScenicSpotResponse
                {
                    ScenicSpotId = scenicSpot.ScenicSpotId,
                    ScenicSpotName = scenicSpot.ScenicSpotName,
                    CityName = scenicSpot.CityName,
                    ScenicSpotGrade = scenicSpot.ScenicSpotGrade,
                    ScenicSpotIntroduction = scenicSpot.ScenicSpotIntroduction,
                    ScenicSpotLocation = scenicSpot.ScenicSpotLocation,
                    CityNameNavigation = scenicSpot.CityNameNavigation,
                    ScenicSpotTickets = scenicSpot.ScenicSpotTickets
                };
        }

        public async Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByNameAsync(string scenicSpotName)
        {
            var scenicSpots = await _context.ScenicSpots
                .Where(s => s.ScenicSpotName.Contains(scenicSpotName))
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

        public async Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByGradeAsync(string city, string grade)
        {
            var scenicSpots = await _context.ScenicSpots
                .Where(s => s.CityName == city && s.ScenicSpotGrade == grade)
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

        public async Task<bool> DeleteScenicSpotAsync(decimal scenicSpotId)
        {
            var scenicSpot = await _context.ScenicSpots
                .FirstOrDefaultAsync(s => s.ScenicSpotId == scenicSpotId);

            if (scenicSpot == null)
            {
                return false; // 未找到景点，删除失败
            }

            _context.ScenicSpots.Remove(scenicSpot);
            await _context.SaveChangesAsync();
            return true; // 删除成功
        }
        public async Task<ScenicSpotResponse> AddScenicSpotAsync(ScenicSpotRequest request)
        {
            // 将请求对象转换为数据库实体
            var scenicSpot = new ScenicSpot
            {
                ScenicSpotName = request.ScenicSpotName,
                CityName = request.CityName,
                ScenicSpotGrade = request.ScenicSpotGrade,
                ScenicSpotIntroduction = request.ScenicSpotIntroduction,
                ScenicSpotLocation = request.ScenicSpotLocation,
            };

            // 将实体添加到数据库上下文中
            _context.ScenicSpots.Add(scenicSpot);
            await _context.SaveChangesAsync();

            // 返回添加后的响应对象
            return new ScenicSpotResponse
            {
                ScenicSpotName = scenicSpot.ScenicSpotName,
                CityName = scenicSpot.CityName,
                ScenicSpotGrade = scenicSpot.ScenicSpotGrade,
                ScenicSpotIntroduction = scenicSpot.ScenicSpotIntroduction,
                ScenicSpotLocation = scenicSpot.ScenicSpotLocation
            };
        }

    }
}
