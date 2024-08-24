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
        private readonly ITourGroupService _tourgroupeService;
        public TourGroupController(ITourGroupService tourgroupeService)
        {
            _tourgroupeService = tourgroupeService;
        }
    }
}
