using Microsoft.AspNetCore.Mvc;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
using EntityFramework.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace db_course_design.Controllers
{
    /* 用户界面
     * 路由设计
     *api/Guide/
     *      all/
     *          Get         获取全部导游信息
     *      person/?{GuideId}&{name}
     *          Get         根据导游id或姓名筛选
     *      ability/?{minCost}&{maxCost}&{grade}
     *              Get     根据价格区间、级别筛选
     *      reservation/
     *          {GuideId}/
     *              Get         获取某个导游可预约时间
     *          create/
     *              Post        创建一个导游订单
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
        [HttpGet("person")]
        public async Task<IActionResult> GetGuidesByPersonAsync([FromQuery] byte? GuideId, [FromQuery] string? name)
        {
            var guides = await _guideService.GetGuideByPersonAsync(GuideId, name);
            if (guides == null || !guides.Any())
            {
                return NotFound(new { Message = "No guide found" });
            }
            return Ok(guides);
        }
        /*--根据价格区间、级别筛选--*/
        [HttpGet("ability")]
        public async Task<IActionResult> GetGuidesByAbilityAsync([FromQuery] decimal? minCost, [FromQuery] decimal? maxCost, [FromQuery] string? grade)
        {
            var guides = await _guideService.GetGuideByAbilityAsync(minCost, maxCost, grade);
            if (guides == null || !guides.Any())
            {
                return NotFound(new { Message = "No guide found" });
            }
            return Ok(guides);
        }
        /*--根据Id搜索--*/
        [HttpGet("{GuideId}")]
        public async Task<IActionResult> GetGuideByIdAsync(byte GuideId)
        {
            var guide = await _guideService.GetGuideByIdAsync(GuideId);
            if (guide == null)
            {
                return NotFound(new { Message = "Guide not found" });
            }
            return Ok(guide);
        }
        /*--获取某个导游可预约时间--*/
        [HttpGet("reservation/{GuideId}")]
        public async Task<IActionResult> GetGuideFreeTime(byte GuideId)
        {
            var free = await _guideService.GetGuideFreeTimesAsync(GuideId);
            if(free == null)
            {
                return NotFound(new { Message = "No Free Time this year" });
            }
            return Ok(free);
        }
        /*--创建一个导游订单--*/
        [HttpPost("reservation/create")]
        public async Task<IActionResult> CreateGuideOrderAsync(GuideReservationRequest request)
        {
            var flag = await _guideService.CreateGuideOrderAsync(request);
            if(!flag)
                return BadRequest(new { Message = "create failed"});
            return Ok();
        }
        /*导游界面补充
         * api/Guide/
         *    {GuideId}/
         *        filter/？{OrderType}&{UserId}&{StartDate}&{EndDate}
         *            Get         按条件筛选
         */
        [HttpGet("{GuideId}/filter")]
        public async Task<IActionResult> GetGuideOrderByFilterAsync
            (byte GuideId, [FromQuery] string? OrderType, [FromQuery] int? UserId, [FromQuery] DateTime? StartDate, [FromQuery] DateTime? EndDate)
        {
            var orders = await _guideService.OrderFilterofGuide(GuideId, OrderType, UserId, StartDate, EndDate);
            if (orders == null)
                return NotFound(new { Message = "未筛选到此类订单" });
            return Ok(orders);
        }
        /*
         业务逻辑：导游信息的增删改
        管理员界面
         */
        /*--添加导游信息--*/
        [HttpPost("add")]
        public async Task<IActionResult> AddGuideAsync([FromBody] GuideRequest guideRequest)
        {
            var addedGuide = await _guideService.AddGuideAsync(guideRequest);
            if (addedGuide == null)
            {
                return BadRequest(new { Message = "Failed to add guide" });
            }

            // 返回添加的导游信息
            return Ok(addedGuide);
        }

        /*--上传导游图片--*/
        [HttpPost("add/picture")]
        public async Task<IActionResult> AddGuidePictureAsync([FromBody] GuidePictureRequest request)
        {
            if (await _guideService.AddGuidePictureAsync(request.GuideId, request.Url))
                return Ok();
            return BadRequest(new { Message = "Failed to add picture" });
        }

        /*--修改导游信息--*/
        [HttpPut("update/{GuideId}")]
        public async Task<IActionResult> UpdateGuideAsync(byte GuideId, [FromBody] GuideRequest guideRequest)
        {
            var updatedGuide = await _guideService.UpdateGuideAsync(GuideId, guideRequest);
            if (updatedGuide == null)
            {
                return NotFound(new { Message = "Guide not found" });
            }
            return Ok(updatedGuide);
        }

        /*--删除导游信息--*/
        [HttpDelete("del/{GuideId}")]
        public async Task<IActionResult> DeleteGuideAsync(byte GuideId)
        {
            var result = await _guideService.DeleteGuideAsync(GuideId);
            if (!result)
            {
                return NotFound(new { Message = "Guide not found" });
            }
            return NoContent();
        }
    }
}
