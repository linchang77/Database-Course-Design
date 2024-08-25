using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace db_course_design.Services.impl
{
    public class HotelService : IHotelService
    {
        /*--上下文连接数据库--*/
        private readonly ModelContext _context;

        public HotelService(ModelContext context)
        {
            _context = context;
        }

        /*--根据城市获取酒店信息--*/
        public async Task<List<HotelResponse>> GetHotelByCityAsync(string city)
        {
            var query = _context.Hotels.AsQueryable();
            query = query.Where(o => o.CityName.Equals(city, StringComparison.OrdinalIgnoreCase));

            var Hotels = await query
                .Select(o => new HotelResponse
                {
                    HotelId = (int)o.HotelId,
                    HotelName = o.HotelName,
                    CityName = city,
                    HotelGrade = o.HotelGrade,
                    HotelLocation = o.HotelLocation,
                    HotelIntroduction = o.HotelIntroduction,
                }).ToListAsync();
            return Hotels;
        }
        /*--返回某酒店各种房型剩余房间数和房型价格--*/
        public async Task<List<HotelRoomDetail>> GetHotelRoomDetailsAsync(int hotelId)
        {
            var query = _context.HotelRoomTypes.AsQueryable();
            query = query.Where(o => o.HotelId == hotelId);

            var RoomDetail = await query
                .Select(o => new HotelRoomDetail
                {
                    HotelId = (int)o.HotelId,
                    RoomType = o.RoomType,
                    RoomPrice = o.RoomPrice,
                    RoomLeft = o.RoomLeft,
                }).ToListAsync();
            return RoomDetail;
        }
        /*--创建一个酒店订单并分配房间--*/
        public async Task<CreateHotelOrderResponse> CreateHotelOrderAsync(CreateHotelOrderRequest request)
        {
            var query = from h in _context.Hotels
                        join room in _context.HotelRooms on h.HotelId equals room.HotelId
                        join rt in _context.HotelRoomTypes on h.HotelId equals rt.HotelId
                        where h.HotelId == request.HotelId
                            && room.RoomType == request.RoomType
                            && room.RoomClear == true
                        select new
                        {
                            RoomType = room.RoomType,
                            RoomPrice = rt.RoomPrice,
                            CityName = h.CityName,
                            HotelName = h.HotelName,
                            HotelLocation = h.HotelLocation,
                            RoomNumber = room.RoomNumber,
                        };
            // 这里要使用 await 等待异步查询结果
            var response = await query.FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }

            // 查找到符合条件的房间，将其RoomClear置为false
            var roomToUpdate = await _context.HotelRooms.FindAsync(response.RoomNumber);
            if (roomToUpdate != null)
            {
                roomToUpdate.RoomClear = false;
                _context.HotelRooms.Update(roomToUpdate);
            }

            // 减少剩余房间的数量
            var rtToUpdate = await _context.HotelRoomTypes.FindAsync(response.RoomType);
            if (rtToUpdate != null) 
            {  
                rtToUpdate.RoomLeft--;
                _context.HotelRoomTypes.Update(rtToUpdate);
            }

            // 添加数据到Hotel_Order表，Order_Data的同步在控制器层
            var roomDetail = new HotelOrder
            {
                HotelId = request.HotelId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                RoomNumber = response.RoomNumber,
            };
            _context.HotelOrders.Add(roomDetail);
            await _context.SaveChangesAsync();

            // 给响应类赋值
            var rsp = new CreateHotelOrderResponse();
            rsp.RoomType = response.RoomType;
            rsp.RoomPrice = response.RoomPrice;
            rsp.CityName = response.CityName;
            rsp.HotelName = response.HotelName;
            rsp.HotelLocation = response.HotelLocation;
            rsp.RoomNumber = response.RoomNumber;
            return rsp;
        }
        /*--删除一个酒店订单--*/

    }
}
