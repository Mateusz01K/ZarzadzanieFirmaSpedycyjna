using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt.Models.Users;
using Projekt.Services.User;

namespace Projekt.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new UserViewModel()
            {
                Users = _userService.GetUsers()
            };
            return View(model);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult SendUser(string FirstName, string LastName, string Email)
        {
            if(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(Email))
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _userService.CreateUser(FirstName, LastName, Email);
            return RedirectToAction("Index");
        }

        public IActionResult UpDateUser()
        {
            var model = new UserViewModel()
            {
                Users = _userService.GetUsers()
            };
            return View(model);
        }

        public IActionResult UpDateThisUser(int id, string FirstName, string LastName, string Email)
        {
            var item = _userService.GetUsers().Count();
            if (id == 0 && id < item && string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(Email))
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _userService.UpDateUser(id, FirstName, LastName, Email);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser()
        {
            var model = new UserViewModel()
            {
                Users = _userService.GetUsers()
            };
            return View(model);
        }

        public IActionResult DeleteThisUser(int id)
        {
            var items = _userService.GetUsers().Count();
            if(id != 0)
            {
                _userService.DeleteUser(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
