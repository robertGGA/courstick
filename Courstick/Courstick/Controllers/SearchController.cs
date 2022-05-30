using Courstick.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class SearchController : Controller
{
    private readonly CourseService _courseService;

    public SearchController(CourseService courseService)
    {
        _courseService = courseService;
    }

    public IActionResult Search()
    {
        var courses = _courseService.GetCourseList();
        return View(courses);
    }

    [HttpGet]
    public async Task<IActionResult> GetCourseByName(string name)
    {
        var courses = await _courseService.SearchListByName(name);
        return Json(courses);
    }


    [HttpGet]
    public IActionResult GetCourses()
    {
        var courses = _courseService.GetCourseList();
        return Json(courses);
    }


    [HttpGet]
    public async Task<IActionResult> GetLowestPriceCourses()
    {
        var courses = await _courseService.GetDescendingCourses();
        return Json(courses);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetHighestPriceCourses()
    {
        var courses = await _courseService.GetAscendingCourses();
        return Json(courses);
    }
}