using db_course_design.Services;
using db_course_design.Services.impl;
using Microsoft.AspNetCore.Mvc;

namespace db_course_design.Controllers
{
    /*
     * 业务逻辑：在管理员界面，实现对城市条目的增删查，和对城市介绍和天气信息的更新
     * api/City/
     *      GET         - 获取所有城市
     *      {name}/
     *      GET         - 根据城市名获取城市详细信息
     *      add/
     *      POST        - 添加城市
     *      del/{name}/
     *      DELETE      - 删除城市
     *      mod/
     *          intro/{name},{intro}/
     *          PATCH   - 更改城市介绍
     *          climate/{name},{t1},{w1},{t2},{w2}
     *          PATCH   - 更改城市天气信息
     */
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await _cityService.GetAllCitiesAsync());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCityByName(string name)
        {
            var city = await _cityService.GetCityByNameAsync(name);

            if (city == null)
                return NotFound("City " + name + " wasn't found.");
            return Ok(city);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity([FromBody] CityRequest request)
        {
            var target = await _cityService.AddCityAsync(request);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the city.");
            return CreatedAtAction(nameof(GetCityByName), new { name = target.CityName }, target);
        }

        [HttpDelete("del/{name}")]
        public async Task<IActionResult> DeleteCity(string name)
        {
            var deleted = await _cityService.DeleteCityAsync(name);

            if (!deleted)
                return NotFound("City " + name + " wasn't found.");
            return NoContent();
        }

        [HttpPatch("mod/intro/{name},{intro}")]
        public async Task<IActionResult> UpdateCityIntro(string name, string intro)
        {
            var target = await _cityService.UpdateCityIntroAsync(name, intro);

            if (target == null)
                return NotFound("City " + name + " wasn't found.");
            return Ok(target);
        }

        [HttpPatch("mod/climate/{name},{t1},{w1},{t2},{w2}")]
        public async Task<IActionResult> UpdateCityClimate(string name, decimal t1, string w1, decimal t2, string w2)
        {
            var target = await _cityService.UpdateCityClimateAsync(name, t1, w1, t2, w2);

            if (target == null)
                return NotFound("City " + name + " wasn't found.");
            return Ok(target);
        }
    }
}
