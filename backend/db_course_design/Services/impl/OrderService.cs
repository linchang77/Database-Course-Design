using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;
/*--订单管理的服务类，简化控制器逻辑--*/
namespace db_course_design.Services.impl
{
    public class OrderService : IOrderService
    {
        /*--上下文连接数据库--*/
        private readonly ModelContext _context;

        public OrderService(ModelContext context)
        {
            _context = context;
        }

        /*--获取角色&Id相关的订单--*/
        public async Task<List<OrderResponse>> GetAllOrdersAsync(string role, int Id)
        {
            var allOrders = new List<OrderResponse>();

            if(role.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                var guideOrders = await GetGuideOrdersAsync(userId: Id);
                var hotelOrders = await GetHotelOrdersAsync(Id);
                var scenicOrders = await GetScenicOrdersAsync(Id);
                var tourOrders = await GetTourOrdersAsync(userId: Id);
                var vehicleOrders = await GetVehicleOrdersAsync(Id);

                allOrders.AddRange(guideOrders);
                allOrders.AddRange(hotelOrders);
                allOrders.AddRange(scenicOrders);
                allOrders.AddRange(tourOrders);
                allOrders.AddRange(vehicleOrders);
            }
            else
            {
                var guideOrders = await GetGuideOrdersAsync(guideId: Id);
                var tourOrders = await GetTourOrdersAsync(guideId: Id);

                allOrders.AddRange(guideOrders);
                allOrders.AddRange(tourOrders);
            }

            return allOrders;
        }

        /*--按订单分类筛选--*/
        public async Task<List<GuideOrderDetail>> GetGuideOrdersAsync(int? userId = null, int? guideId = null)
        {
            var query = _context.GuideOrders.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(o => o.Order.UserId == userId.Value);
            }
            if (guideId.HasValue)
            {
                query = query.Where(o => o.Order.GuideOrder.GuideId == guideId.Value);
            }

            var guideOrders = await query
                .Select(o => new GuideOrderDetail
                {
                    OrderId = o.OrderId,
                    OrderType = "GuideOrder",
                    Status = o.Order.Status,
                    OrderDate = o.Order.OrderDate,
                    Price = o.Order.Price,
                    ServiceBeginDate = o.ServiceBeginDate,
                    ServiceEndDate = o.ServiceEndDate,
                    Service = o.Service,
                    GuideId = o.Guide.GuideId,
                    GuideName = o.Guide.GuideName,
                    GuideGender = o.Guide.GuideGender,
                }).ToListAsync();
            return guideOrders;
        }
        public async Task<List<HotelOrderDetail>> GetHotelOrdersAsync(int userId)
        {
            var hotelOrders = await (from ho in _context.HotelOrders
                                     join h in _context.Hotels on ho.HotelId equals h.HotelId
                                     where ho.Order.UserId == userId
                                     select new HotelOrderDetail
                                     {
                                         OrderId = ho.OrderId,
                                         OrderType = "HotelOrder",
                                         Status = ho.Order.Status,
                                         OrderDate = ho.Order.OrderDate,
                                         Price = ho.Order.Price,
                                         CityName = h.CityName,
                                         HotelName = h.HotelName,
                                         HotelLocation = h.HotelLocation,
                                         CheckInDate = ho.CheckInDate,
                                         CheckOutDate = ho.CheckOutDate,
                                         RoomType = ho.HotelRoom.RoomType,
                                     }).ToListAsync();
            return hotelOrders;
        }

        public async Task<List<ScenicOrderDetail>> GetScenicOrdersAsync(int userId)
        {
            var scenicOrders = await (from so in _context.ScenicSpotOrders
                                      join s in _context.ScenicSpots on so.ScenicSpotId equals s.ScenicSpotId
                                      where so.Order.UserId == userId
                                      select new ScenicOrderDetail
                                      {
                                          OrderId = so.OrderId,
                                          OrderType = "ScenicOrder",
                                          Status = so.Order.Status,
                                          OrderDate = so.Order.OrderDate,
                                          Price = so.Order.Price,
                                          CityName = s.CityName,
                                          ScenicSpotName = s.ScenicSpotName,
                                          TicketType = so.TicketType,
                                          TicketNumber = so.TicketNumber,
                                          TicketDate = so.TicketDate,
                                      }).ToListAsync();
            return scenicOrders;
        }

