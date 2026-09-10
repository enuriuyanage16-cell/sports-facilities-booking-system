using Microsoft.AspNetCore.Mvc;
using SportsFacilitiesBookingSystem.Models;

namespace SportsFacilitiesBookingSystem.Controllers
{
    public class ReviewController : Controller
    {
        private readonly SportsBookingDBContext _context;

        public ReviewController(SportsBookingDBContext context)
        {
            _context = context;
        }

        // GET (Review/Create)
        public IActionResult Create()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberId");
            if (memberId == null)
            {
                TempData["SuccessMessage"] = "Please sign in to leave a review.";
                return RedirectToAction("SignIn", "Member");
            }

            var myBookings = _context.Bookings
                .Where(b => b.MemberMemberId == memberId && b.Status == "Confirmed")
                .Select(b => b.FacilityFacilityId)
                .Distinct()
                .ToList();

            var facilities = _context.Facilities
                .Where(f => myBookings.Contains(f.FacilityId))
                .ToList();

            ViewBag.Facilities = facilities;
            return View();
        }

        // POST (Review/Create)
        [HttpPost]
        public IActionResult Create(int facilityId, int rating, string? comment)
        {
            int? memberId = HttpContext.Session.GetInt32("MemberId");
            if (memberId == null)
            {
                return RedirectToAction("SignIn", "Member");
            }

            bool hasBooked = _context.Bookings.Any(b =>
                b.MemberMemberId == memberId && b.FacilityFacilityId == facilityId && b.Status == "Confirmed");

            if (!hasBooked)
            {
                TempData["SuccessMessage"] = "You can only review facilities you have booked.";
                return RedirectToAction("Create");
            }

            int nextReviewId = _context.Reviews.Any() ? _context.Reviews.Max(r => r.ReviewId) + 1 : 1;

            var review = new Review
            {
                ReviewId = nextReviewId,
                Rating = rating,
                Comment = comment,
                ReviewDate = DateOnly.FromDateTime(DateTime.Now),
                MemberMemberId = memberId.Value,
                FacilityFacilityId = facilityId
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Thank you! Your review has been submitted.";
            return RedirectToAction("Index", "Home");
        }
    }
}