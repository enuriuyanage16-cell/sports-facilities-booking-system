using System;
using System.Collections.Generic;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public int BookingBookingId { get; set; }

    public virtual Booking BookingBooking { get; set; } = null!;
}
