using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class City
{
    public string CityName { get; set; } = null!;

    public string? Province { get; set; }

    public string? CityIntroduction { get; set; }

    public virtual Climate? Climate { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<ScenicSpot> ScenicSpots { get; set; } = new List<ScenicSpot>();

    public virtual ICollection<VehicleSchedule> VehicleScheduleArrivalCityNavigations { get; set; } = new List<VehicleSchedule>();

    public virtual ICollection<VehicleSchedule> VehicleScheduleDepartureCityNavigations { get; set; } = new List<VehicleSchedule>();

    public virtual ICollection<VehicleTicket> VehicleTicketTicketArrivalCityNavigations { get; set; } = new List<VehicleTicket>();

    public virtual ICollection<VehicleTicket> VehicleTicketTicketDepartureCityNavigations { get; set; } = new List<VehicleTicket>();
}
