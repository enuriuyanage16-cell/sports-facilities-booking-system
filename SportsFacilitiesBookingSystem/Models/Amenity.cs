using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Amenity
{
    public int AmenityId { get; set; }

    public string AmenityName { get; set; } = null!;

    public virtual ICollection<Facility> FacilityFacilities { get; set; } = new List<Facility>();
}
