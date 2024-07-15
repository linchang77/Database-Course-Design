using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class VehicleSchedule
{
    public string? ArrivalCity { get; set; }

    public string VehicleId { get; set; } = null!;

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public string? VehicleType { get; set; }

    public string? DepartureCity { get; set; }

    public virtual City? ArrivalCityNavigation { get; set; }

    public virtual City? DepartureCityNavigation { get; set; }

    public virtual ICollection<VehicleTicket> VehicleTickets { get; set; } = new List<VehicleTicket>();
}
