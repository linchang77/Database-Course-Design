using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class HotelRoom
{
    public string RoomNumber { get; set; } = null!;

    public decimal HotelId { get; set; }

    public string? RoomType { get; set; }

    public bool? RoomClear { get; set; }

    public virtual ICollection<HotelOrder> HotelOrders { get; set; } = new List<HotelOrder>();

    public virtual HotelRoomType? HotelRoomType { get; set; }
}
