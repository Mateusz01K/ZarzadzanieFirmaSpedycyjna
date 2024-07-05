using Microsoft.AspNetCore.Mvc;
using Projekt.Models.Trucks;
using Projekt.Services.Truck;

namespace Projekt.Controllers
{
    public class TrucksController : Controller
    {
        private readonly ITruckService _truckService;
        public TrucksController(ILogger<TrucksController> logger, ITruckService truckService)
        {
            _truckService = truckService;
        }

        public IActionResult Index()
        {
            var model = new TrucksViewModel()
            {
                Trucks = _truckService.GetTrucks()
            };
            return View(model);
        }

        public IActionResult InsertNewTruck()
        {
            return View();
        }

        public IActionResult InsertTruck(string Model, string Brand, int Power, int Distance, int YearOfProduction)
        {
            if(string.IsNullOrEmpty(Model) && string.IsNullOrEmpty(Brand) && Power == 0 && Distance == 0 && YearOfProduction == 0)
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _truckService.InsertTruck(Model, Brand, Power, Distance, YearOfProduction);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTruck()
        {
            var model = new TrucksViewModel()
            {
                Trucks = _truckService.GetTrucks()
            };
            return View(model);
        }


        public IActionResult DeleteThisTruck(int id)
        {
            if(id!=0)
            {
                _truckService.DeleteTruck(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }


        public IActionResult UpDateTruck()
        {
            var model = new TrucksViewModel()
            {
                Trucks = _truckService.GetTrucks()
            };
            return View(model);
        }

        public IActionResult UpDateThisTruck(int id, string Model, string Brand, int Power, int Distance, int YearOfProduction)
        {
            var items = _truckService.GetTrucks().Count();
            if (id != 0 && Model != "" && Brand != "" && Power != 0 && Distance != 0 && YearOfProduction != 0)
            {
                _truckService.UpDateTruck(id, Model, Brand, Power, Distance, YearOfProduction);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}