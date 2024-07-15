using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class TourItinerary
{
    public byte ItineraryId { get; set; }

    public byte? GroupId { get; set; }

    public DateTime? ItineraryTime { get; set; }

    public TimeSpan? ItineraryDuration { get; set; }

    public string? Location { get; set; }

    public string? Activities { get; set; }

    public virtual TourGroup? Group { get; set; }
}
