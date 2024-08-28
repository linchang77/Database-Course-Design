using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using db_course_design.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;
using db_course_design.Profiles;
using db_course_design.Common;

namespace db_course_design.Services.impl
{
    public class HotelService : IHotelService
    {
        /*--上下文连接数据库--*/
        private readonly ModelContext _context;

        public IMapper _mapper { get; }

        public HotelService(ModelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<HotelProfile>()).CreateMapper();
        }

        /*--返回所有酒店信息--*/
        public async Task<List<HotelResponse>> GetAllHotelsAsync()
        {
            return await _context.Hotels.Select(h => _mapper.Map<HotelResponse>(h)).ToListAsync();
        }
        /*--根据城市获取酒店信息--*/
        public async Task<List<HotelResponse>> GetHotelByCityAsync(string city)
        {
            var query = _context.Hotels.AsQueryable();
            query = query.Where(o => o.CityName.Equals(city));

            var Hotels = await query
                .Select(o => _mapper.Map<HotelResponse>(o)).ToListAsync();
            return Hotels;
        }
        /*--返回某酒店各种房型剩余房间数和房型价格--*/
        public async Task<List<HotelRoomDetail>> GetHotelRoomDetailsAsync(int hotelId)
        {
            var query = _context.HotelRoomTypes.AsQueryable();
            query = query.Where(o => o.HotelId == hotelId);

            var RoomDetail = await query
                .Select(o => _mapper.Map<HotelRoomDetail>(o)).ToListAsync();
            return RoomDetail;
        }
        /*--返回某酒店所有房间信息--*/
        public async Task<List<HotelRoomResponse>> GetAllHotelRoomsAsync(int hotelId, string roomType)
        {
            var detail = (await _context.HotelRoomTypes
                .Where(t => t.HotelId == hotelId && t.RoomType == roomType)
                .Include(t => t.HotelRooms)
                .ToListAsync()).SingleOrDefault();

            if (detail == null)
                return new List<HotelRoomResponse>();
            return detail.HotelRooms.Select(r => _mapper.Map<HotelRoomResponse>(r)).ToList();
        }
        /*--创建一个酒店订单并分配房间--*/
        public async Task<CreateHotelOrderResponse?> CreateHotelOrderAsync(CreateHotelOrderRequest request)
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

            // 添加数据到Hotel_Order表，并同步Order_Data
            var roomDetail = new HotelOrder
            {
                HotelId = request.HotelId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                RoomNumber = response.RoomNumber,
            };
            var orderDatum = new OrderDatum
            {
                OrderType = "hotel",
                OrderDate = DateTime.Now,
                UserId = request.userId,
                Status = "Pending",
                Price = response.RoomPrice,
            };
            _context.HotelOrders.Add(roomDetail);
            _context.OrderData.Add(orderDatum);
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

        /*--添加酒店--*/
        public async Task<HotelResponse?> AddHotelAsync(HotelRequest request)
        {
            try
            {
                var record = _mapper.Map<Hotel>(request);
                _context.Hotels.Add(record);
                await _context.SaveChangesAsync();
                return _mapper.Map<HotelResponse>(record);
            }
            catch
            {
                return null;
            }
        }
        /*--删除酒店--*/
        public async Task<bool> DeleteHotelAsync(decimal hotelId)
        {
            var target = await _context.Hotels.FindAsync(hotelId);

            if (target == null) 
                return false;

            _context.Hotels.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }
        /*--更新酒店--*/
        public async Task<HotelResponse?> UpdateHotelAsync(HotelResponse request)
        {
            var target = await _context.Hotels.FindAsync(request.HotelId);

            if (target == null) 
                return null;

            target.HotelName = request.HotelName;
            target.CityName = request.CityName;
            target.HotelGrade = request.HotelGrade;
            target.HotelLocation = request.HotelLocation;
            target.HotelIntroduction = request.HotelIntroduction;
            await _context.SaveChangesAsync();

            return _mapper.Map<HotelResponse>(target);
        }
        /*--添加酒店房型--*/
        public async Task<HotelRoomDetail?> AddHotelRoomTypeAsync(HotelRoomTypeRequest request)
        {
            try
            {
                var record = _mapper.Map<HotelRoomType>(request);
                _context.HotelRoomTypes.Add(record);
                await _context.SaveChangesAsync();
                return _mapper.Map<HotelRoomDetail>(record);
            }
            catch
            {
                return null;
            }
        }
        /*--删除酒店房型--*/
        public async Task<bool> DeleteHotelRoomTypeAsync(decimal hotelId, string roomType)
        {
            var target = await _context.HotelRoomTypes.FindAsync(hotelId, roomType);

            if (target == null) 
                return false;

            _context.HotelRoomTypes.Remove(target);
            await _context.SaveChangesAsync(); 
            return true;
        }
        /*--更新酒店房型--*/
        public async Task<HotelRoomDetail?> UpdateHotelRoomTypeAsync(HotelRoomDetail request)
        {
            var target = await _context.HotelRoomTypes.FindAsync(request.HotelId, request.RoomType);

            if (target == null)
                return null;

            target.RoomPrice = request.RoomPrice;
            target.RoomLeft = request.RoomLeft;
            await _context.SaveChangesAsync();

            return _mapper.Map<HotelRoomDetail>(target);
        }
        /*--添加酒店房间--*/
        public async Task<HotelRoomResponse?> AddHotelRoomAsync(HotelRoomRequest request)
        {
            try
            {
                var record = _mapper.Map<HotelRoom>(request);
                _context.HotelRooms.Add(record);
                await _context.SaveChangesAsync();
                return _mapper.Map<HotelRoomResponse>(record);
            }
            catch
            {
                return null;
            }
        }
        /*--删除酒店房间--*/
        public async Task<bool> DeleteHotelRoomAsync(string roomNumber, decimal hotelId)
        {
            var target = await _context.HotelRooms.FindAsync(roomNumber, hotelId);

            if (target == null) 
                return false;

            _context.HotelRooms.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }
        /*--更新酒店房间--*/
        public async Task<HotelRoomResponse?> UpdateHotelRoomAsync(HotelRoomResponse request)
        {
            var target = await _context.HotelRooms.FindAsync(request.RoomNumber, request.HotelId);

            if (target == null) 
                return null;

            target.RoomType = request.RoomType;
            target.RoomClear = request.RoomClear;
            await _context.SaveChangesAsync();

            return _mapper.Map<HotelRoomResponse>(target);
        }
    }
}
