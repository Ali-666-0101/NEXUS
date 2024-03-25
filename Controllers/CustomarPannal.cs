using Microsoft.AspNetCore.Mvc;
using NEXUS.Models;

namespace NEXUS.Controllers
{
	public class CustomarPannal : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();

            return RedirectToAction("Index", "WEB");
        }

        [HttpPost]
        public IActionResult ServicesRegistration(ServicesRequestModel model)
        {
            return Json("noghting");
        }
    }
}
