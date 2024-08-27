using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class VehiclePassenger
{
    public int OrderId { get; set; }

    public string PassengerId { get; set; } = null!;

    public string? PassengerName { get; set; }

    public virtual VehicleOrder Order { get; set; } = null!;
}
