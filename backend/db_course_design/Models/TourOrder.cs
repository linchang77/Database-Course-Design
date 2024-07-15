using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class TourOrder
{
    public int OrderId { get; set; }

    public byte? GroupId { get; set; }

    public decimal? OrderNumber { get; set; }

    public virtual TourGroup? Group { get; set; }

    public virtual OrderDatum Order { get; set; } = null!;
}
