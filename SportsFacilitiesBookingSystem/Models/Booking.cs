using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public DateOnly BookingDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string Status { get; set; } = null!;

    public int MemberMemberId { get; set; }

    public int FacilityFacilityId { get; set; }

    public virtual Facility FacilityFacility { get; set; } = null!;

    public virtual Member MemberMember { get; set; } = null!;

    public virtual Payment? Payment { get; set; }
}
