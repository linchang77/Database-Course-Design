using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class TourGroup
{
    public byte GroupId { get; set; }

    public byte? GuideId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? GroupName { get; set; }

    public decimal? GroupPrice { get; set; }

    public decimal? GoTicketId { get; set; }

    public decimal? ReturnTicketId { get; set; }

    public string? Departure { get; set; }

    public string? Destination { get; set; }

    public virtual VehicleTicket? GoTicket { get; set; }

    public virtual Guide? Guide { get; set; }

    public virtual VehicleTicket? ReturnTicket { get; set; }

    public virtual ICollection<TourItinerary> TourItineraries { get; set; } = new List<TourItinerary>();

    public virtual ICollection<TourOrder> TourOrders { get; set; } = new List<TourOrder>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
