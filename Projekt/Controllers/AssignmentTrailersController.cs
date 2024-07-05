using Microsoft.AspNetCore.Mvc;
using Projekt.Models.AssignmentTruck;
using Projekt.Models.AssignTrailerToTruck;
using Projekt.Services.AssignmentTruck;
using Projekt.Services.AssignTrailerToTruck;
using Projekt.Services.Trailer;
using Projekt.Services.Truck;

namespace Projekt.Controllers
{
    public class AssignmentTrailersController : Controller
    {
        private readonly IAssignTrailerToTruckService _assignmentTruckService;
        private readonly ITruckService _truckService;
        private readonly ITrailerService _trailerService;



        public AssignmentTrailersController(IAssignTrailerToTruckService assignmentTrailerService, ITruckService truckService, ITrailerService trailerService)
        {
            _assignmentTruckService = assignmentTrailerService;
            _truckService = truckService;
            _trailerService = trailerService;
        }


        public IActionResult Index()
        {
            var model = new AssignTrailerToTruckViewModel()
            {
                AssignmentTrailers = _assignmentTruckService.GetAssignTrailers(),
                Trucks = _truckService.GetTrucks(),
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }


        public IActionResult AssignTrailer()
        {
            var model = new AssignTrailerToTruckViewModel()
            {
                AssignmentTrailers = _assignmentTruckService.GetAssignTrailers(),
                Trucks = _truckService.GetTrucks(),
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult AssignThisTrailer(int truckId, int trailerId)
        {
            if (truckId != 0 && trailerId != 0)
            {
                _assignmentTruckService.AssignTrailerToTruck(truckId, trailerId);
                return RedirectToAction("Index");
            }

            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAssignTrailer()
        {
            var model = new AssignTrailerToTruckViewModel()
            {
                AssignmentTrailers = _assignmentTruckService.GetAssignTrailers(),
                Trucks = _truckService.GetTrucks(),
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult DeleteThisAssignTrailer(int id)
        {
            var items = _assignmentTruckService.GetAssignTrailers().Count();
            if (id != 0)
            {
                _assignmentTruckService.DeleteAssignTrailer(id);
                return RedirectToAction("Index");
            }

            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }

        public IActionResult ReturnAssignTrailer()
        {
            var model = new AssignTrailerToTruckViewModel()
            {
                AssignmentTrailers = _assignmentTruckService.GetAssignTrailers(),
                Trucks = _truckService.GetTrucks(),
                Trailers = _trailerService.GetTrailer()
            };

            return View(model);
        }

        public IActionResult ReturnThisAssignTrailer(int id)
        {
            if (id != 0)
            {
                _assignmentTruckService.ReturnAssignTrailer(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
