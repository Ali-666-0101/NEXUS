using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEXUS.Models;
using System.Diagnostics.Eventing.Reader;
using static System.Net.WebRequestMethods;

namespace NEXUS.Controllers
{
	public class CustomarPannal : Controller
	{
		private readonly NEXUSContext _context;
		public CustomarPannal(NEXUSContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var log = HttpContext.Session.GetString("UserName");
			if (log != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "WEBController");
			}
		}


		[HttpPost]
		public IActionResult ServicesRegistration(ServicesRequestModel model)
		{

			if (model.Name == null && model.ServiceName == "Select" && model.Address == null && model.Zip == null && model.Email == null)
			{
				return Json("some ting gone worng sheck input feild once again");
			}
			var ddd = new ServeOwn();
			ddd.ServiceName = model.ServiceName;
			ddd.CustumarId = HttpContext.Session.GetInt32("UserId");
			var customer = new Customer
			{
				Name = model.Name,
				Email = model.Email,
				Phone = model.Phone,
				Address = model.Address,
				AddressDetails = model.AddressDetails,
				City = model.City,
				ServiceName = model.ServiceName,
				ZipCode = model.Zip
			};

			// Add the customer to the context
			_context.Customers.Add(customer);
			_context.SaveChanges(); // Save changes to the database

			// Check the service type and insert data accordingly
			//var getServe = new OwnServe();

			if (model.ServiceName != null)
			{
				if (model.ServiceName == "Dial-Up Connection")
				{

					var dialUpConnection = new DialUpConnection();
					dialUpConnection.CustomerId = HttpContext.Session.GetInt32("UserId");


					if (model.HourlyPlan != null)
					{
						dialUpConnection.PakageName = model.HourlyPlan;
						ddd.PackageName = model.HourlyPlan;
						if (model.HourlyPlan == "10Hours")
						{
							dialUpConnection.Rates = 50;
							ddd.Rate = "50$";
						}
						if (model.HourlyPlan == "30Hours")
						{
							dialUpConnection.Rates = 130;
							ddd.Rate = "130$";

						}
						if (model.HourlyPlan == "60Hours")
						{
							dialUpConnection.Rates = 260;
							ddd.Rate = "260$";

						}
					}
					if (model.Kbps28Plan != null)
					{
						dialUpConnection.PakageName = model.Kbps28Plan;
						ddd.PackageName = model.Kbps28Plan;

						if (model.HourlyPlan == "28kbpsMonthly")
						{
							dialUpConnection.Rates = 75;
							ddd.Rate ="75$";

						}
						if (model.HourlyPlan == "28kbpsQuarterly")
						{
							dialUpConnection.Rates = 150;
							ddd.Rate = "150$";

						}

					}
					if (model.Kbps56Plan != null)
					{
						dialUpConnection.PakageName = model.Kbps56Plan;
						ddd.PackageName = model.Kbps56Plan;

						if (model.HourlyPlan == "56kbpsMonthly")
						{
							dialUpConnection.Rates = 100;
							ddd.Rate = "100$";

						}
						if (model.HourlyPlan == "56kbpsQuarterly")
						{
							dialUpConnection.Rates = 180;
							ddd.Rate = "180$";

						}

					}

					_context.DialUpConnections.Add(dialUpConnection);
				}
				if (model.ServiceName == "Brodbank Connection")
				{
					var broadbandConnection = new BroadbandConnection();
					broadbandConnection.CustomerId = HttpContext.Session.GetInt32("UserId");
					if (model.BroadbandHourlyPlan != null)
					{
						broadbandConnection.PakageName = model.BroadbandHourlyPlan;
						ddd.PackageName = model.BroadbandHourlyPlan;
						if (model.BroadbandHourlyPlan == "30Hours")
						{
							broadbandConnection.Rates = 175;
							ddd.Rate = "175$";
						}
						if (model.BroadbandHourlyPlan == "60Hours")
						{
							broadbandConnection.Rates = 315;
							ddd.Rate = "315$";
						}

					}
					if (model.Kbps64Plan != null)
					{
						broadbandConnection.PakageName = model.Kbps64Plan;
						ddd.PackageName = model.Kbps64Plan;

						if (model.Kbps64Plan == "64kbpsMonthly")
						{
							broadbandConnection.Rates = 225;
							ddd.Rate = "225$";
						}
						if (model.Kbps64Plan == "64kbpsQuarterly")
						{
							broadbandConnection.Rates = 400;
							ddd.Rate = "400$";
						}

					}
					if (model.Kbps128Plan != null)
					{
						broadbandConnection.PakageName = model.Kbps128Plan;
						ddd.PackageName = model.Kbps128Plan;

						if (model.Kbps128Plan == "128kbpsMonthly")
						{
							broadbandConnection.Rates = 350;
							ddd.Rate = "350$";
						}
						if (model.Kbps128Plan == "128kbpsQuarterly")
						{
							broadbandConnection.Rates = 445;
							ddd.Rate = "445$";
						}

					}
					_context.BroadbandConnections.Add(broadbandConnection);
					
				}
				if (model.ServiceName == "Land line Connection")
				{
					var landLineConnection = new LandLineConnection();
					var id = HttpContext.Session.GetInt32("UserId");
					if (id > 0)
					{
						landLineConnection.CustomerId = id.Value;
					}

					if (model.LocalPlan != null)
					{
						landLineConnection.PakageName = model.LocalPlan;
						
						ddd.PackageName = model.LocalPlan;

						if (model.LocalPlan == "Unlimited")
						{
							landLineConnection.Rates = 75;
							ddd.Rate = "75$";

						}
						if (model.LocalPlan == "Monthly")
						{
							landLineConnection.Rates = 35;
						}

					}
					if (model.StdPlan != null)
					{
						landLineConnection.PakageName = model.StdPlan;
						ddd.PackageName = model.StdPlan;

						if (model.StdPlan == "Monthly")
						{
							landLineConnection.Rates = 125;
							ddd.Rate = "125$";

						}
						if (model.StdPlan == "HalfYearly")
						{
							landLineConnection.Rates = 420;
							ddd.Rate = "420$";

						}
						if (model.StdPlan == "Yearly")
						{
							landLineConnection.Rates = 700;
							ddd.Rate = "700$";

						}

					}

					_context.LandLineConnections.Add(landLineConnection);
					
					
				}
			}
			_context.ServeOwns.Add(ddd);
			_context.SaveChanges();

			return Json("Data inserted successfully.");
		}
		public IActionResult logOut()
		{
			HttpContext.Session.Clear();

			return RedirectToAction("Index", "WEB");
		}

		[HttpPost]
		public IActionResult savePayment(Payment Pay)
		{
			Pay.CustomarId = HttpContext.Session.GetInt32("UserId");
			_context.Payments.Add(Pay);
			_context.SaveChanges();
			return Json("Data inserted successfully.");
		}

		[HttpGet]
		public IActionResult getPaymentByid()
		{
			var id = HttpContext.Session.GetInt32("UserId");
			var PayHistory = _context.Payments.Where(x => x.CustomarId == id);
			return Json(PayHistory);
		}

		[HttpGet]
		public IActionResult GetHaveServices()
		{
			var id = HttpContext.Session.GetInt32("UserId");

			var data = _context.ServeOwns.Where(x => x.CustumarId == id);
			return Json(data);
		}
	}
}

