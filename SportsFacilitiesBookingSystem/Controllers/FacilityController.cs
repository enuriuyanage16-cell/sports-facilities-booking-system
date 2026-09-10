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
        public IActionResult Search(string? facilityType, DateOnly? searchDate, TimeOnly? startTime, TimeOnly? endTime)
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
    }
}