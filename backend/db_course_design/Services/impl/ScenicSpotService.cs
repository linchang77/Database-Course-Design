using db_course_design.DTOs;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.Common;

namespace db_course_design.Services.impl
{
    public class ScenicSpotRequest
    {
        public string? ScenicSpotName { get; set; }

        public string? CityName { get; set; }

        public string? ScenicSpotGrade { get; set; }

        public string? ScenicSpotIntroduction { get; set; }

        public string? ScenicSpotLocation { get; set; }
    }

    public class ScenicSpotService : IScenicSpotService
    {
        private readonly ModelContext _context;

        public ScenicSpotService(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByCityAsync(string city)
        {
            var scenicSpots = await _context.ScenicSpots
                .Where(s => s.CityName == city)
                .Select(s => new ScenicSpotResponse
                {
                    ScenicSpotId = s.ScenicSpotId,
                    ScenicSpotName = s.ScenicSpotName,
                    CityName = s.CityName,
                    ScenicSpotGrade = s.ScenicSpotGrade,
                    ScenicSpotIntroduction = s.ScenicSpotIntroduction,
                    ScenicSpotLocation = s.ScenicSpotLocation,
                    CityNameNavigation = s.CityNameNavigation,
                    ScenicSpotTickets = s.ScenicSpotTickets
                })
                .ToListAsync();

            return scenicSpots.Any() ? scenicSpots : null;
        }

        public async Task<ScenicSpotResponse> GetScenicSpotByIdAsync(decimal scenicSpotId)
        {
            var scenicSpot = await _context.ScenicSpots
                .FirstOrDefaultAsync(s => s.ScenicSpotId == scenicSpotId);

            if (scenicSpot == null)
            {
                return null;
            }
            else
                return new ScenicSpotResponse
                {
                    ScenicSpotId = scenicSpot.ScenicSpotId,
                    ScenicSpotName = scenicSpot.ScenicSpotName,
                    CityName = scenicSpot.CityName,
                    ScenicSpotGrade = scenicSpot.ScenicSpotGrade,
                    ScenicSpotIntroduction = scenicSpot.ScenicSpotIntroduction,
                    ScenicSpotLocation = scenicSpot.ScenicSpotLocation,
                    CityNameNavigation = scenicSpot.CityNameNavigation,
                    ScenicSpotTickets = scenicSpot.ScenicSpotTickets
                };
        }

        public async Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByNameAsync(string scenicSpotName)
        {
            var scenicSpots = await _context.ScenicSpots
                .Where(s => s.ScenicSpotName.Contains(scenicSpotName))
                .Select(s => new ScenicSpotResponse
                {
                    ScenicSpotId = s.ScenicSpotId,
                    ScenicSpotName = s.ScenicSpotName,
                    CityName = s.CityName,
                    ScenicSpotGrade = s.ScenicSpotGrade,
                    ScenicSpotIntroduction = s.ScenicSpotIntroduction,
                    ScenicSpotLocation = s.ScenicSpotLocation,
                    CityNameNavigation = s.CityNameNavigation,
                    ScenicSpotTickets = s.ScenicSpotTickets
                })
                .ToListAsync();

            return scenicSpots.Any() ? scenicSpots : null;
        }

        public async Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByGradeAsync(string city, string grade)
        {
            var scenicSpots = await _context.ScenicSpots
                .Where(s => s.CityName == city && s.ScenicSpotGrade == grade)
                .Select(s => new ScenicSpotResponse
                {
                    ScenicSpotId = s.ScenicSpotId,
                    ScenicSpotName = s.ScenicSpotName,
                    CityName = s.CityName,
                    ScenicSpotGrade = s.ScenicSpotGrade,
                    ScenicSpotIntroduction = s.ScenicSpotIntroduction,
                    ScenicSpotLocation = s.ScenicSpotLocation,
                    CityNameNavigation = s.CityNameNavigation,
                    ScenicSpotTickets = s.ScenicSpotTickets
                })
                .ToListAsync();

            return scenicSpots.Any() ? scenicSpots : null;
        }

        public async Task<IEnumerable<ScenicSpotResponse>> GetScenicSpotsByDistance(string city, int mindis, int maxdis)
        {
            var scenicSpots = await _context.ScenicSpots
               .Where(s => s.CityName == city && Convert.ToDecimal(s.ScenicSpotLocation) >=mindis && Convert.ToDecimal(s.ScenicSpotLocation) <= maxdis)
               .Select(s => new ScenicSpotResponse
               {
                   ScenicSpotId = s.ScenicSpotId,
                   ScenicSpotName = s.ScenicSpotName,
                   CityName = s.CityName,
                   ScenicSpotGrade = s.ScenicSpotGrade,
                   ScenicSpotIntroduction = s.ScenicSpotIntroduction,
                   ScenicSpotLocation = s.ScenicSpotLocation,
                   CityNameNavigation = s.CityNameNavigation,
                   ScenicSpotTickets = s.ScenicSpotTickets
               })
               .ToListAsync();

            return scenicSpots.Any() ? scenicSpots : null;
        }

        public async Task<bool> DeleteScenicSpotAsync(decimal scenicSpotId)
        {
            var scenicSpot = await _context.ScenicSpots
                .FirstOrDefaultAsync(s => s.ScenicSpotId == scenicSpotId);

            if (scenicSpot == null)
            {
                return false; // 未找到景点，删除失败
            }

            _context.ScenicSpots.Remove(scenicSpot);
            await _context.SaveChangesAsync();
            return true; // 删除成功
        }
        public async Task<ScenicSpotResponse> AddScenicSpotAsync(ScenicSpotRequest request)
        {
            // 将请求对象转换为数据库实体
            var scenicSpot = new ScenicSpot
            {
                ScenicSpotName = request.ScenicSpotName,
                CityName = request.CityName,
                ScenicSpotGrade = request.ScenicSpotGrade,
                ScenicSpotIntroduction = request.ScenicSpotIntroduction,
                ScenicSpotLocation = request.ScenicSpotLocation,
            };

            // 将实体添加到数据库上下文中
            _context.ScenicSpots.Add(scenicSpot);
            await _context.SaveChangesAsync();

            // 返回添加后的响应对象
            return new ScenicSpotResponse
            {
                ScenicSpotName = scenicSpot.ScenicSpotName,
                CityName = scenicSpot.CityName,
                ScenicSpotGrade = scenicSpot.ScenicSpotGrade,
                ScenicSpotIntroduction = scenicSpot.ScenicSpotIntroduction,
                ScenicSpotLocation = scenicSpot.ScenicSpotLocation
            };
        }
        // 获取当天的门票信息
        public async Task<AdultChildTicketResponse> GetTodayTicketInfoAsync(string scenicSpotName)
        {
            var today = DateTime.Today;

            var tickets = await _context.ScenicSpotTickets
                .Where(t => t.ScenicSpot.ScenicSpotName == scenicSpotName && t.TicketDate == today)
                .ToListAsync();

            var adultTicket = tickets.FirstOrDefault(t => t.TicketType == "成人票");
            var childTicket = tickets.FirstOrDefault(t => t.TicketType == "儿童票");

            return new AdultChildTicketResponse
            {
                AdultTicket = adultTicket != null ? new ScenicSpotTicketResponse
                {
                    ScenicSpotId = adultTicket.ScenicSpotId,
                    TicketType = adultTicket.TicketType,
                    TicketPrice = adultTicket.TicketPrice,
                    TicketRemaining = adultTicket.TicketRemaining,
                    TicketDate = adultTicket.TicketDate
                } : null,
                ChildTicket = childTicket != null ? new ScenicSpotTicketResponse
                {
                    ScenicSpotId = childTicket.ScenicSpotId,
                    TicketType = childTicket.TicketType,
                    TicketPrice = childTicket.TicketPrice,
                    TicketRemaining = childTicket.TicketRemaining,
                    TicketDate = childTicket.TicketDate
                } : null
            };
        }

        // 获取特定日期的门票信息
        public async Task<AdultChildTicketResponse> GetTicketInfoByDateAsync(string scenicSpotName, DateTime date)
        {
            var tickets = await _context.ScenicSpotTickets
                .Where(t => t.ScenicSpot.ScenicSpotName == scenicSpotName && t.TicketDate == date)
                .ToListAsync();

            var adultTicket = tickets.FirstOrDefault(t => t.TicketType == "成人票");
            var childTicket = tickets.FirstOrDefault(t => t.TicketType == "儿童票");

            return new AdultChildTicketResponse
            {
                AdultTicket = adultTicket != null ? new ScenicSpotTicketResponse
                {
                    ScenicSpotId = adultTicket.ScenicSpotId,
                    TicketType = adultTicket.TicketType,
                    TicketPrice = adultTicket.TicketPrice,
                    TicketRemaining = adultTicket.TicketRemaining,
                    TicketDate = adultTicket.TicketDate
                } : null,
                ChildTicket = childTicket != null ? new ScenicSpotTicketResponse
                {
                    ScenicSpotId = childTicket.ScenicSpotId,
                    TicketType = childTicket.TicketType,
                    TicketPrice = childTicket.TicketPrice,
                    TicketRemaining = childTicket.TicketRemaining,
                    TicketDate = childTicket.TicketDate
                } : null
            };
        }

        // 购买门票
        public async Task<bool> PurchaseTicketAsync(string scenicSpotName, string type, DateTime date, CreateScenicSpotOrderRequest orderRequest, int number = 1)
        {
            // 查找符合条件的门票
            var ticket = await _context.ScenicSpotTickets
                .FirstOrDefaultAsync(t => t.ScenicSpot.ScenicSpotName == scenicSpotName && t.TicketType == type && t.TicketDate == date);

            if (ticket == null || ticket.TicketRemaining <= 0)
            {
                return false; // 没有找到票或票数不足
            }

            // 减少剩余票数
            ticket.TicketRemaining-=number;

            // 创建 ScenicSpotOrder 实体
            var scenicSpotOrder = new ScenicSpotOrder
            {
                ScenicSpotId = ticket.ScenicSpotId,
                TicketType = type,
                TicketNumber = number,
                TicketDate = date,
                ScenicSpotTicket = ticket
            };

            // 创建 OrderDatum 实体
            var orderDatum = new OrderDatum
            {
                OrderType = "scenic_spot",
                OrderDate = orderRequest.OrderDate ?? DateTime.Now, // 如果未指定日期，使用当前日期
                UserId = orderRequest.UserId,
                Status = orderRequest.Status ?? "Pending", // 默认状态为 "Pending"
                Price = ticket.TicketPrice*number, // 使用门票价格
                ScenicSpotOrders = new List<ScenicSpotOrder> { scenicSpotOrder } // 将 ScenicSpotOrder 关联到 OrderDatum
            };

            // 将 OrderDatum 添加到上下文并保存，以生成 OrderId
            _context.OrderData.Add(orderDatum);
            await _context.SaveChangesAsync();

            // 设置 ScenicSpotOrder 的外键 OrderId
            scenicSpotOrder.OrderId = orderDatum.OrderId;

            // 再次保存更改，以保存 ScenicSpotOrder 的 OrderId
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
