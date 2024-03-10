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
            // add git commit i n this repo
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
    }
}
