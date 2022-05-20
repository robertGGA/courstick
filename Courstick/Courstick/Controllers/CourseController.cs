using Courstick.Core.Services;
using Courstick.Dto;
using Courstick.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courstick.Controllers;

public class CourseController : Controller
{
    private readonly CourseService _courseService;
    private readonly ApplicationContext _appContext;
    public CourseController(CourseService courseService, ApplicationContext appContext)
    {
        _courseService = courseService;
        _appContext = appContext;
    }

    [HttpGet]
    public async Task<IActionResult> Course(int id)
    {
        try
        {
            var thatCourse = await _appContext.Courses
                .Include(c => c.Page)
                .FirstAsync(c => c.CourseId == id);
            CourseDto courseDto = new CourseDto();

            ViewBag.Count = thatCourse.Name;
            if (thatCourse.Page != null)
            {
                ViewBag.lessons = thatCourse.Page;
                courseDto.Name = thatCourse.Name;
                courseDto.Price = thatCourse.Price;
                courseDto.Description = thatCourse.Description;
                courseDto.CourseId = id;
            }
            else
            {
                return Redirect("/Search");
            }

            return View(courseDto);
        }
        catch (Exception e)
        {
            return Redirect("/Search");
        }
    } 
}