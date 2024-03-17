using Microsoft.AspNetCore.Mvc;

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
    }
}
