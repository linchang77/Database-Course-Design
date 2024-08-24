namespace db_course_design.Common
{
    //订单创建请求模型
    public class CreateOrderRequest
    {
        public string? OrderType { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
    }
    public class CreateScenicSpotOrderRequest
    {
        public DateTime? OrderDate { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
    }
    public class SearchTourGroupRequest
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime? Departure_Time { get; set; }
        public int Days_of_Travel { get; set; }
    }
}