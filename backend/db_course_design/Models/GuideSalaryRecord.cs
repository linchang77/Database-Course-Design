using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class GuideSalaryRecord
{
    public byte GuideId { get; set; }

    public DateTime SalaryPaidDate { get; set; }

    public int? SalaryAmount { get; set; }

    public string? Description { get; set; }

    public virtual Guide Guide { get; set; } = null!;
}
