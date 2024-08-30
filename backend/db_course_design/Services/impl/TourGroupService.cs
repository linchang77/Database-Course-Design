using db_course_design.DTOs;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.Common;
using AutoMapper;
using db_course_design.Profiles;

namespace db_course_design.Services.impl
{
    public class TourGroupRequest
    {
        public byte? GuideId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? GroupName { get; set; }

        public decimal? GroupPrice { get; set; }

        public decimal? GoTicketId { get; set; }

        public decimal? ReturnTicketId { get; set; }

        public string? Departure { get; set; }

        public string? Destination { get; set; }
    }

    public class TourItineraryRequest
    {
        public byte? GroupId { get; set; }

        public DateTime? ItineraryTime { get; set; }

        public TimeSpan? ItineraryDuration { get; set; }

        public decimal? ScenicSpotId { get; set; }

        public string? Activities { get; set; }
    }

    public class TourGroupService : ITourGroupService
    {
        private readonly ModelContext _context;

        public IMapper _mapper { get; }

        public TourGroupService(ModelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<TourGroupProfile>()).CreateMapper();
        }

        public async Task<IEnumerable<TourGroupResponse>> GetAllTourGroupsAsync()
        {
            return await _context.TourGroups
                .Include(t => t.TourItineraries)
                .Include(t => t.Hotels)
                .Include(t => t.Guide) // 加载导游信息
                .Include(t => t.GoTicket) // 加载去程票信息
                .Include(t => t.ReturnTicket) // 加载回程票信息
                .Select(t => _mapper.Map<TourGroupResponse>(t))
                .ToListAsync();
        }


        public async Task<IEnumerable<TourGroupResponse>> SearchTourGroupsByCityAsync(SearchTourGroupRequest request)
        {
            var query = _context.TourGroups
                .Include(tg => tg.TourItineraries)
                .Include(tg => tg.Hotels)
                .Include(t => t.Guide) // 加载导游信息
                .Where(tg => tg.Departure == request.Departure &&
                       tg.Destination == request.Destination &&
                       (request.Departure_Time == null || tg.StartDate >= request.Departure_Time) &&
                       (request.Days_of_Travel == 0 || tg.EndDate <= tg.StartDate.Value.AddDays(request.Days_of_Travel))
                             );

            var tourGroups = await query.ToListAsync();

            return tourGroups.Select(t => _mapper.Map<TourGroupResponse>(t));
        }

        public async Task<TourGroupResponse?> SearchTourGroupsByIdAsync(byte id)
        {
            var query = _context.TourGroups
                .Where(tg => tg.GroupId == id)
                .Include(tg => tg.TourItineraries)
                .Include(tg => tg.Hotels)
                .Include(t => t.Guide); // 加载导游信息;
            var tourGroup = (await query.ToListAsync()).SingleOrDefault();

            if (tourGroup == null)
                return null;

            return _mapper.Map<TourGroupResponse>(tourGroup);
        }

        public async Task<IEnumerable<TourGroupResponse>> SearchTourGroupsByNameAsync(string name)
        {
            var query = _context.TourGroups
                .Where(tg => tg.GroupName.Contains(name))
                .Include(tg => tg.TourItineraries)
                .Include(tg => tg.Hotels)
                .Include(t => t.Guide);
            var tourGroups = await query.ToListAsync();

            return tourGroups.Select(t => _mapper.Map<TourGroupResponse>(t));
        }

        public async Task<IEnumerable<TourGroupResponse>> GetRecommendedTourGroupsAsync()
        {
            var recommendedGroups = await _context.TourGroups
                .Include(tg => tg.TourItineraries)
                .Include(tg => tg.Hotels)
                .Include(t => t.Guide)
                .OrderBy(tg => tg.GroupPrice) // 假设推荐规则是按最低价格排序
                .ToListAsync();

            return recommendedGroups.Select(t => _mapper.Map<TourGroupResponse>(t));
        }

