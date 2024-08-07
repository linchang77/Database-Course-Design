using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class ScenicSpotOrder
{
    public int OrderId { get; set; }

    public decimal ScenicSpotId { get; set; }

    public string TicketType { get; set; } = null!;

    public decimal? TicketNumber { get; set; }

    public DateTime TicketDate { get; set; }

    public virtual OrderDatum Order { get; set; } = null!;

    public virtual ScenicSpotTicket ScenicSpotTicket { get; set; } = null!;
}
