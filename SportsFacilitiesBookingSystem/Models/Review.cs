using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateOnly ReviewDate { get; set; }

    public int MemberMemberId { get; set; }

    public int FacilityFacilityId { get; set; }

    public virtual Facility FacilityFacility { get; set; } = null!;

    public virtual Member MemberMember { get; set; } = null!;
}
