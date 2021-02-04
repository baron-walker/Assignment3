using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Add a route EnterMovie movie view fresh form
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        // Add a route to the EnterMovie Confirmation View after submit button
        [HttpPost]
        public IActionResult EnterMovie(MovieResponse movieResponse)
        {
            TempStorage.AddApplication(movieResponse);
            return View("Confirmation", movieResponse);
        }

        // Add a route to the EnteredMovies View
        public IActionResult EnteredMovies()
        {
            return View(TempStorage.Applications);
        }

        // Add a route to the MyPodcasts View
        public IActionResult MyPodcast()
        {
            return View();
        }

        // route not implimented
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
