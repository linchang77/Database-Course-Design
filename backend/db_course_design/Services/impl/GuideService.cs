using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;
using db_course_design.Profiles;
using db_course_design.Common;

namespace db_course_design.Services.impl
{
    public class GuideService : IGuideService
    {
        private readonly ModelContext _context;

        public IMapper _mapper { get; }

        public GuideService(ModelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<GuideProfile>()).CreateMapper();
        }
        /*--获取全部导游信息--*/
        public async Task<List<GuideResponse>> GetAllGuideAsync()
        {
            return await _context.Guides.Select(p => _mapper.Map<GuideResponse>(p)).ToListAsync();
        }
        /*--根据导游id、姓名筛选--*/
        public async Task<List<GuideResponse>> GetGuideByPersonAsync(byte? GuideId, string? name)
        {
            var query = _context.Guides.AsQueryable();
            query = query.Where(o => o.GuideId == GuideId && o.GuideName.Equals(name));

            var guides = await query
                .Select(o => _mapper.Map<GuideResponse>(o)).ToListAsync();
            return guides;
        }
        /*--根据价格区间、级别筛选--*/
        public async Task<List<GuideResponse>> GetGuideByAbilityAsync(decimal? minCost,decimal? maxCost,string? grade)
        {
            var query = _context.Guides.AsQueryable();
            query = query.Where(o => o.GuidePerformanceLevel.Equals(grade)
                && o.GuidePrice >= minCost
                && o.GuidePrice <= maxCost);

            var guides = await query
                .Select(o => _mapper.Map<GuideResponse>(o)).ToListAsync();
            return guides;
        }
        /*--预约导游--*
        public async Task<bool> GuideReservationAsync(GuideReservationResponse response)
        {
            var Id = response.GuideId
        }*/
    }
}
