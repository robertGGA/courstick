using System.Security.Claims;
using Courstick.Core.Models;
using Courstick.Dto;
using Courstick.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courstick.Controllers;

public class CourseController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationContext _appContext;
    public CourseController(UserManager<User> userManager, ApplicationContext appContext)
    {
        _userManager = userManager;
        _appContext = appContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> Course(int id)
    {
        var course = await _appContext.Courses.FirstOrDefaultAsync(a => a.CourseId == id);
        
        if (course is null)
        {
            return NotFound();
        }
        
        //var user = await _userManager.FindByIdAsync();

        var model = new CourseDto
        {
            CourseId = id,
            Description = course.Description,
            Name = course.Name,
            Price = course.Price,
            // Author = user
        };
        
        return View(model);
    }
}