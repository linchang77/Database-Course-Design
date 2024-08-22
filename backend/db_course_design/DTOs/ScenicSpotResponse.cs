﻿using EntityFramework.Models;

namespace db_course_design.DTOs
{
    public class ScenicSpotResponse
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
    public class ScenicSpotTicketResponse
    {
        public decimal ScenicSpotId { get; set; }

        public string TicketType { get; set; } = null!;

        public decimal? TicketPrice { get; set; }

        public decimal? TicketRemaining { get; set; }

        public DateTime TicketDate { get; set; }

        public virtual ScenicSpot ScenicSpot { get; set; } = null!;

        public virtual ICollection<ScenicSpotOrder> ScenicSpotOrders { get; set; } = new List<ScenicSpotOrder>();
    }

    public class AdultChildTicketResponse
    {
        public ScenicSpotTicketResponse AdultTicket;

        public ScenicSpotTicketResponse ChildTicket;
    }
}