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

    public async Task<CourseDto?> GetCourseDtoByIdAsync(int id)
    {
        var thatCourse = await _courseRepository.GetCourseByIdAsync(id);
        if (thatCourse is null)
            return null;
        CourseDto courseDto = new CourseDto();

        courseDto.Lessons = thatCourse.Page?.Select(x => new PageDto()
        {
            Movie = x.Movie,
            Image = x.Image,
            Text = x.Text,
            Type = x.Type
        }).ToList()??new List<PageDto>();
        courseDto.Name = thatCourse.Name;
        courseDto.Price = thatCourse.Price;
        courseDto.Description = thatCourse.Description;
        courseDto.CourseId = id;
        return courseDto;
    }

    public async Task<List<CourseInfoDto>> GetCourseListByName(string name)
    {
        var courses = await _courseRepository.GetCourseByNameAsync(name);
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