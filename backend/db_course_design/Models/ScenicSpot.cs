using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class ScenicSpot
{
    public string? ScenicSpotName { get; set; }

    public decimal ScenicSpotId { get; set; }

    public string? CityName { get; set; }

    public string? ScenicSpotGrade { get; set; }

    public string? ScenicSpotIntroduction { get; set; }

    public string? ScenicSpotLocation { get; set; }

    public virtual City? CityNameNavigation { get; set; }

    public virtual ICollection<ScenicSpotTicket> ScenicSpotTickets { get; set; } = new List<ScenicSpotTicket>();
}
