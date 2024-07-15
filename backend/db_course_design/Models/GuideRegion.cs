using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class GuideRegion
{
    public byte GuideId { get; set; }

    public string GuidedRegion { get; set; } = null!;

    public virtual Guide Guide { get; set; } = null!;
}
