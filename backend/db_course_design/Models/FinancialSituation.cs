using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class FinancialSituation
{
    public decimal FinancialRecordId { get; set; }

    public DateTime? RecordingDate { get; set; }

    public decimal? Income { get; set; }

    public decimal? Expence { get; set; }

    public decimal? Profit { get; set; }

    public string? FinancialRecordCategory { get; set; }

    public string? FinancialRecordDescription { get; set; }
}
