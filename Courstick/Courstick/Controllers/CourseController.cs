using System.Security.Claims;
using Courstick.Core.Models;
using Courstick.Core.Services;
using Courstick.Dto;
using Courstick.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Courstick.Controllers;

public class CourseController : Controller
{
    private readonly CourseService _courseService;
    private readonly string userId;
    private readonly UserManager<User> _userManager;
    private readonly ApplicationContext _appContext;

    public CourseController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, CourseService courseService,
        ApplicationContext appContext)
    {
        _courseService = courseService;
        _userManager = userManager;
        _appContext = appContext;
        userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
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
    
    [HttpPost]
    public async Task<IActionResult> BuyCourse(CourseDto model)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var course = await _appContext.Courses.FirstOrDefaultAsync(c => c.CourseId == model.CourseId);
        
        if (course is null)
        {
            return Redirect("/Search/Search");
        }

        if (user.Courses is null)
        {
            user.Courses = new List<Course>();
        }
        
        user.Courses.Add(course);
        user.Balance -= course.Price;
        
        await _userManager.UpdateAsync(user);
        
        return RedirectToAction("Lessons", "Lessons", new {id = course.CourseId});
    }
}