using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class VehicleOrder
{
    public decimal OrderId { get; set; }

    public decimal TicketId { get; set; }

    public decimal? TicketNumber { get; set; }

    public virtual VehicleTicket Ticket { get; set; } = null!;
}
