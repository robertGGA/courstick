using Courstick.Core.Models;
using Courstick.Views.CourseSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Courstick.Controllers;

public class CourseSettingsController : Controller
{
    private readonly string userId;
    private readonly UserManager<User> _userManager;
    public CourseSettingsController(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
    {
        _userManager = userManager;
        userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
    // GET
    public IActionResult CreateCourse()
    {
        return View();
    }

    public IActionResult YourCourses()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CreateCourseModel model)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View();
        //}

        var user = await _userManager.FindByIdAsync(userId);

        var course = new Course
        {
            Name = model.Name,
            Description = model.Description,
            Image = model.Image,
            Price = model.Price
        };

        if (course.Author == null)
            course.Author = new List<User>();
        course.Author.Add(user);

        return RedirectToAction("Index", "Home");
    }
}