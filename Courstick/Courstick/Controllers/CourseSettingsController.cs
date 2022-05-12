using Courstick.Core.Models;
using Courstick.Views.CourseSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Courstick.Dto;
using Courstick.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CreateCourseModel = Courstick.Dto.CreateCourseModel;

namespace Courstick.Controllers;

public class CourseSettingsController : Controller
{
    private readonly string userId;
    private readonly UserManager<User> _userManager;
    private readonly ApplicationContext appContext;
    public CourseSettingsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ApplicationContext appContext)
    {
        
        _userManager = userManager;
        this.appContext = appContext;
        userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
    // GET
    public IActionResult CreateCourse()
    {
        return View();
    }

    public async Task<IActionResult> YourCourses()
    {
        var user = await _userManager.FindByIdAsync(userId);

        var courses =  appContext.Courses
            .Include(c => c.Users)
            .Where(c => c.Author.Contains(user));
        
        var model = new YourCourseModel
        {
            Courses = courses
        };
        
        return View(model);
    }
    
    public IActionResult EditCourse()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EditCourse([FromBody] EditCourseDto model)
    {
        var course = new Course
        {
            Name = model.Name,
            Description = model.Description,
            SmallDescription = model.SmallDescription,
            Image = new byte[]{1},
            Price = model.Price,
            //Author = new List<User> {user},
            Rating = 0
            
        };

        var updatedCourse = await appContext.Courses.AddAsync(course);
        
        await appContext.SaveChangesAsync();
        return Json(updatedCourse.Entity.CourseId);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody]CreateCourseModel model)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View();
        //}

        if (model == null)
        {
            return BadRequest("error");
        }

        var user = await _userManager.FindByIdAsync(userId);

        var course = new Course
        {
            Name = model.Name,
            Description = model.Description,
            SmallDescription = model.SmallDescription,
            Image = new byte[]{1},
            Price = model.Price,
            Author = new List<User> {user},
            Rating = 0
            
        };

        var updatedCourse = await appContext.Courses.AddAsync(course);
        
        await appContext.SaveChangesAsync();

        return Json(updatedCourse.Entity.CourseId);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLessons([FromBody]CourseDto courseDto)
    {
        var thatCourse = await appContext.Courses
            .Include(c => c.Page)
            .FirstAsync(c => c.CourseId == courseDto.CourseId);
        foreach (var lesson in courseDto.Lessons)
        {
            thatCourse.Page?.Add(new Page()
            {
                Movie = lesson.Movie,
                Type = lesson.Type,
                Text = lesson.Text,
                Image = lesson.Image
            });
        }
        
        await appContext.SaveChangesAsync();

        return Ok();
    }
}