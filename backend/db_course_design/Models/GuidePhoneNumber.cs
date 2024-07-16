using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class GuidePhoneNumber
{
    public string PhoneNumber { get; set; } = null!;

    public byte GuideId { get; set; }

    public virtual Guide Guide { get; set; } = null!;
}
