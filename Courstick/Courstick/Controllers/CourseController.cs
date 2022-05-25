using Courstick.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class CourseController : Controller
{
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> Course(int id)
    {
        var courseDto = await _courseService.GetCourseDtoByIdAsync(id);
        if (courseDto is null)
        {
            return Redirect("/Search/Search");
        }
        return View(courseDto);
    }
}