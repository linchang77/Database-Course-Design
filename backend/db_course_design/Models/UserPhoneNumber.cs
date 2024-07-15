using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class UserPhoneNumber
{
    public int UserId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
