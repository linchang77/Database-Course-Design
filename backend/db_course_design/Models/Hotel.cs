using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Hotel
{
    public decimal HotelId { get; set; }

    public string? HotelName { get; set; }

    public string? CityName { get; set; }

    public string? HotelGrade { get; set; }

    public string? HotelLocation { get; set; }

    public string? HotelIntroduction { get; set; }

    public virtual City? CityNameNavigation { get; set; }

    public virtual ICollection<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
}
