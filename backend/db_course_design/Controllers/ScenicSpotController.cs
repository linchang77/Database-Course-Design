using Microsoft.AspNetCore.Mvc;
using db_course_design.Common;
using db_course_design.Services;
using db_course_design.Services.impl;
using db_course_design.DTOs;

namespace db_course_design.Controllers
{
    /*业务逻辑(关于景点的搜索)：
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
            all/
                spots/
                    GET           - 获取所有景点
                tickets/
                    GET           - 获取所有景点门票
            {city}/
                GET               - 获取该城市所有的景点
                id/
                {ScenicSpotId}
                        GET       - 按景点ID搜索
                name/
                {ScenicSpotName}
                        GET       - 按景点名字搜索
                grade/
                    {grade}/
                        GET       - 按景点的星级筛选
                distance/
                    {distance}/
                         GET      - 按距离市中心距离筛选
      业务逻辑（用户购买景点门票）：
            展示景点的门票信息：
            点击某一个景点，显示它的儿童票和成人票票价，当天的剩余票数
            展示特定日期景点的门票信息：
            筛选日期之后显示它的儿童票和成人票票价，当天的剩余票数

            购买门票：
            增加一个景点订单，同时门票剩余票数减一
    [HttpGet("ticket/{scenicSpotName}")]                                       -获取该景点当天的门票信息
    [HttpGet("ticket/{scenicSpotName}/date/{date}")]                           -获取特定日期的门票信息
    [HttpPost("ticket/{scenicSpotName}/date/{date}/purchase/type/{type}/quantity/{quantity}")]     -购买{ScenicSpotName}的 {type}门票（type只能是‘成人票’或者‘儿童票’）
                          
    注意事项！！！
    目前用户信息还没做好 UserId填41  status填已购买   价格填0就行
                                        
            
      
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

        [HttpGet("all/spots")]
        public async Task<IActionResult> GetAllScenicSpots()
        {
            return Ok(await _scenicSpotService.GetAllScenicSpotsAsync());
        }

        [HttpGet("all/tickets")]
        public async Task<IActionResult> GetAllScenicSpotTickets()
        {
            return Ok(await _scenicSpotService.GetAllScenicSpotTicketsAsync());
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

        //根据星级筛选
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

        //根据距离筛选
        [HttpGet("{city}/distance/{mindis},{maxdis}")]
        public async Task<IActionResult> GetScenicSpotsByDistance(string city, int mindis,int maxdis)
        {
            var scenicSpots = await _scenicSpotService.GetScenicSpotsByDistance(city, mindis,maxdis);
            if (scenicSpots == null || !scenicSpots.Any())
            {
                return NotFound();
            }
            return Ok(scenicSpots);
        }


        //根据Id删除
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


        //添加景点
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

        //更新景点信息
        [HttpPut("{scenicSpotId}/update")]
        public async Task<IActionResult> UpdateScenicSpot(decimal scenicSpotId, [FromBody] ScenicSpotRequest request)
        {
            var newScenicSpot = await _scenicSpotService.UpdateScenicSpotAsync(scenicSpotId, request);

            if (newScenicSpot == null)
                return BadRequest("Cannot update scenic spot " + scenicSpotId);
            return Ok(newScenicSpot);
        }

        // 删除门票
        [HttpDelete("{scenicSpotId}/{ticketType},{ticketDate}")]
        public async Task<IActionResult> DeleteScenicSpotTicket(decimal scenicSpotId, string ticketType, DateTime ticketDate)
        {
            var deleted = await _scenicSpotService.DeleteScenicSpotTicketAsync(scenicSpotId, ticketType, ticketDate);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // 添加门票
        [HttpPost("ticket")]
        public async Task<IActionResult> AddScenicSpotTicket([FromBody] ScenicSpotTicketRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedTicket = await _scenicSpotService.AddScenicSpotTicketAsync(request);

            if (addedTicket == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the scenic spot ticket.");
            }

            // 返回 201 Created 状态码，并包含新创建的景点门票的详细信息
            return CreatedAtAction(nameof(GetScenicSpotTicketInfo), 
                                   new { scenicSpotId = addedTicket.ScenicSpotId,
                                         ticketType = addedTicket.TicketType,
                                         ticketDate = addedTicket.TicketDate
                                       }, 
                                   addedTicket);
        }

        [HttpPut("ticket/update")]
        public async Task<IActionResult> UpdateScenicSpotTicket([FromBody] ScenicSpotTicketRequest request)
        {
            var newTicket = await _scenicSpotService.UpdateScenicSpotTicketAsync(request);

            if (newTicket == null)
                return BadRequest("Cannot update " + request.TicketType + " of scenic spot " + request.ScenicSpotId + " on " + request.TicketDate);
            return Ok(newTicket);
        }

        // 获取指定景点指定种类指定日期的门票信息
        [HttpGet("ticket/{scenicSpotId},{ticketType},{ticketDate}")]
        public async Task<IActionResult> GetScenicSpotTicketInfo(decimal scenicSpotId, string ticketType, DateTime ticketDate)
        {
            var result = await _scenicSpotService.GetScenicSpotTicketAsync(scenicSpotId, ticketType, ticketDate);

            if (result == null)
            {
                return NotFound("No " + ticketType + " at " +  ticketDate + " found for this scenic spot.");
            }
            return Ok(result);
        }

        // 获取指定景点当天的门票信息
        [HttpGet("ticket/{scenicSpotName}")]
        public async Task<ActionResult<AdultChildTicketResponse>> GetTodayTicketInfo(string scenicSpotName)
        {
            var result = await _scenicSpotService.GetTodayTicketInfoAsync(scenicSpotName);
            if (result.AdultTicket == null && result.ChildTicket == null)
            {
                return NotFound("Scenic spot or tickets not found for today.");
            }
            return Ok(result);
        }

        // 获取指定日期的门票信息
        [HttpGet("ticket/{scenicSpotName}/date/{date}")]
        public async Task<ActionResult<AdultChildTicketResponse>> GetTicketInfoByDate(string scenicSpotName, DateTime date)
        {
            var result = await _scenicSpotService.GetTicketInfoByDateAsync(scenicSpotName, date);
            if (result.AdultTicket == null && result.ChildTicket == null)
            {
                return NotFound("Scenic spot or tickets not found for the specified date.");
            }
            return Ok(result);
        }

        // 购买门票
        [HttpPost("ticket/{scenicSpotName}/date/{date}/purchase/type/{type}/quantity/{quantity}")]
        public async Task<ActionResult> PurchaseTicket(string scenicSpotName, string type, DateTime date, CreateScenicSpotOrderRequest orderRequest)
        {
            if (type != "成人票" && type != "儿童票")
            {
                return BadRequest("Invalid ticket type. It must be '成人票' or '儿童票'.");
            }

            var success = await _scenicSpotService.PurchaseTicketAsync(scenicSpotName, type, date, orderRequest);
            if (!success)
            {
                return BadRequest("Unable to purchase the ticket. It may be sold out or the scenic spot does not exist.");
            }

            return Ok("Ticket purchased successfully.");
        }

    }
}
