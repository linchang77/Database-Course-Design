using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;
using db_course_design.Profiles;
using db_course_design.Common;
using static db_course_design.Controler.AuthController;

namespace db_course_design.Services.impl
{
    public class GuideRequest
    {
        public string? GuideName { get; set; }

        public string? GuideGender { get; set; }

        public string? GuideIntroduction { get; set; }

        public decimal? GuideSalary { get; set; }

        public string? GuidePerformanceLevel { get; set; }

        public string? GuideSeniority { get; set; }

        public decimal? GuidePrice { get; set; }

        public string? ProfilePicture { get; set; }

        public bool? GuideFree { get; set; }

        public string? Password { get; set; }
    }

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

        public async Task<GuideResponse> GetGuideByIdAsync(byte GuideId)
        {
            var guide = await _context.Guides.FindAsync(GuideId);

            if (guide == null)
            {
                return null;
            }

            return _mapper.Map<GuideResponse>(guide);
        }

        /*--预约导游--*
        public async Task<bool> GuideReservationAsync(GuideReservationResponse response)
        {
            var Id = response.GuideId
        }*/

        /*--添加导游信息--*/
        public async Task<GuideResponse> AddGuideAsync(GuideRequest guideRequest)
        {
            guideRequest.Password= SaltedPassword.HashPassword(guideRequest.Password, SaltedPassword.salt);
            var guide = _mapper.Map<Guide>(guideRequest);

            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();

            return _mapper.Map<GuideResponse>(guide);
        }


        /*--修改导游信息--*/
        public async Task<GuideResponse> UpdateGuideAsync(byte GuideId, GuideRequest guideRequest)
        {
            guideRequest.Password = SaltedPassword.HashPassword(guideRequest.Password, SaltedPassword.salt);
            var guide = await _context.Guides.FindAsync(GuideId);

            if (guide == null)
            {
                return null;
            }

            _mapper.Map(guideRequest, guide);

            _context.Guides.Update(guide);
            await _context.SaveChangesAsync();

            return _mapper.Map<GuideResponse>(guide);
        }



        /*--删除导游信息--*/
        public async Task<bool> DeleteGuideAsync(byte GuideId)
        {
            var guide = await _context.Guides.FindAsync(GuideId);

            if (guide == null)
            {
                return false;
            }

            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
