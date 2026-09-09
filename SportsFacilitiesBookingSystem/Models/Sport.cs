using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Sport
{
    public int SportId { get; set; }

    public string SportName { get; set; } = null!;

    public virtual ICollection<Facility> FacilityFacilities { get; set; } = new List<Facility>();

    public virtual ICollection<Member> MemberMembers { get; set; } = new List<Member>();
}
