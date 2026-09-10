using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsFacilitiesBookingSystem.Models;

public partial class Member
{
    public int MemberId { get; set; }

    [Required(ErrorMessage = "Please enter your name.")]
    [StringLength(100)]
    [Display(Name = "Full Name")]
    public string MemberName { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your phone number.")]
    [StringLength(15)]
    [Display(Name = "Phone Number")]
    public string MemberPhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(100)]
    [Display(Name = "Email")]
    public string MemberEmail { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your address.")]
    [StringLength(255)]
    [Display(Name = "Address")]
    public string MemberAddress { get; set; } = null!;

    [Required(ErrorMessage = "Please enter a password.")]
    [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string MemberPassword { get; set; } = null!;

    public DateOnly DateRegistered { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Sport> SportSports { get; set; } = new List<Sport>();
}