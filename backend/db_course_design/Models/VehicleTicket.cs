using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class VehicleTicket
{
    public string VehicleId { get; set; } = null!;

    public string TicketType { get; set; } = null!;

    public decimal? TicketPrice { get; set; }

    public DateTime? TicketDepartureTime { get; set; }

    public DateTime? TicketArrivalTime { get; set; }

    public string? TicketDepartureCity { get; set; }

    public string? TicketArrivalCity { get; set; }

    public decimal TicketId { get; set; }

    public decimal? TicketRemaining { get; set; }

    public virtual City? TicketArrivalCityNavigation { get; set; }

    public virtual City? TicketDepartureCityNavigation { get; set; }

    public virtual VehicleSchedule Vehicle { get; set; } = null!;

    public virtual ICollection<VehicleOrder> VehicleOrders { get; set; } = new List<VehicleOrder>();
}
