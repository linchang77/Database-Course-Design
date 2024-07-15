using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Admin
{
    public decimal AdminId { get; set; }

    public string? Password { get; set; }

    public string? AdminName { get; set; }
}
