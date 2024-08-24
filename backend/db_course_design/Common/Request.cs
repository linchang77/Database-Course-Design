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

}
