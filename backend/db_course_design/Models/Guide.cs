using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Guide
{
    public byte GuideId { get; set; }

    public string? Password { get; set; }

    public string? GuideName { get; set; }

    public string? GuideGender { get; set; }

    public string? TravelGroup { get; set; }

    public bool? GuideFree { get; set; }

    public string? GuideIntroduction { get; set; }

    public decimal? GuideSalary { get; set; }

    public string? GuidePerformanceLevel { get; set; }

    public string? GuideSeniority { get; set; }

    public decimal? GuidePrice { get; set; }

    public virtual ICollection<GuideOrder> GuideOrders { get; set; } = new List<GuideOrder>();

    public virtual ICollection<GuidePhoneNumber> GuidePhoneNumbers { get; set; } = new List<GuidePhoneNumber>();

    public virtual ICollection<GuideRegion> GuideRegions { get; set; } = new List<GuideRegion>();

    public virtual ICollection<GuideSalaryRecord> GuideSalaryRecords { get; set; } = new List<GuideSalaryRecord>();

    public virtual ICollection<TourGroup> TourGroups { get; set; } = new List<TourGroup>();

    public virtual ICollection<TourGroup> Groups { get; set; } = new List<TourGroup>();
}
