using Courstick.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Courstick.Controllers
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

        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Course()
        {
            return View();
        }

        public IActionResult Lesson()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        public IActionResult YourCourses()
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