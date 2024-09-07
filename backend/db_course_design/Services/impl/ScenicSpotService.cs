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

        public decimal? ScenicSpotRemoteness { get; set; }
    }

    public class ScenicSpotTicketRequest
    {
        public decimal ScenicSpotId { get; set; }

        public string TicketType { get; set; } = null!;

        public decimal? TicketPrice { get; set; }

        public decimal? TicketRemaining { get; set; }

        public DateTime TicketDate { get; set; }
    }

    public class ScenicSpotService : IScenicSpotService
    {
        private readonly ModelContext _context;

        public ScenicSpotService(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScenicSpotResponse>> GetAllScenicSpotsAsync()
        {
            return await _context.ScenicSpots.Select(s => new ScenicSpotResponse
            {
                ScenicSpotId = s.ScenicSpotId,
                ScenicSpotName = s.ScenicSpotName,
                CityName = s.CityName,
                ScenicSpotGrade = s.ScenicSpotGrade,
                ScenicSpotIntroduction = s.ScenicSpotIntroduction,
                ScenicSpotLocation = s.ScenicSpotLocation,
                ScenicSpotRemoteness = s.ScenicSpotRemoteness
            }).ToListAsync();
        }

        public async Task<IEnumerable<ScenicSpotTicketResponse>> GetAllScenicSpotTicketsAsync()
        {
            return await _context.ScenicSpotTickets.Select(t => new ScenicSpotTicketResponse
            {
                ScenicSpotId = t.ScenicSpotId,
                TicketType = t.TicketType,
                TicketPrice = t.TicketPrice,
                TicketRemaining = t.TicketRemaining,
                TicketDate = t.TicketDate
            }).ToListAsync();
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
                    ScenicSpotRemoteness = s.ScenicSpotRemoteness
                })
                .ToListAsync();

            return scenicSpots;
        }

        public async Task<ScenicSpotResponse?> GetScenicSpotByIdAsync(decimal scenicSpotId)
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
                    ScenicSpotRemoteness = scenicSpot.ScenicSpotRemoteness
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
                    ScenicSpotRemoteness = s.ScenicSpotRemoteness
                })
                .ToListAsync();

            return scenicSpots;
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
                    ScenicSpotRemoteness = s.ScenicSpotRemoteness
                })
                .ToListAsync();

            return scenicSpots;
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
                   ScenicSpotRemoteness = s.ScenicSpotRemoteness
               })
               .ToListAsync();

            return scenicSpots;
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

        public async Task<ScenicSpotResponse?> AddScenicSpotAsync(ScenicSpotRequest request)
        {
            try
            {
                // 将请求对象转换为数据库实体
                var scenicSpot = new ScenicSpot
                {
                    ScenicSpotName = request.ScenicSpotName,
                    CityName = request.CityName,
                    ScenicSpotGrade = request.ScenicSpotGrade,
                    ScenicSpotIntroduction = request.ScenicSpotIntroduction,
                    ScenicSpotLocation = request.ScenicSpotLocation,
                    ScenicSpotRemoteness = request.ScenicSpotRemoteness,
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
                    ScenicSpotLocation = scenicSpot.ScenicSpotLocation,
                    ScenicSpotRemoteness = scenicSpot.ScenicSpotRemoteness
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<ScenicSpotResponse?> UpdateScenicSpotAsync(decimal scenicSpotId, ScenicSpotRequest request)
        {
            try
            {
                // scenicSpotId用于搜索要修改的景点信息，不可修改
                var scenicSpot = await _context.ScenicSpots.FindAsync(scenicSpotId);
                if (scenicSpot == null)
                    throw new Exception();
                scenicSpot.ScenicSpotName = request.ScenicSpotName;
                scenicSpot.CityName = request.CityName;
                scenicSpot.ScenicSpotGrade = request.ScenicSpotGrade;
                scenicSpot.ScenicSpotIntroduction = request.ScenicSpotIntroduction;
                scenicSpot.ScenicSpotLocation = request.ScenicSpotLocation;
                scenicSpot.ScenicSpotRemoteness = request.ScenicSpotRemoteness;
                await _context.SaveChangesAsync();
                return new ScenicSpotResponse
                {
                    ScenicSpotName = scenicSpot.ScenicSpotName,
                    CityName = scenicSpot.CityName,
                    ScenicSpotGrade = scenicSpot.ScenicSpotGrade,
                    ScenicSpotIntroduction = scenicSpot.ScenicSpotIntroduction,
                    ScenicSpotLocation = scenicSpot.ScenicSpotLocation,
                    ScenicSpotRemoteness = scenicSpot.ScenicSpotRemoteness
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteScenicSpotTicketAsync(decimal scenicSpotId, string ticketType, DateTime ticketDate)
        {
            var ticket = await _context.ScenicSpotTickets.FindAsync(scenicSpotId, ticketType, ticketDate);

            if (ticket == null)
            {
                return false; // 未找到门票，删除失败
            }

            _context.ScenicSpotTickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true; // 删除成功
        }

        public async Task<ScenicSpotTicketResponse?> AddScenicSpotTicketAsync(ScenicSpotTicketRequest request)
        {
            try
            {
                // 将请求对象转换为数据库实体
                var ticket = new ScenicSpotTicket
                {
                    ScenicSpotId = request.ScenicSpotId,
                    TicketType = request.TicketType,
                    TicketPrice = request.TicketPrice,
                    TicketRemaining = request.TicketRemaining,
                    TicketDate = request.TicketDate
                };

                // 将实体添加到数据库上下文中
                _context.ScenicSpotTickets.Add(ticket);
                await _context.SaveChangesAsync();

                // 返回添加后的响应对象
                return new ScenicSpotTicketResponse
                {
                    ScenicSpotId = ticket.ScenicSpotId,
                    TicketType = ticket.TicketType,
                    TicketPrice = ticket.TicketPrice,
                    TicketRemaining = ticket.TicketRemaining,
                    TicketDate = ticket.TicketDate
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<ScenicSpotTicketResponse?> UpdateScenicSpotTicketAsync(ScenicSpotTicketRequest request)
        {
            try
            {
                // (scenicSpotId, ticketType, ticketDate)用于搜索要修改的门票信息，不可修改
                var ticket = await _context.ScenicSpotTickets.FindAsync(request.ScenicSpotId, request.TicketType, request.TicketDate);
                if (ticket == null)
                    throw new Exception();
                ticket.TicketPrice = request.TicketPrice;
                ticket.TicketRemaining = request.TicketRemaining;
                await _context.SaveChangesAsync();
                return new ScenicSpotTicketResponse
                {
                    ScenicSpotId = request.ScenicSpotId,
                    TicketType = request.TicketType,
                    TicketDate = request.TicketDate,
                    TicketPrice = request.TicketPrice,
                    TicketRemaining = request.TicketRemaining
                };
            }
            catch
            {
                return null;
            }
        }

        // 获取指定景点指定种类指定日期的门票信息
        public async Task<ScenicSpotTicketResponse?> GetScenicSpotTicketAsync(decimal scenicSpotId, string ticketType, DateTime ticketDate)
        {
            var ticket = await _context.ScenicSpotTickets.FindAsync(scenicSpotId, ticketType, ticketDate);

            if (ticket == null)
            {
                return null; // 未找到门票
            }

            return new ScenicSpotTicketResponse
            {
                ScenicSpotId = ticket.ScenicSpotId,
                TicketType = ticket.TicketType,
                TicketPrice = ticket.TicketPrice,
                TicketRemaining = ticket.TicketRemaining,
                TicketDate = ticket.TicketDate
            };
        }
        public async Task<IEnumerable<ScenicSpotTicketResponse?>> GetTicketInfoAsync(string scenicSpotName)
        {
            // 通过景点名称获取景点信息
            var scenicSpot = await _context.ScenicSpots
                .FirstOrDefaultAsync(s => s.ScenicSpotName == scenicSpotName);

            if (scenicSpot == null)
            {
                return Enumerable.Empty<ScenicSpotTicketResponse?>(); // 未找到对应景点
            }

            // 查询该景点的所有门票信息
            var tickets = await _context.ScenicSpotTickets
                .Where(t => t.ScenicSpotId == scenicSpot.ScenicSpotId)
                .OrderBy(t => t.TicketDate) // 按日期排序
                .ToListAsync();

            // 将查询结果映射为响应对象
            var ticketResponses = tickets.Select(t => new ScenicSpotTicketResponse
            {
                ScenicSpotId = t.ScenicSpotId,
                TicketType = t.TicketType,
                TicketPrice = t.TicketPrice,
                TicketRemaining = t.TicketRemaining,
                TicketDate = t.TicketDate
            });

            return ticketResponses;
        }
        // 获取当天的门票信息
        public async Task<AdultChildTicketResponse?> GetTodayTicketInfoAsync(string scenicSpotName)
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
        public async Task<AdultChildTicketResponse?> GetTicketInfoByDateAsync(string scenicSpotName, DateTime date)
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
            scenicSpotOrder.Order = orderDatum;

            // 再次保存更改，以保存 ScenicSpotOrder 的 OrderId
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<ScenicSpotResponse>> GetRecommendedScenicSpotsAsync()
        {
            var recommendedSpotNames = new List<string>
            {
                "上海迪士尼",
                "同济大学",
                "豫园"
            };

            var recommendedSpots = await _context.ScenicSpots
                .Where(ss => recommendedSpotNames.Contains(ss.ScenicSpotName))
                .ToListAsync();

            return recommendedSpots.Select(ss => new ScenicSpotResponse
            {
                ScenicSpotId = ss.ScenicSpotId,
                ScenicSpotName = ss.ScenicSpotName,
                CityName = "上海",
                ScenicSpotGrade = ss.ScenicSpotGrade,
                ScenicSpotIntroduction = ss.ScenicSpotIntroduction,
                ScenicSpotLocation = ss.ScenicSpotLocation,
                ScenicSpotRemoteness = ss.ScenicSpotRemoteness
            }).ToList();
        }
    }
}
