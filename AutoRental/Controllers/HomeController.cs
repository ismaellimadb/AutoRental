using AutoRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
			string errorMessage = TempData["ErrorMessage"] as string;
			ViewBag.ErrorMessage = errorMessage;

			var rentalViewModel = new RentalViewModel
			{
				Auto = GetAutoData(),
				Manufacturer = GetManufacturerData(),
				Year = GetYearData(),
				ModelManufacturer = GetAutoManufacturerData()
			};

			return View(rentalViewModel);
        }

		private List<Auto> GetAutoData()
		{
			return _dbContext.Auto.ToList();
		}

		private List<Manufacturer> GetManufacturerData()
		{
			return _dbContext.Manufacturer.ToList();
		}

		private List<ModelManufacturer> GetAutoManufacturerData()
		{
			List<Manufacturer> manufacturerList = GetManufacturerData();
			List<Auto> autoList = GetAutoData();

			var filteredNameModel = manufacturerList.Join(autoList,
										   manufacturer => manufacturer.id_manufacturer,
										   auto => auto.id_manufacturer,
										   (manufacturer, auto) => new ModelManufacturer
										   {
											   name = manufacturer.name,
											   model = auto.model,
                                               id_auto = auto.id_auto
                                           });

			return filteredNameModel.OrderBy(auto => auto.id_auto).ToList();
		}

		private List<Year> GetYearData()
		{
			List<Year> yearList = _dbContext.Year.ToList();
			yearList.Reverse();
			return yearList;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		[HttpPost]
		public IActionResult SaveToDatabase(string manufacturer, int year, string textModel, string textPlate)
		{
			try
			{
				var selectedmanufacturer = _dbContext.Manufacturer.Where(p => p.name == manufacturer).FirstOrDefault();
				var newAuto = new Auto { year = new DateTime(year, 1, 1), id_manufacturer = selectedmanufacturer.id_manufacturer, model = textModel, plate = textPlate };
				_dbContext.Auto.Add(newAuto);
				_dbContext.SaveChanges();

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "Fields are not allowed to be empty and Plate cannot be one already registered!";
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id_auto)
		{
			var auto = await _dbContext.Auto
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.id_auto == id_auto);

			if (auto is not null)
			{
				_dbContext.Auto.Remove(auto);
				await _dbContext.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id_auto, string newPlate)
		{
			try
			{
				var auto = await _dbContext.Auto
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.id_auto == id_auto);

				if (!newPlate.Contains("null") || newPlate!= "")
				{
					auto.plate = newPlate;

					_dbContext.Update(auto);

					await _dbContext.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}
	}
}

