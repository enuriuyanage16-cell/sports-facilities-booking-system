using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Inquiry
{
    public int InquiryId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public string InquiryMessage { get; set; } = null!;

    public DateOnly InquiryDate { get; set; }

    public int? FacilityFacilityId { get; set; }

    public virtual Facility? FacilityFacility { get; set; }
}