        public async Task<bool> PurchaseTourGroupOrderAsync(PurchaseTourOrderRequest request, int number = 1)
        {
            if (request == null || request.GroupId == null || request.UserId == null)
            {
                throw new ArgumentException("旅行团ID和用户ID是必填项。");
            }
            byte groupId = (byte)request.GroupId.Value;
            // 查找对应的旅行团
            var tourGroup = await _context.TourGroups
                .Include(t => t.GoTicket)
                .Include(t => t.ReturnTicket)
                .FirstOrDefaultAsync(t => t.GroupId == request.GroupId);

            if (tourGroup == null)
            {
                throw new ArgumentException("未找到对应的旅行团。");
            }

            // 创建订单数据
            var orderDatum = new OrderDatum
            {
                OrderType = "tour_group",
                OrderDate = DateTime.UtcNow,
                UserId = request.UserId,
                Status = "Pending",
                Price = tourGroup.GroupPrice*number,
            };

            // 将 OrderDatum 添加到上下文并保存，以生成 OrderId
            _context.OrderData.Add(orderDatum);
            await _context.SaveChangesAsync();

            // 创建旅行团订单
            var tourOrder = new TourOrder
            {
                GroupId = groupId,
                OrderNumber = number,
                OrderId = orderDatum.OrderId, // 设置 TourOrder 的外键 OrderId
                Group = tourGroup, // 设置 Group 关系属性
                Order = orderDatum // 设置 Order 关系属性
            };

            // 保存到数据库
            _context.TourOrders.Add(tourOrder);

            // 保存更改
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TourGroupResponse?> AddTourGroupAsync(TourGroupRequest request)
        {
            try
            {
                var record = _mapper.Map<TourGroup>(request);
                _context.TourGroups.Add(record);
                await _context.SaveChangesAsync();
                return _mapper.Map<TourGroupResponse>(record);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteTourGroupAsync(byte id)
        {
            var target = await _context.TourGroups.FindAsync(id);

            if (target == null)
                return false;

            _context.TourGroups.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TourGroupResponse?> UpdateTourGroupAsync(byte id, TourGroupRequest request)
        {
            try
            {
                var target = (await _context.TourGroups
                .Include(t => t.TourItineraries)
                .Include(t => t.Hotels)
                .Where(t => t.GroupId == id)
                .ToListAsync()).SingleOrDefault();
                if (target == null)
                    throw new Exception();
                target.GuideId = request.GuideId;
                target.StartDate = request.StartDate;
                target.EndDate = request.EndDate;
                target.GroupName = request.GroupName;
                target.GroupPrice = request.GroupPrice;
                target.GoTicketId = request.GoTicketId;
                target.ReturnTicketId = request.ReturnTicketId;
                target.Departure = request.Departure;
                target.Destination = request.Destination;
                await _context.SaveChangesAsync();
                return _mapper.Map<TourGroupResponse>(target);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<TourItineraryResponse>> GetAllTourItinerarysAsync(byte groupId)
        {
            var group = (await _context.TourGroups
                .Where(g => g.GroupId == groupId)
                .Include(g => g.TourItineraries)
                .ToListAsync()).SingleOrDefault();

            if (group == null)
                return Enumerable.Empty<TourItineraryResponse>();
            return group.TourItineraries
                .Select(i => _mapper.Map<TourItineraryResponse>(i))
                .OrderBy(i => i.ItineraryTime);
        }

        public async Task<TourItineraryResponse?> GetTourItineraryByIdAsync(byte itineraryId)
        {
            var itinerary = await _context.TourItineraries.FindAsync(itineraryId);

            if (itinerary == null)
                return null;
            return _mapper.Map<TourItineraryResponse>(itinerary);
        }

        public async Task<TourItineraryResponse?> AddTourItineraryAsync(TourItineraryRequest request)
        {
            try
            {
                var record = _mapper.Map<TourItinerary>(request);
                _context.TourItineraries.Add(record);
                await _context.SaveChangesAsync();
                return _mapper.Map<TourItineraryResponse>(record);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteTourItineraryAsync(byte id)
        {
            var target = await _context.TourItineraries.FindAsync(id);

            if (target == null)
                return false;

            _context.TourItineraries.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TourItineraryResponse?> UpdateTourItineraryAsync(byte id, TourItineraryRequest request)
        {
            try
            {
                var target = await _context.TourItineraries.FindAsync(id);
                if (target == null)
                    return null;
                target.GroupId = request.GroupId;
                target.ItineraryTime = request.ItineraryTime;
                target.ItineraryDuration = request.ItineraryDuration;
                target.ScenicSpotId = request.ScenicSpotId;
                target.Activities = request.Activities;
                await _context.SaveChangesAsync();
                return _mapper.Map<TourItineraryResponse>(target);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<HotelResponse>> GetAllTourHotelsAsync(byte groupId)
        {
            var group = (await _context.TourGroups
                .Where(g => g.GroupId == groupId)
                .Include(g => g.Hotels)
                .ToListAsync()).SingleOrDefault();

            if (group == null)
                return Enumerable.Empty<HotelResponse>();

            return group.Hotels.Select(h => _mapper.Map<HotelResponse>(h));
        }

        public async Task<HotelResponse?> AddTourHotelAsync(byte groupId, decimal hotelId)
        {
            var group = (await _context.TourGroups
                .Where(g => g.GroupId == groupId)
                .Include(g => g.Hotels)
                .ToListAsync()).SingleOrDefault();

            if (group == null) 
                return null;

            var hotel = await _context.Hotels.FindAsync(hotelId);

            if (hotel == null)
                return null;

            group.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelResponse>(hotel);
        }

        public async Task<bool> DeleteTourHotelAsync(byte groupId, decimal hotelId)
        {
            var group = (await _context.TourGroups
                .Where(g => g.GroupId == groupId)
                .Include(g => g.Hotels)
                .ToListAsync()).SingleOrDefault();

            if (group == null)
                return false;

            var hotel = await _context.Hotels.FindAsync(hotelId);

            if (hotel == null)
                return false;

            if (!group.Hotels.Remove(hotel))
                return false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<HotelResponse?> UpdateTourHotelAsync(byte groupId, decimal oldHotelId, decimal newHotelId)
        {
            try
            {
                if (await DeleteTourHotelAsync(groupId, oldHotelId))
                    return await AddTourHotelAsync(groupId, newHotelId);
            }
            catch
            {
                return null;
            }

            return null;
        }

        public async Task<IEnumerable<GuideResponse>> GetAllGuidesAsync()
        {
            return await _context.Guides.Select(g => _mapper.Map<GuideResponse>(g)).ToListAsync();
        }
    }
}
 