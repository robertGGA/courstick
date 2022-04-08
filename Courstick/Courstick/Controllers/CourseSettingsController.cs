using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class CourseSettingsController : Controller
{
    // GET
    public IActionResult CreateCourse()
    {
        return View();
    }

    public IActionResult YourCourses()
    {
        return View();
    }
}