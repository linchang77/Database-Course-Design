using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class TourItinerary
{
    public decimal ItineraryId { get; set; }

    public byte? GroupId { get; set; }

    public DateTime? ItineraryTime { get; set; }

    public TimeSpan? ItineraryDuration { get; set; }

    public decimal? ScenicSpotId { get; set; }

    public string? Activities { get; set; }

    public virtual TourGroup? Group { get; set; }

    public virtual ScenicSpot? ScenicSpot { get; set; }
}
