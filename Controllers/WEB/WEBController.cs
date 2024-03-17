using Microsoft.AspNetCore.Mvc;

namespace NEXUS.Controllers.WEB
{
    public class WEBController : Controller
    {
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
        [HttpPost]
        public IActionResult Loginsubmit()
        {
            return RedirectToAction("Index");
           
        }
    }
}
