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
        var courseDto = await _courseService.Course(id);
        return View(courseDto);
    }
}