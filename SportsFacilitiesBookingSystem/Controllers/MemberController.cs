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

        // GET (Member/SignIn)
        public IActionResult SignIn()
        {
            return View();
        }

        // POST (Member/SignIn)
        [HttpPost]
        public IActionResult SignIn(string MemberEmail, string MemberPassword)
        {
            var member = _context.Members.FirstOrDefault(m => m.MemberEmail == MemberEmail && m.MemberPassword == MemberPassword);

            if (member != null)
            {
                HttpContext.Session.SetInt32("MemberId", member.MemberId);
                HttpContext.Session.SetString("MemberName", member.MemberName);
                TempData["SuccessMessage"] = $"Welcome back, {member.MemberName}!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Incorrect email or password. Please try again.";
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}