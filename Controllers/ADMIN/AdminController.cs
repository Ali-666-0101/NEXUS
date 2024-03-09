using Microsoft.AspNetCore.Mvc;

namespace NEXUS.Controllers.ADMIN
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
