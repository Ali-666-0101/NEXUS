using Microsoft.AspNetCore.Mvc;
using NEXUS.Models;
using System.Linq;


namespace NEXUS.Controllers.WEB
{
    public class WEBController : Controller
    {
        private readonly NEXUSContext _context;
        public WEBController(NEXUSContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Price()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginSubmit(Login log)
        {
			var user = _context.Registrations.FirstOrDefault(u => u.UserName == log.UserName);

			if (user == null || user.Password != log.Password) 
			{
				TempData["error"] = "the credential is invalid";
			}
            if(user != null)
            {
			    HttpContext.Session.SetString("UserName", user.UserName);
            }

			return RedirectToAction("CustomarPannal", "Home");
		}

		//Registration api 
		[HttpPost]
        public IActionResult Register(Registration registration)
        {
            if (_context.Registrations.Any(r => r.UserName == registration.UserName))
            {
                return BadRequest("Username already exists");
            }

            if (_context.Registrations.Any(r => r.Email == registration.Email))
            {
                return BadRequest("Email already exists");
            }

            _context.Registrations.Add(registration);
            _context.SaveChanges();

			HttpContext.Session.SetInt32("UserId", registration.Id);
            if(registration.UserName != null) 
            { 
			    HttpContext.Session.SetString("UserName", registration.UserName);
            }
			

			return RedirectToAction("Login");
        }

    }
}
