using Microsoft.AspNetCore.Mvc;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
using EntityFramework.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace db_course_design.Controllers
{
    /* 
     * 路由设计
     *api/Guide/
     *      all/
     *          Get         获取全部导游信息
     *      person/
     *          {GuideId},{name}/
     *              Get     根据导游id、姓名筛选
     *      ability/
     *          {minCost},{maxCost},{grade}/
     *              Get     根据价格区间、级别筛选
     *      reservation/
     *          Post    预约导游[GuideReservationResponse:GuideId,StartDate,EndDate]
     */
    [ApiController]
    [Route("api/[controller]")]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService;
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        /*--获取全部导游信息--*/
        [HttpGet("all")]
        public async Task<IActionResult> GetAllGuidesAsync()
        {
            var guides = await _guideService.GetAllGuideAsync();

            return Ok(guides);
        }
        /*--根据导游id、姓名筛选--*/
        [HttpGet("person/{GuideId},{name}")]
        public async Task<IActionResult> GetGuidesByPersonAsync(byte? GuideId, string? name)
        {
            var guides = await _guideService.GetGuideByPersonAsync(GuideId, name);
            if (guides == null || !guides.Any())
            {
                return NotFound(new { Message = "No guide found" });
            }
            return Ok(guides);
        }
        /*--根据价格区间、级别筛选--*/
        [HttpGet("ability/{minCost},{maxCost},{grade}")]
        public async Task<IActionResult> GetGuidesByAbilityAsync(decimal? minCost, decimal? maxCost, string? grade)
        {
            var guides = await _guideService.GetGuideByAbilityAsync(minCost, minCost, grade);
            if (guides == null || !guides.Any())
            {
                return NotFound(new { Message = "No guide found" });
            }
            return Ok(guides);
        }
    }
}
