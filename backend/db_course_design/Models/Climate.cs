using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Climate
{
    public string CityName { get; set; } = null!;

    public decimal? TodayTemperature { get; set; }

    public string? TodayWeather { get; set; }

    public decimal? TomorrowTemperature { get; set; }

    public string? TomorrowWeather { get; set; }

    public virtual City CityNameNavigation { get; set; } = null!;
}
