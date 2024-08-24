using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class OrderDatum
{
    public string? OrderType { get; set; }

    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? UserId { get; set; }

    public string? Status { get; set; }

    public decimal? Price { get; set; }

    public virtual GuideOrder? GuideOrder { get; set; }

    public virtual ICollection<HotelOrder> HotelOrders { get; set; } = new List<HotelOrder>();

    public virtual ICollection<ScenicSpotOrder> ScenicSpotOrders { get; set; } = new List<ScenicSpotOrder>();

    public virtual TourOrder? TourOrder { get; set; }

    public virtual User? User { get; set; }

    public virtual VehicleOrder? VehicleOrder { get; set; }
}