        public async Task<List<TourOrderDetail>> GetTourOrdersAsync(int? userId = null, int? guideId = null)
        {
            var query = _context.TourOrders.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(o => o.Order.UserId == userId);
            }
            if (guideId.HasValue)
            {
                query = query.Where(o => o.Order.TourOrder.Group.GuideId == guideId);
            }

            var tourOrders = await query
                .Select(o => new TourOrderDetail
                {
                    OrderId = o.OrderId,
                    OrderType = "TourOrder",
                    Status = o.Order.Status,
                    OrderDate = o.Order.OrderDate,
                    Price = o.Order.Price,
                    GroupId = o.GroupId,
                    GroupName = o.Group.GroupName,
                    GuideId = o.Group.GuideId,
                    GuideName = o.Group.Guide.GuideName,
                    GuideGender = o.Group.Guide.GuideGender,
                    StartDate = o.Group.StartDate,
                    EndDate = o.Group.EndDate,
                }).ToListAsync();
            return tourOrders;
        }

        public async Task<List<VehicleOrderDetail>> GetVehicleOrdersAsync(int userId)
        {
            var vehicleOrders = await _context.VehicleOrders
                .Where(o => o.Order.UserId == userId)
                .Select(o => new VehicleOrderDetail
                {
                    OrderId = o.OrderId,
                    OrderType = "VehicleOrder",
                    Status = o.Order.Status,
                    OrderDate = o.Order.OrderDate,
                    Price = o.Order.Price,
                    VehicleId = o.Ticket.VehicleId,
                    VehicleType = o.Ticket.Vehicle.VehicleType,
                    TicketId = o.Ticket.TicketId,
                    TicketType = o.Ticket.TicketType,
                    TicketUserName = o.TicketUserName,
                    TicketDepartureTime = o.Ticket.TicketDepartureTime,
                    TicketArrivalTime = o.Ticket.TicketArrivalTime,
                    TicketDepartureCity = o.Ticket.TicketDepartureCity,
                    TicketArrivalCity = o.Ticket.TicketArrivalCity,
                    TicketDepartureStation = o.Ticket.TicketDepartureStation,
                    TicketArrivalStation = o.Ticket.TicketArrivalStation,
                }).ToListAsync();
            return vehicleOrders;
        }

        public async Task<List<OrderResponse>> GetOrdersByCategoryAsync(string role, int Id, string orderType)
        {
            if(role.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                if (orderType.Equals("GuideOrder", StringComparison.OrdinalIgnoreCase))
                {
                    var guideOrders = await GetGuideOrdersAsync(userId: Id);
                    return guideOrders.Cast<OrderResponse>().ToList();
                }
                else if (orderType.Equals("HotelOrder", StringComparison.OrdinalIgnoreCase))
                {
                    var hotelOrders = await GetHotelOrdersAsync(Id);
                    return hotelOrders.Cast<OrderResponse>().ToList();
                }
                else if (orderType.Equals("ScenicOrder", StringComparison.OrdinalIgnoreCase))
                {
                    var scenicOrders = await GetScenicOrdersAsync(Id);
                    return scenicOrders.Cast<OrderResponse>().ToList();
                }
                else if (orderType.Equals("TourOrder", StringComparison.OrdinalIgnoreCase))
                {
                    var tourOrders = await GetTourOrdersAsync(userId: Id);
                    return tourOrders.Cast<OrderResponse>().ToList();
                }
                else if (orderType.Equals("VehicleOrder", StringComparison.OrdinalIgnoreCase))
                {
                    var vehicleOrders = await GetVehicleOrdersAsync(Id);
                    return vehicleOrders.Cast<OrderResponse>().ToList();
                }
                else
                {
                    throw new ArgumentException("Invalid order category type.");
                }
            }
            else
            {
                if (orderType.Equals("GuideOrder", StringComparison.OrdinalIgnoreCase))
                {
                    var guideOrders = await GetGuideOrdersAsync(guideId: Id);
                    return guideOrders.Cast<OrderResponse>().ToList();
                }
                else if (orderType.Equals("TourOrder", StringComparison.OrdinalIgnoreCase))
                {
                    var tourOrders = await GetTourOrdersAsync(guideId: Id);
                    return tourOrders.Cast<OrderResponse>().ToList();
                }
                else
                {
                    throw new ArgumentException("Invalid order category type.");
                }
            }
        }

        /*--按订单状态筛选--*/
        public async Task<List<OrderResponse>> GetOrdersByStatusAsync(string role, int Id, string status)
        {
            var allOrders = await GetAllOrdersAsync(role, Id);

            var filteredOrders = allOrders.Where(o => o.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            return filteredOrders;
        }

        /*--按订单ID搜索--*/
        public async Task<OrderResponse> GetOrderByIdAsync(string role, int Id, int orderId)
        {
            var allOrders = await GetAllOrdersAsync(role, Id);

            var targetOrder = allOrders.Where(o => o.OrderId == orderId).FirstOrDefault();
            return targetOrder;
        }

        /*--删除某个订单(其实是改状态属性)--*/
        public async Task<bool> DelOrderByIdAsync(string role, int Id, int orderId)
        {
            var targetOrder = await GetOrderByIdAsync(role, Id, orderId);
            if(targetOrder == null) {  return false; }
            targetOrder.Status = "Cancel";
            // 保存更改
            await _context.SaveChangesAsync();
            return true;
        }

        /*--按时间段筛选--*/
        public async Task<List<OrderResponse>> GetOrdersByTimeAsync(string role, int Id, DateTime start, DateTime end)
        {
            var orders = new List<OrderResponse>();

            if(role.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                var guideOrders = await GetGuideOrdersAsync(guideId: Id);
                var FilteredGuideOrders = guideOrders.Where(o => o.ServiceBeginDate >= start && o.ServiceEndDate <= end);

                var hotelOrders = await GetHotelOrdersAsync(Id);
                var FilteredHotelOrders = hotelOrders.Where(o => o.CheckInDate >= start && o.CheckOutDate <= end);

                var scenicOrders = await GetScenicOrdersAsync(Id);
                var FilteredScenicOrders = scenicOrders.Where(o => o.TicketDate >= start && o.TicketDate <= end);

                var tourOrders = await GetTourOrdersAsync(guideId: Id);
                var FilteredTourOrders = tourOrders.Where(o => o.StartDate >= start && o.EndDate <= end);

                var vehicleOrders = await GetVehicleOrdersAsync(Id);
                var FilteredVehicleOrders = vehicleOrders.Where(o => o.TicketDepartureTime >= start && o.TicketArrivalTime <= end);

                orders.AddRange(FilteredGuideOrders);
                orders.AddRange(FilteredHotelOrders);
                orders.AddRange(FilteredScenicOrders);
                orders.AddRange(FilteredTourOrders);
                orders.AddRange(FilteredVehicleOrders);
            }
            else
            {
                var guideOrders = await GetGuideOrdersAsync(guideId: Id);
                var FilteredGuideOrders = guideOrders.Where(o => o.ServiceBeginDate >= start && o.ServiceEndDate <= end);

                var tourOrders = await GetTourOrdersAsync(guideId: Id);
                var FilteredTourOrders = tourOrders.Where(o => o.StartDate >= start && o.EndDate <= end);

                orders.AddRange(FilteredGuideOrders);
                orders.AddRange(FilteredTourOrders);
            }

            return orders;
        }

        /*--创建一个订单--*/
        public async Task<OrderDatum> CreateOrderAsync(OrderDatum orderData)
        {
            _context.OrderData.Add(orderData);
            await _context.SaveChangesAsync();
            return orderData;
        }
    }
}
