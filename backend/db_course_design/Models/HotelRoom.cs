using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class HotelRoom
{
    public string RoomNumber { get; set; } = null!;

    public decimal HotelId { get; set; }

    public decimal? RoomPrice { get; set; }

    public string? RoomType { get; set; }

    public bool? RoomClear { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<HotelOrder> HotelOrders { get; set; } = new List<HotelOrder>();
}
