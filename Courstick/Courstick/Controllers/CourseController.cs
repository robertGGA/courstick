using Courstick.Core.Models;
using Courstick.Views.CourseSettings;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class CourseController : Controller
{
    [HttpGet]
    public IActionResult Course() => View();

}