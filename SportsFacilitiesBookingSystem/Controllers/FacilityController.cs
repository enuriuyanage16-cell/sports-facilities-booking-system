using Microsoft.AspNetCore.Mvc;
using SportsFacilitiesBookingSystem.Models;

namespace SportsFacilitiesBookingSystem.Controllers
{
    public class FacilityController : Controller
    {
        private readonly SportsBookingDBContext _context;

        public FacilityController(SportsBookingDBContext context)
        {
            _context = context;
        }

        // GET (Facility/Search)
        public IActionResult Search(string? facilityType, string? location, DateOnly? searchDate, TimeOnly? startTime, TimeOnly? endTime)
        {
            if (HttpContext.Session.GetInt32("MemberId") == null)
            {
                TempData["SuccessMessage"] = "Please sign in to search facilities.";
                return RedirectToAction("SignIn", "Member");
            }

            var facilities = _context.Facilities.AsQueryable();

            if (!string.IsNullOrEmpty(facilityType))
            {
                facilities = facilities.Where(f => f.FacilityType.Contains(facilityType));
            }

            if (!string.IsNullOrEmpty(location))
            {
                facilities = facilities.Where(f => f.FacilityLocation.Contains(location));
            }

            facilities = facilities.Where(f => f.FacilityAvailabilityStatus == "Available");

            if (searchDate != null && startTime != null && endTime != null)
            {
                var bookedFacilityIds = _context.Bookings
                    .Where(b => b.BookingDate == searchDate
                        && (b.Status == "Confirmed" || b.Status == "Pending")
                        && b.StartTime < endTime && b.EndTime > startTime)
                    .Select(b => b.FacilityFacilityId);

                facilities = facilities.Where(f => !bookedFacilityIds.Contains(f.FacilityId));
            }

            return View(facilities.ToList());
        }

        // GET (Facility/RestrictedSearch)
        public IActionResult RestrictedSearch(string? facilityType, DateOnly? searchDate, TimeOnly? startTime, TimeOnly? endTime)
        {
            var facilities = _context.Facilities.AsQueryable();

            if (!string.IsNullOrEmpty(facilityType))
            {
                facilities = facilities.Where(f => f.FacilityType.Contains(facilityType));
            }

            facilities = facilities.Where(f => f.FacilityAvailabilityStatus == "Available");

            if (searchDate != null && startTime != null && endTime != null)
            {
                var bookedFacilityIds = _context.Bookings
                    .Where(b => b.BookingDate == searchDate
                        && (b.Status == "Confirmed" || b.Status == "Pending")
                        && b.StartTime < endTime && b.EndTime > startTime)
                    .Select(b => b.FacilityFacilityId);

                facilities = facilities.Where(f => !bookedFacilityIds.Contains(f.FacilityId));
            }

            return View(facilities.ToList());
        }

        // GET (Facility/Book/5)
        public IActionResult Book(int id)
        {
            if (HttpContext.Session.GetInt32("MemberId") == null)
            {
                TempData["SuccessMessage"] = "Please sign in to book a facility.";
                return RedirectToAction("SignIn", "Member");
            }

            var facility = _context.Facilities.Find(id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // POST (Facility/Book)
        [HttpPost]
        public IActionResult Book(int facilityId, DateOnly bookingDate, TimeOnly startTime, TimeOnly endTime, decimal amount, string paymentMethod)
        {
            int? memberId = HttpContext.Session.GetInt32("MemberId");
            if (memberId == null)
            {
                return RedirectToAction("SignIn", "Member");
            }

            if (endTime <= startTime)
            {
                TempData["SuccessMessage"] = "End time must be after start time.";
                return RedirectToAction("Search");
            }

            bool isOverlapping = _context.Bookings.Any(b =>
                b.FacilityFacilityId == facilityId
                && b.BookingDate == bookingDate
                && (b.Status == "Confirmed" || b.Status == "Pending")
                && b.StartTime < endTime && b.EndTime > startTime);

            if (isOverlapping)
            {
                TempData["SuccessMessage"] = "Sorry, that time slot is no longer available.";
                return RedirectToAction("Search");
            }

            int nextBookingId = _context.Bookings.Any() ? _context.Bookings.Max(b => b.BookingId) + 1 : 1;

            var booking = new Booking
            {
                BookingId = nextBookingId,
                BookingDate = bookingDate,
                StartTime = startTime,
                EndTime = endTime,
                Status = "Confirmed",
                MemberMemberId = memberId.Value,
                FacilityFacilityId = facilityId
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            int nextPaymentId = _context.Payments.Any() ? _context.Payments.Max(p => p.PaymentId) + 1 : 1;

            var payment = new Payment
            {
                PaymentId = nextPaymentId,
                Amount = amount,
                PaymentDate = DateOnly.FromDateTime(DateTime.Now),
                PaymentMethod = paymentMethod,
                PaymentStatus = "Paid",
                BookingBookingId = booking.BookingId
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Booking confirmed! Your payment was successful.";
            return RedirectToAction("Index", "Home");
        }
    }
}