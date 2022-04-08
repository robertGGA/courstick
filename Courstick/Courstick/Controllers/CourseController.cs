using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class CourseController : Controller
{
    // GET
    public IActionResult Course()
    {
        return View();
    }
}