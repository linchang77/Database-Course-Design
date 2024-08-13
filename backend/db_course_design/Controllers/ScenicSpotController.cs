using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;


namespace db_course_design.Controllers
{
    /*业务逻辑：
         景点管理界面
         可以看到所有景点，
         搜索：按城市搜索唯一对应的订单
               按景点ID搜索
               按景点名字搜索
         删除：通过删除按钮删除某个订单
         筛选：1.距离市中心距离
               2.景点的星级
    api/
        ScenicSpot/
            {city}/
                GET               - 获取该城市所有的景点
                id/
                {ScenicSpotId}/
                        GET       - 按景点ID搜索
                name/
                {ScenicSpotName}
                        GET       - 按景点名字搜索
                grade/
                    {grade}/
                        GET       - 按景点的星级筛选
                distance/
                    {distanch}/
                         GET      - 按距离市中心距离筛选
    */
    [ApiController]
    [Route("api/[controller]")]
    public class ScenicSpotController : ControllerBase
    {
        private readonly IScenicSpotService _scenicSpotService;

        public ScenicSpotController(IScenicSpotService scenicSpotService)
        {
            _scenicSpotService = scenicSpotService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetScenicSpotsByCity(string city)
        {
            var scenicSpots = await _scenicSpotService.GetScenicSpotsByCityAsync(city);
            if (scenicSpots == null || !scenicSpots.Any())
            {
                return NotFound();
            }
            return Ok(scenicSpots);
        }

        [HttpGet("id/{scenicSpotId}")]
        public async Task<IActionResult> GetScenicSpotById(decimal scenicSpotId)
        {
            var scenicSpot = await _scenicSpotService.GetScenicSpotByIdAsync(scenicSpotId);
            if (scenicSpot == null)
            {
                return NotFound();
            }
            return Ok(scenicSpot);
        }

        [HttpGet("name/{scenicSpotName}")]
        public async Task<IActionResult> GetScenicSpotByName(string scenicSpotName)
        {
            var scenicSpots = await _scenicSpotService.GetScenicSpotsByNameAsync(scenicSpotName);
            if (scenicSpots == null || !scenicSpots.Any())
            {
                return NotFound();
            }
            return Ok(scenicSpots);
        }

        [HttpGet("{city}/grade/{grade}")]
        public async Task<IActionResult> GetScenicSpotsByGrade(string city, string grade)
        {
            var scenicSpots = await _scenicSpotService.GetScenicSpotsByGradeAsync(city, grade);
            if (scenicSpots == null || !scenicSpots.Any())
            {
                return NotFound();
            }
            return Ok(scenicSpots);
        }

        [HttpDelete("{scenicSpotId}")]
        public async Task<IActionResult> DeleteScenicSpot(decimal scenicSpotId)
        {
            var deleted = await _scenicSpotService.DeleteScenicSpotAsync(scenicSpotId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddScenicSpot([FromBody] ScenicSpotRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedScenicSpot = await _scenicSpotService.AddScenicSpotAsync(request);

            if (addedScenicSpot == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the scenic spot.");
            }

            // 返回 201 Created 状态码，并包含新创建的景点的详细信息
            return CreatedAtAction(nameof(GetScenicSpotById), new { scenicSpotId = addedScenicSpot.ScenicSpotId }, addedScenicSpot);
        }

    }
}
