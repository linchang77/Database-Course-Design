using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class VehicleOrder
{
    public int OrderId { get; set; }

    public decimal TicketId { get; set; }

    public string TicketUserName { get; set; } = null!;

    public virtual OrderDatum Order { get; set; } = null!;

    public virtual VehicleTicket Ticket { get; set; } = null!;
}
