using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class VehicleOrder
{
    public int OrderId { get; set; }

    public decimal? TicketId { get; set; }

    public virtual OrderDatum Order { get; set; } = null!;

    public virtual VehicleTicket? Ticket { get; set; }

    public virtual ICollection<VehiclePassenger> VehiclePassengers { get; set; } = new List<VehiclePassenger>();
}
