using System.Collections;
using Courstick.Core.Interfaces;
using Courstick.Core.Models;
using Courstick.Dto;
using Courstick.Infrastructure.Interfaces;

namespace Courstick.Core.Services;

public class CourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    
    public List<CourseInfoDto> GetCourseList()
    {
        var courses = _courseRepository.GetAll();
        var arrayList = new List<CourseInfoDto>();
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

    public async Task<List<CourseInfoDto>> GetCourseListByName(string name)
    {
        var courses =  await _courseRepository.GetCourseByNameAsync(name);
        var arrayList = new List<CourseInfoDto>();
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

    public async Task<CourseDto> Course(int id)
    {
        var currentCourse = await _courseRepository.GetCourseByIdAsync(id);
        CourseDto courseDto = new CourseDto();
        courseDto.Description = currentCourse.Description;
        courseDto.Name = currentCourse.Name;
        courseDto.SmallDescription = currentCourse.SmallDescription;
        courseDto.Price = currentCourse.Price;
        return courseDto;
    }
    
    
}