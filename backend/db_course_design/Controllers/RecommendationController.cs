using Microsoft.AspNetCore.Mvc;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;
namespace db_course_design.Controllers
{
    /*
      /*业务逻辑(推荐旅行团，景点)
    返回推荐的旅行团和景点，目前固定景点为上海迪士尼，外滩，豫园
     [HttpGet("tourgroup")]              -获取推荐的旅行团
     [HttpGet("scenicspot")]             -获取推荐的景点
     */
    public class RecommendationController: ControllerBase
    {
        private readonly ITourGroupService _tourGroupService;
        private readonly IScenicSpotService _scenicSpotService;

        public RecommendationController(ITourGroupService tourGroupService,IScenicSpotService scenicSpotService)
        {
            _tourGroupService = tourGroupService;
            _scenicSpotService = scenicSpotService;
        }

        [HttpGet("scenicspots")]
        public async Task<ActionResult<IEnumerable<ScenicSpotResponse>>> GetRecommendedScenicSpots()
        {
            var recommendedSpots = await _scenicSpotService.GetRecommendedScenicSpotsAsync();
            return Ok(recommendedSpots);
        }
    }
   
}
