using Microsoft.AspNetCore.Mvc;
using Projekt.Models.AssignmentTruck;
using Projekt.Services.Truck;
using Projekt.Services.AssignmentTruck;
using Projekt.Services.User;
using System.IO;

namespace Projekt.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;
        private readonly ITruckService _filmService;
        private readonly IUserService _userService;



        public AssignmentController(IAssignmentService assignmentService, ITruckService filmService, IUserService userService)
        {
            _assignmentService = assignmentService;
            _filmService = filmService;
            _userService = userService;
        }


        public IActionResult Index()
        {
            var model = new AssignmentViewModel()
            {
                AssignmentTrucks = _assignmentService.GetAssignments(),
                Trucks = _filmService.GetTrucks(),
                Users = _userService.GetUsers()
            };
            return View(model);
        }


        public IActionResult AssignmentTrucks()
        {
            var model = new AssignmentViewModel()
            {
                AssignmentTrucks = _assignmentService.GetAssignments(),
                Trucks = _filmService.GetTrucks(),
                Users = _userService.GetUsers()
            };
            return View(model);
        }
        
        public IActionResult AssignmentThisTruck(int truckId, int userId)
        {
            if (truckId != 0 && userId != 0)
            {
                _assignmentService.AssignmentTruck(truckId, userId);
                return RedirectToAction("Index");
            }

        TempData["message"] = "Popraw dane.";
        return RedirectToAction("Index");
        }

        public IActionResult DeleteAssignment()
        {
            var model = new AssignmentViewModel()
            {
                AssignmentTrucks = _assignmentService.GetAssignments(),
                Trucks = _filmService.GetTrucks(),
                Users = _userService.GetUsers()
            };
            return View(model);
        }

        public IActionResult DeleteThisAssignment(int id)
        {
            var items = _assignmentService.GetAssignments().Count();
            if(id != 0)
            {
                _assignmentService.DeleteAssignment(id);
                return RedirectToAction("Index");
            }

        TempData["message"] = "Popraw dane.";
        return RedirectToAction("Index");
        }

        public IActionResult ReturnAssignment()
        {
            var model = new AssignmentViewModel()
            {
                AssignmentTrucks = _assignmentService.GetAssignments(),
                Trucks = _filmService.GetTrucks(),
                Users = _userService.GetUsers()
            };

            return View(model);
        }

        public IActionResult ReturnThisAssignment(int id)
        {
            if (id != 0 )
            {
                _assignmentService.ReturnAssignment(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
