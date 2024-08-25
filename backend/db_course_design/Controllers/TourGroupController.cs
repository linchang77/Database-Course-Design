using db_course_design.Common;
using db_course_design.DTOs;
using db_course_design.Services;
using Microsoft.AspNetCore.Mvc;

namespace db_course_design.Controllers
{
    /*业务逻辑(旅行团的搜索):
        点击筛选之后显示出符合筛选条件的旅行团产品
    筛选条件有
    public class SearchTourGroupRequest
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime? Departure_Time { get; set; }
        public int Days_of_Travel { get; set; }
    }
    出发地和目的地必填，出发时间和行程天数没有的话默认填0
      [HttpGet("search")]                   -获取筛选条件的旅行团产品  
      [HttpGet("recommendedtours")]         -获取推荐的旅行团

     */
    [Route("api/[controller]")]
    [ApiController]
    public class TourGroupController : ControllerBase
    {
        private readonly ITourGroupService _tourGroupService;

        public TourGroupController(ITourGroupService tourGroupService)
        {
            _tourGroupService = tourGroupService;
        }

        /// <summary>
        /// 获取符合筛选条件的旅行团产品
        /// </summary>
        /// <param name="request">筛选条件</param>
        /// <returns>符合条件的旅行团列表</returns>
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TourGroupResponse>>> SearchTourGroups([FromQuery] SearchTourGroupRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Departure) || string.IsNullOrWhiteSpace(request.Destination))
            {
                return BadRequest("出发地和目的地是必填项。");
            }

            var tourGroups = await _tourGroupService.SearchTourGroupsByCityAsync(request);
            return Ok(tourGroups);
        }

        /// <summary>
        /// 获取推荐的旅行团
        /// </summary>
        /// <returns>推荐的旅行团列表</returns>
        [HttpGet("recommendedtours")]
        public async Task<ActionResult<IEnumerable<TourGroupResponse>>> GetRecommendedTourGroups()
        {
            var recommendedGroups = await _tourGroupService.GetRecommendedTourGroupsAsync();
            return Ok(recommendedGroups);
        }
    }
}