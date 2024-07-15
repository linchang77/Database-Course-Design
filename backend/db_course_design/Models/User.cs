using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public DateTime? RegistrationTime { get; set; }

    public string? Password { get; set; }

    public string? ProfilePicture { get; set; }

    public string? UserGender { get; set; }

    public virtual ICollection<OrderDatum> OrderData { get; set; } = new List<OrderDatum>();

    public virtual ICollection<UserPhoneNumber> UserPhoneNumbers { get; set; } = new List<UserPhoneNumber>();

    public virtual ICollection<TourGroup> Groups { get; set; } = new List<TourGroup>();
}
