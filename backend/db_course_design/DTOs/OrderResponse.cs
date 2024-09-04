using db_course_design.Services.impl;

namespace db_course_design.DTOs
{
    /*--封装订单返回属性的类--*/
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public string OrderType { get; set; }
        public string Status { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Price { get; set; }
    }
    public class GuideOrderDetail : OrderResponse
    {
        public DateTime? ServiceBeginDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public string Service { get; set; }
        public byte GuideId { get; set; }
        public string GuideName { get; set; }
        public string GuideGender { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
    }
    public class HotelOrderDetail : OrderResponse
    {
        public string? CityName { get; set; }
        public string? HotelName { get; set; }
        public string? HotelLocation { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string RoomType { get; set; }
        public string RoomNumber { get; set; }
    }
    public class ScenicOrderDetail : OrderResponse
    {
        public string? CityName { get; set; }
        public string ScenicSpotName { get; set; }
        public string TicketType { get; set; }
        public decimal? TicketNumber { get; set; }
        public DateTime TicketDate { get; set; }
    }
    public class TourOrderDetail : OrderResponse
    {
        public byte? GroupId { get; set; }
        public string? GroupName { get; set; }  // 建议名字起旅行目的地
        public byte? GuideId { get; set; }
        public string GuideName { get; set; }
        public string GuideGender { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public decimal? OrderNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class VehicleOrderDetail : OrderResponse
    {
        public string? VehicleId { get; set; }
        public string? VehicleType { get; set; }
        public decimal TicketId { get; set; }
        public string? TicketType { get; set; }
        public virtual ICollection<VehiclePassengerRequest> Passengers { get; set; } = new List<VehiclePassengerRequest>();
        public DateTime? TicketDepartureTime { get; set; }
        public DateTime? TicketArrivalTime { get; set; }
        public string? TicketDepartureCity { get; set; }
        public string? TicketArrivalCity { get; set; }
        public string? TicketDepartureStation { get; set; }
        public string? TicketArrivalStation { get; set; }
    }
}
