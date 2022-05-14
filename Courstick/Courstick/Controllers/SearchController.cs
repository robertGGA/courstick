using System.Collections;
using System.Collections.Immutable;
using System.Data.Entity;
using Courstick.Dto;
using Courstick.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courstick.Controllers;

public class SearchController : Controller
{
    private readonly ApplicationContext appContext;

    public SearchController(ApplicationContext _appContext)
    {
        appContext = _appContext;
    }
    // GET
    
    public IActionResult Search()
    {
        var courses = GetCourseList();
        return View(courses);
    }

    private ArrayList GetCourseList()
    {
        var courses =  appContext.Courses.ToImmutableArray();
        ArrayList arrayList = new ArrayList();
        foreach (var course in courses)
        {
            CourseInfoDto item = new CourseInfoDto();
            try
            {
                item.Name = course.Name;
                item.Description = course.Description;
                item.SmallDescription = course.SmallDescription;
                item.Price = course.Price;
                item.Id = course.CourseId;
                arrayList.Add(item);
            }
            catch (Exception e)
            {
                continue;
            }
        }

        return arrayList;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses =  appContext.Courses.ToImmutableArray();
        ArrayList arrayList = new ArrayList();
        foreach (var course in courses)
        {
            CourseInfoDto item = new CourseInfoDto();
            try
            {
                item.Name = course.Name;
                item.Description = course.Description;
                item.SmallDescription = course.SmallDescription;
                item.Price = course.Price;
                item.Author = course.Author[0];
                arrayList.Add(item);
            }
            catch (Exception e)
            {
                continue;
            }
        }
        return Json(arrayList);
       
    }

    [HttpGet]
    public async Task<IActionResult> GetCoursesByName()
    {
        return Json("");
    }
}