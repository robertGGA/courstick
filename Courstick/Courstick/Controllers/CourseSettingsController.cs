using Courstick.Core.Models;
using Courstick.Views.CourseSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Courstick.Dto;
using Courstick.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CreateCourseModel = Courstick.Dto.CreateCourseDto;

namespace Courstick.Controllers;

public class CourseSettingsController : Controller
{
    private readonly string userId;
    private readonly UserManager<User> _userManager;
    private readonly ApplicationContext _appContext;
    public CourseSettingsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ApplicationContext appContext)
    {
        
        _userManager = userManager;
        _appContext = appContext;
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

        var courses =  _appContext.Courses
            .Include(c => c.Users)
            .Where(c => c.Author.Contains(user));
        
        var model = new YourCourseDto
        {
            Courses = courses
        };
        
        return View(model);
    }
    
    public async Task<IActionResult> EditCourse(int id)
    {
        var course = await _appContext.Courses.FirstOrDefaultAsync(a => a.CourseId == id);
        
        if (course is null)
        {
            return NotFound();
        }
        
        var model = new EditCourseDto
        {
            Id = id,
            Description = course.Description,
            Name = course.Name,
            Price = course.Price,
            SmallDescription = course.SmallDescription
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditCourse(EditCourseDto model)
    {
        if (model is null)
        {
            return BadRequest("error");
        }

        var course = await _appContext.Courses.FirstOrDefaultAsync(c => c.CourseId == model.Id);
        
        if (course is null)
        {
            return BadRequest("error");
        }

        course.Name = model.Name;
        course.Description = model.Description;
        course.SmallDescription = model.SmallDescription;
        course.Image = new byte[] {1};
        course.Price = model.Price;
        course.Rating = 0;
            
        _appContext.Courses.Update(course);
        await _appContext.SaveChangesAsync();
        
        return View(model);
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

        var updatedCourse = await _appContext.Courses.AddAsync(course);
        
        await _appContext.SaveChangesAsync();

        return Json(updatedCourse.Entity.CourseId);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLessons([FromBody]CourseDto courseDto)
    {
        var thatCourse = await _appContext.Courses
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
        
        await _appContext.SaveChangesAsync();

        return Ok();
    }
}