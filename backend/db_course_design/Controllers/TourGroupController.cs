using db_course_design.Common;
using db_course_design.DTOs;
using db_course_design.Services;
using db_course_design.Services.impl;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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
      业务逻辑(旅行团订单的购买):
        点击购买自动在数据库中产生一条旅行图订单

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
        /// 获取所有旅行团产品
        /// </summary>
        /// <returns>所有旅行团列表</returns>
        [HttpGet("search/all")]
        public async Task<IActionResult> SearchAllTourGroups()
        {
            return Ok(await _tourGroupService.GetAllTourGroupsAsync());
        }

        /// <summary>
        /// 按名字搜索旅行团产品
        /// <param name="name">搜索名称</param>
        /// </summary>
        /// <returns>名称匹配的旅行团列表</returns>
        [HttpGet("search/name/{name}")]
        public async Task<IActionResult> SearchTourGroupsByName(string name)
        {
            var groups = await _tourGroupService.SearchTourGroupsByNameAsync(name);

            if (groups == null || !groups.Any())
                return BadRequest("No tour group found.");
            return Ok(groups.ToList());
        }

        /// <summary>
        /// 按编号查找旅行团信息
        /// <param name="id">旅行团编号</param>
        /// </summary>
        /// <returns>指定编号的旅行团条目</returns>
        [HttpGet("search/id/{id}")]
        public async Task<IActionResult> SearchTourGroupById(byte id)
        {
            var group = await _tourGroupService.SearchTourGroupsByIdAsync(id);

            if (group == null)
                return BadRequest("No tour group found.");
            return Ok(group);
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

            if (tourGroups == null || !tourGroups.Any())
            {
                return NotFound("没有找到符合条件的旅行团。");
            }

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

        /// <summary>
        /// 购买旅行团订单
        /// </summary>
        /// <param name="request">购买请求</param>
        /// <returns>购买结果</returns>
        [HttpPost("purchase")]
        public async Task<ActionResult> PurchaseTourGroupOrder([FromBody] PurchaseTourOrderRequest request)
        {
            if (request == null || request.UserId == null || request.GroupId == null)
            {
                return BadRequest("用户ID和旅行团ID是必填项。");
            }
            var result = await _tourGroupService.PurchaseTourGroupOrderAsync(request);

            if (result)
            {
                return Ok("订单购买成功。");
            }
            else
            {
                return StatusCode(500, "订单购买失败。");
            }
        }

        /// <summary>
        /// 获取全部导游编号和名字
        /// </summary>
        /// <returns>所有导游列表</returns>
        [HttpGet("guide/all")]
        public async Task<IActionResult> GetAllGuides()
        {
            return Ok(await _tourGroupService.GetAllGuidesAsync());
        }


        /*
         * 业务逻辑：管理员对旅行团信息进行增删改
         * api/TourGroup/
         *      add/
         *      POST    - 添加旅行团信息
         *      del/{id}
         *      DELETE  - 删除旅行团信息
         *      mod/{id}
         *      PUT     - 更新旅行团信息
         */
        [HttpPost("add")]
        public async Task<IActionResult> AddTourGroup([FromBody] TourGroupRequest request)
        {
            var target = await _tourGroupService.AddTourGroupAsync(request);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the tour group.");
            return CreatedAtAction(nameof(SearchTourGroupById), new { id = target.GroupId }, target);
        }

        [HttpDelete("del/{id}")]
        public async Task<IActionResult> DeleteTourGroup(byte id)
        {
            var deleted = await _tourGroupService.DeleteTourGroupAsync(id);

            if (!deleted)
                return NotFound("Tour group " + id + " doesn't exist.");
            return NoContent();
        }

        [HttpPut("mod/{id}")]
        public async Task<IActionResult> UpdateTourGroup(byte id, [FromBody] TourGroupRequest request)
        {
            var target = await _tourGroupService.UpdateTourGroupAsync(id, request);

            if (target == null)
                return NotFound("Tour group " + id + " doesn't exist.");
            return Ok(target);
        }


        /*
         * 业务逻辑：导游对旅行团行程信息进行增删改查
         * api/TourGroup/itinerary/
         *      all/{groupId}/
         *          GET     - 获取指定旅行团的所有行程
         *      {itineraryId}/
         *          GET     - 按照编号查找行程
         *      add/
         *          POST    - 添加一条行程
         *      del/{itineraryId}/
         *          DELETE  - 删除一条行程
         *      mod/{itineraryId}/
         *          PUT     - 更新一条行程
         */
        [HttpGet("itinerary/all/{groupId}")]
        public async Task<IActionResult> GetAllTourItineraries(byte groupId)
        {
            var list = await _tourGroupService.GetAllTourItinerarysAsync(groupId);

            if (list == null || !list.Any())
                return NotFound("Tour group " + groupId + " doesn't exist.");
            return Ok(list.ToList());
        }

        [HttpGet("itinerary/{itineraryId}")]
        public async Task<IActionResult> GetTourItineraryById(byte itineraryId)
        {
            var itinerary = await _tourGroupService.GetTourItineraryByIdAsync(itineraryId);

            if (itinerary == null)
                return NotFound("Tour itinerary " + itineraryId + " doesn't exist.");
            return Ok(itinerary);
        }

        [HttpPost("itinerary/add")]
        public async Task<IActionResult> AddTourItinerary([FromBody] TourItineraryRequest request)
        {
            var target = await _tourGroupService.AddTourItineraryAsync(request);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the tour itinerary.");
            return CreatedAtAction(nameof(GetTourItineraryById), new { target.ItineraryId }, target);
        }

        [HttpDelete("itinerary/del/{itineraryId}")]
        public async Task<IActionResult> DeleteTourItinerary(byte itineraryId)
        {
            var deleted = await _tourGroupService.DeleteTourItineraryAsync(itineraryId);

            if (!deleted)
                return NotFound("Tour itinerary " + itineraryId + " doesn't exist.");
            return NoContent();
        }

        [HttpPut("itinerary/mod/{itineraryId}")]
        public async Task<IActionResult> UpdateTourItinerary(byte itineraryId, [FromBody] TourItineraryRequest request)
        {
            var target = await _tourGroupService.UpdateTourItineraryAsync(itineraryId, request);

            if (target == null)
                return NotFound("Tour itinerary " + itineraryId + " doesn't exist.");
            return Ok(target);
        }


        /*
         * 业务逻辑：导游对旅行团酒店信息进行增删改查
         * api/TourGroup/hotel/
         *      all/{groupId}/
         *          GET     - 获取指定旅行团的所有酒店
         *      add/{groupId},{hotelId}/
         *          PUT     - 为指定旅行团添加酒店
         *      del/{groupId},{hotelId}/
         *          DELETE  - 为指定旅行团删除酒店
         *      mod/{groupId},{oldHotelId},{newHotelId}/
         *          PATCH   - 为指定旅行团更新酒店
         */
        [HttpGet("hotel/all/{groupId}")]
        public async Task<IActionResult> GetAllTourHotels(byte groupId)
        {
            var list = await _tourGroupService.GetAllTourHotelsAsync(groupId);

            if (list == null)
                return NotFound("Tour group " + groupId + " doesn't exist.");
            return Ok(list.ToList());
        }

        [HttpPut("hotel/add/{groupId},{hotelId}")]
        public async Task<IActionResult> AddTourHotel(byte groupId, decimal hotelId)
        {
            var target = await _tourGroupService.AddTourHotelAsync(groupId, hotelId);

            if (target == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the tour hotel.");
            return Ok(target);
        }

        [HttpDelete("hotel/del/{groupId},{hotelId}")]
        public async Task<IActionResult> DeleteTourHotel(byte groupId, decimal hotelId)
        {
            var deleted = await _tourGroupService.DeleteTourHotelAsync(groupId, hotelId);

            if (!deleted)
                return NotFound("Tour group " + groupId + " doesn't contain hotel " + hotelId + ".");
            return NoContent();
        }

        [HttpPatch("hotel/mod/{groupId},{oldHotelId},{newHotelId}")]
        public async Task<IActionResult> UpdateTourHotel(byte groupId, decimal oldHotelId, decimal newHotelId)
        {
            var target = await _tourGroupService.UpdateTourHotelAsync(groupId, oldHotelId, newHotelId);

            if (target == null)
                return NotFound("Tour group " + groupId + " doesn't contain hotel " + oldHotelId + ".");
            return Ok(target);
        }
    }
}
