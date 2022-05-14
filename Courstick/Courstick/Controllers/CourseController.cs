
using Courstick.Dto;
using Courstick.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courstick.Controllers;

public class CourseController : Controller
{
    private readonly ApplicationContext _appContext;

    public CourseController(ApplicationContext appContext)
    {
        _appContext = appContext;
    }
    [HttpGet]
    public async Task<IActionResult> Course(int id)
    {
        var currentCourse = await _appContext.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
        CourseDto courseDto = new CourseDto();
        courseDto.Description = currentCourse.Description;
        courseDto.Name = currentCourse.Name;
        courseDto.SmallDescription = currentCourse.SmallDescription;
        courseDto.Price = currentCourse.Price;
        return View(courseDto);
    }
}