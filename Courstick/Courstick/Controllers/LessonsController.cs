using Courstick.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courstick.Controllers;

public class LessonsController : Controller
{
    private readonly ApplicationContext _appContext;

    LessonsController(ApplicationContext appContext)
    {
        _appContext = appContext;
    }
    
    [Authorize]
    public async Task<IActionResult> Lessons(int id)
    {
        var thatCourse = await _appContext.Courses
            .Include(c => c.Page)
            .FirstAsync(c => c.CourseId == id);
        ViewBag.lessons = thatCourse.Page;
        return View();
    }
}