using Microsoft.AspNetCore.Mvc;
using Projekt.Models.Trailer;
using Projekt.Services.Trailer;

namespace Projekt.Controllers
{
    public class TrailersController : Controller
    {
        private readonly ITrailerService _trailerService;
        public TrailersController(ILogger<TrailersController> logger, ITrailerService trailerService)
        {
            _trailerService = trailerService;
        }

        public IActionResult Index()
        {
            var model = new TrailerViewModel()
            {
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult InsertNewTrailer()
        {
            return View();
        }


        public IActionResult InsertTrailer(string Model, string Brand, string Type, int MaxLoad, int YearOfProduction)
        {
            if (string.IsNullOrEmpty(Model) && string.IsNullOrEmpty(Brand) && string.IsNullOrEmpty(Type) && MaxLoad == 0 && YearOfProduction == 0)
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _trailerService.InsertTrailer(Model, Brand, Type, MaxLoad, YearOfProduction);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTrailer()
        {
            var model = new TrailerViewModel()
            {
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult DeleteThisTrailer(int id)
        {
            if (id != 0)
            {
                _trailerService.DeleteTrailer(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTrailer()
        {
            var model = new TrailerViewModel()
            {
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult UpdateThisTrailer(int id, string Model, string Brand, string Type, int MaxLoad, int YearOfProduction)
        {
            var items = _trailerService.GetTrailer().Count();
            if (id != 0 && Model != "" && Type != "" && MaxLoad != 0 && YearOfProduction != 0)
            {
                _trailerService.UpdateTrailer(id, Model, Brand, Type, MaxLoad, YearOfProduction);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
