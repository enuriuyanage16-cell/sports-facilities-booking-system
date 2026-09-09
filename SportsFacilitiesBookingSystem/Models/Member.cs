using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string MemberName { get; set; } = null!;

    public string MemberPhoneNumber { get; set; } = null!;

    public string MemberEmail { get; set; } = null!;

    public string MemberAddress { get; set; } = null!;

    public string MemberPassword { get; set; } = null!;

    public DateOnly DateRegistered { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Sport> SportSports { get; set; } = new List<Sport>();
}
