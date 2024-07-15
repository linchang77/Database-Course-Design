using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class GuidePhoneNumber
{
    public string GuidePhoneNumber1 { get; set; } = null!;

    public byte GuideId { get; set; }

    public virtual Guide Guide { get; set; } = null!;
}
