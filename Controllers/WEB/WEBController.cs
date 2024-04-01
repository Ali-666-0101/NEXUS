using Microsoft.AspNetCore.Mvc;
using NEXUS.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
            var user = _context.Registers.FirstOrDefault(u => u.UserName == log.UserName);

            if (user == null || user.Password != log.Password)
            {
                TempData["error"] = "the credential is invalid";
                return RedirectToAction("Registration", "WEBController");
            }
            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.UserName);
            }
			if (!string.IsNullOrEmpty(log.UserName) && user != null)
			{
				HttpContext.Session.SetString("UserName", log.UserName);
				HttpContext.Session.SetInt32("UserId", user.Id);
			}

			return RedirectToAction("Index", "CustomarPannal");
        }

        //Registration api
        [HttpPost]
		public IActionResult Register(Register registration)
		{
			if (registration == null)
			{
				return BadRequest("Registration data is null");
			}

			var usernameExists = _context.Registers.Any(r => r.UserName == registration.UserName);
			var emailExists = _context.Registers.Any(r => r.Email == registration.Email);

			if (usernameExists)
			{
				return BadRequest("Username already exists");
			}

			if (emailExists)
			{
				return BadRequest("Email already exists");
			}
            

			_context.Registers.Add(registration);
			_context.SaveChanges();
            

			

			// Redirect to the appropriate page after successful registration
			return RedirectToAction("Login");
		}

        public IActionResult ContectPost(Contect model)
        {
            _context.Contects.Add(model);
            _context.SaveChanges();
            TempData["M"] = "Massege sent Success";
            return RedirectToAction("Contact");
        }


    }
}
