using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class HotelRoomType
{
    public decimal HotelId { get; set; }

    public string RoomType { get; set; } = null!;

    public decimal? RoomPrice { get; set; }

    public decimal? RoomLeft { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
}
