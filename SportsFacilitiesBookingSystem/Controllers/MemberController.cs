using Microsoft.AspNetCore.Mvc;
using SportsFacilitiesBookingSystem.Models;

namespace SportsFacilitiesBookingSystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly SportsBookingDBContext _context;

        public MemberController(SportsBookingDBContext context)
        {
            _context = context;
        }

        // GET (Member/Register)
        public IActionResult Register()
        {
            return View();
        }

        // POST (Member/Register)
        [HttpPost]
        public IActionResult Register(Member member)
        {
            if (ModelState.IsValid)
            {
                int nextId = _context.Members.Any() ? _context.Members.Max(m => m.MemberId) + 1 : 1;
                member.MemberId = nextId;
                member.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
                _context.Members.Add(member);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Account created successfully! You can now sign in.";
                return RedirectToAction("Index", "Home");
            }
            return View(member);
        }
    }
}