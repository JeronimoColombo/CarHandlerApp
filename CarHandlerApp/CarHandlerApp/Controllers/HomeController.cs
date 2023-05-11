using CarHandlerApp.Models;
using CarHandlerApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarHandlerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;

        private AttemptsSingleton _attemptsSingleton;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
            _attemptsSingleton = AttemptsSingleton.Instance;
        }

        public IActionResult Index()
        {
            List<Car> cars = _carService.GetCars();
            return View(cars);
        }

        public IActionResult PriceGuess(int carId, double priceGuessed)
        {
            bool isPriceCorrect = _carService.IsPriceCorrect(carId, priceGuessed);

            if (!isPriceCorrect)
                _attemptsSingleton.Attempts++;
            else
                _attemptsSingleton.Attempts = 0;

            var attempt = new Attemp{ IsCorrect = isPriceCorrect, Count = _attemptsSingleton.Attempts };

            return View(attempt);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }


}