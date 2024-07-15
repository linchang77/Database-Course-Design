using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class HotelOrder
{
    public int OrderId { get; set; }

    public decimal HotelId { get; set; }

    public DateTime? CheckInDate { get; set; }

    public DateTime? CheckOutDate { get; set; }

    public string RoomNumber { get; set; } = null!;

    public virtual HotelRoom HotelRoom { get; set; } = null!;

    public virtual OrderDatum Order { get; set; } = null!;
}
