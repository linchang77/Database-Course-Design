using db_course_design.Services.impl;

namespace db_course_design.DTOs
{
    public class HotelResponse
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string CityName { get; set; }
        public string HotelGrade { get; set; }
        public string HotelLocation { get; set; }
        public string HotelIntroduction { get; set; }
    }
    public class HotelRoomDetail
    {
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public int RoomLeft { get; set; }
        public decimal? RoomPrice { get; set; }
    }
    // 接收类
    public class CreateHotelOrderRequest
    {
        public int userId { get; set; }
        public int HotelId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string RoomType { get; set; }
    }
    // 响应类
    public class CreateHotelOrderResponse
    {
        public string RoomType { get; set; }
        public decimal? RoomPrice { get; set; }
        public string CityName { get; set; }
        public string HotelName { get; set; }
        public string HotelLocation { get; set; }
        public string RoomNumber { get; set; }
    }
}
