using Microsoft.AspNetCore.Mvc;
using SportsFacilitiesBookingSystem.Models;

namespace SportsFacilitiesBookingSystem.Controllers
{
    public class InquiryController : Controller
    {
        private readonly SportsBookingDBContext _context;

        public InquiryController(SportsBookingDBContext context)
        {
            _context = context;
        }

        // GET (Inquiry/Create)
        public IActionResult Create()
        {
            ViewBag.Facilities = _context.Facilities.ToList();
            return View();
        }

        // POST (Inquiry/Create)
        [HttpPost]
        public IActionResult Create(string name, string email, string contactNo, string inquiryMessage, int? facilityId)
        {
            int nextInquiryId = _context.Inquiries.Any() ? _context.Inquiries.Max(i => i.InquiryId) + 1 : 1;

            var inquiry = new Inquiry
            {
                InquiryId = nextInquiryId,
                Name = name,
                Email = email,
                ContactNo = contactNo,
                InquiryMessage = inquiryMessage,
                InquiryDate = DateOnly.FromDateTime(DateTime.Now),
                FacilityFacilityId = facilityId
            };

            _context.Inquiries.Add(inquiry);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Your inquiry has been submitted. We'll get back to you soon.";
            return RedirectToAction("Index", "Home");
        }
    }
}