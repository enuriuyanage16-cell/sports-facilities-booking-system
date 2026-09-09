using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Facility
{
    public int FacilityId { get; set; }

    public string FacilityName { get; set; } = null!;

    public string FacilityType { get; set; } = null!;

    public string FacilityLocation { get; set; } = null!;

    public int FacilityCapacity { get; set; }

    public string FacilityAvailabilityStatus { get; set; } = null!;

    public string? StatusReason { get; set; }

    public string Description { get; set; } = null!;

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Amenity> AmenityAmenities { get; set; } = new List<Amenity>();

    public virtual ICollection<Sport> SportSports { get; set; } = new List<Sport>();
}
