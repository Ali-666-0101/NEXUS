using Microsoft.AspNetCore.Mvc;
using NEXUS.Models;

namespace NEXUS.Controllers.ADMIN
{
	public class AdminController : Controller
	{
		private readonly NEXUSContext _context;
		public AdminController(NEXUSContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult BroadbandConnections()
		{
			var data = _context.BroadbandConnections.ToList();
			return View(data);
		}
		public IActionResult Customers()
		{
			var data = _context.Customers.ToList();
			return View(data);
		}
		public IActionResult DialUpConnections()
		{
			var data = _context.DialUpConnections.ToList();
			return View(data);
		}
		public IActionResult LandLineConnections()
		{
			var data = _context.LandLineConnections.ToList();
			return View(data);
		}
		public IActionResult Payments()
		{
			var data = _context.Payments.ToList();
			return View(data);
		}
		public IActionResult Registers()
		{
			var data = _context.Registers.ToList();
			return View(data);
		}
		public IActionResult ServeOwns()
		{
			var data = _context.ServeOwns.ToList();
			return View(data);
		}

		public IActionResult Contects()
		{
			var data = _context.Contects.ToList();
			return View(data);
		}


	}
}
