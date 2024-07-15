using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class TransactionRecord
{
    public int TransactionId { get; set; }

    public byte? UserId { get; set; }

    public DateTime? TransactionTime { get; set; }

    public decimal? Amount { get; set; }

    public string? TransactionObject { get; set; }

    public string? TransactionStatus { get; set; }

    public string? TransactionMethod { get; set; }

    public string? TransactionCategory { get; set; }

    public string? Description { get; set; }
}
