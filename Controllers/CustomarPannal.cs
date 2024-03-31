using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEXUS.Models;

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
			if ( log != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index" , "WEBController");
			}
		}
		public IActionResult Logout()
		{
			//HttpContext.Session.Clear();

			return RedirectToAction("Index", "WEB");
		}

		[HttpPost]
		public IActionResult ServicesRegistration(ServicesRequestModel model)
		{

			if (model.Name == null  && model.ServiceName == "Select" && model.Address==null && model.Zip == null && model.Email == null)
			{
				return Json("some ting gone worng sheck input feild once again");
			}
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
			if(model.ServiceName != null)
			{
				if(model.ServiceName == "Dial-Up Connection")
				{

					var dialUpConnection = new DialUpConnection();
					dialUpConnection.CustomerId = customer.CustomerId;

					if (model.HourlyPlan != null)
					{
						dialUpConnection.PakageName = model.HourlyPlan;
						if (model.HourlyPlan == "10Hours")
						{
							dialUpConnection.Rates = 50;
						}
						if (model.HourlyPlan == "30Hours")
						{
							dialUpConnection.Rates = 130;
						}
						if (model.HourlyPlan == "60Hours")
						{
							dialUpConnection.Rates = 260;
						}
					}
					if (model.Kbps28Plan != null)
					{
						dialUpConnection.PakageName = model.Kbps28Plan;
						if (model.HourlyPlan == "28kbpsMonthly")
						{
							dialUpConnection.Rates = 75;
						}
						if (model.HourlyPlan == "28kbpsQuarterly")
						{
							dialUpConnection.Rates = 150;
						}

					}
					if (model.Kbps56Plan != null)
					{
						dialUpConnection.PakageName = model.Kbps56Plan;
						if (model.HourlyPlan == "56kbpsMonthly")
						{
							dialUpConnection.Rates = 100;
						}
						if (model.HourlyPlan == "56kbpsQuarterly")
						{
							dialUpConnection.Rates = 180;
						}

					}

					_context.DialUpConnections.Add(dialUpConnection);
				}
				if (model.ServiceName == "Brodbank Connection")
				{
					var broadbandConnection = new BroadbandConnection();
					if (model.BroadbandHourlyPlan != null)
					{
						broadbandConnection.PakageName = model.BroadbandHourlyPlan;
						if (model.BroadbandHourlyPlan == "30Hours")
						{
							broadbandConnection.Rates = 175;
						}
						if (model.BroadbandHourlyPlan == "60Hours")
						{
							broadbandConnection.Rates = 315;
						}

					}
					if (model.Kbps64Plan != null)
					{
						broadbandConnection.PakageName = model.Kbps64Plan;
						if (model.Kbps64Plan == "64kbpsMonthly")
						{
							broadbandConnection.Rates = 225;
						}
						if (model.Kbps64Plan == "64kbpsQuarterly")
						{
							broadbandConnection.Rates = 400;
						}

					}
					if (model.Kbps128Plan != null)
					{
						broadbandConnection.PakageName = model.Kbps128Plan;
						if (model.Kbps128Plan == "128kbpsMonthly")
						{
							broadbandConnection.Rates = 350;
						}
						if (model.Kbps128Plan == "128kbpsQuarterly")
						{
							broadbandConnection.Rates = 445;
						}

					}
					_context.BroadbandConnections.Add(broadbandConnection);
				}
				if (model.ServiceName == "Land line Connection")
				{
					var landLineConnection = new LandLineConnection();
					if (model.LocalPlan != null)
					{
						landLineConnection.PakageName = model.LocalPlan;
						if (model.LocalPlan == "Unlimited")
						{
							landLineConnection.Rates = 75;
						}
						if (model.LocalPlan == "Monthly")
						{
							landLineConnection.Rates = 35;
						}

					}
					if (model.StdPlan != null)
					{
						landLineConnection.PakageName = model.StdPlan;
						if (model.StdPlan == "Monthly")
						{
							landLineConnection.Rates = 125;
						}
						if (model.StdPlan == "HalfYearly")
						{
							landLineConnection.Rates = 420;
						}
						if (model.StdPlan == "Yearly")
						{
							landLineConnection.Rates = 700;
						}

					}

					_context.LandLineConnections.Add(landLineConnection);
				}
			}

			_context.SaveChanges(); // Save changes to the database

			return Json("Data inserted successfully.");
		}
		public IActionResult logOut()
		{
			HttpContext.Session.Clear();

			return RedirectToAction("Index", "WEBController");
		}
	}
}
