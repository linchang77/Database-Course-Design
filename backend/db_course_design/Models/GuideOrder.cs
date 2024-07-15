using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class GuideOrder
{
    public int OrderId { get; set; }

    public byte? GuideId { get; set; }

    public DateTime? ServiceBeginDate { get; set; }

    public string? Service { get; set; }

    public DateTime? ServiceEndDate { get; set; }

    public virtual Guide? Guide { get; set; }

    public virtual OrderDatum Order { get; set; } = null!;
}
