using Microsoft.AspNetCore.Mvc;
using NEXUS.Models;

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

        //[HttpPost]
   //     public async Task<IActionResult> Registration(Customer Customar)
   //     {
   //         try
   //         {
			//	var customar = new Customer()
			//	{
			//		FirstName = Customar.FirstName,
			//		LastName = Customar.LastName,
			//		Email = Customar.Email,
			//		Password = Customar.Password,
			//		Address1 = Customar.Address1,
			//		Address2 = Customar.Address2,
			//		PhoneNumber = Customar.PhoneNumber,
			//		City = Customar.City,
			//		ZipCode = Customar.ZipCode,
			//	};
   //             await _context.Customers.AddAsync(customar);
   //             await _context.SaveChangesAsync();
   //             //HttpContext.Session.SetString("RegistrationStatus", "success");
   //             return RedirectToAction("Index","CustomarPannal");
			//}
   //         catch
   //         {
			//	TempData["error"] = "An error occurred while processing your registration. Please try again later.";

			//	return RedirectToAction("Registration");
			//}

   //     }
    }
}
