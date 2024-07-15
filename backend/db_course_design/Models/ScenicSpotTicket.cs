using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class ScenicSpotTicket
{
    public decimal ScenicSpotId { get; set; }

    public string TicketType { get; set; } = null!;

    public decimal? TicketPrice { get; set; }

    public decimal? TicketRemaining { get; set; }

    public virtual ScenicSpot ScenicSpot { get; set; } = null!;

    public virtual ICollection<ScenicSpotOrder> ScenicSpotOrders { get; set; } = new List<ScenicSpotOrder>();
}
