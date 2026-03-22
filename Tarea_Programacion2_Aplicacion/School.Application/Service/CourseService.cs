using School.Application.Contract;
using School.Application.Core;
using School.Application.Dtos.Course;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;

namespace School.Application.Service;

public class CourseService : BaseService, ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public ServiceResult GetAll()
    {
        var courses = _courseRepository.GetAll()
            .Select(course => new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Credits = course.Credits,
                DepartmentId = course.DepartmentId
            })
            .ToList();

        return Success(courses);
    }

    public ServiceResult GetById(int id)
    {
        if (id <= 0)
        {
            return Fail("Id is required.");
        }

        var course = _courseRepository.GetById(id);

        if (course is null)
        {
            return Fail("Course not found.");
        }

        var dto = new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            Credits = course.Credits,
            DepartmentId = course.DepartmentId
        };

        return Success(dto);
    }

    public ServiceResult Add(SaveCourseDto dto)
    {
        var validation = Validate(dto);

        if (!validation.IsSuccess)
        {
            return validation;
        }

        try
        {
            var model = new CursoModel
            {
                Name = dto.Name.Trim(),
                Credits = dto.Credits,
                DepartmentId = dto.DepartmentId
            };

            var course = _courseRepository.Create(model);

            var result = new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Credits = course.Credits,
                DepartmentId = course.DepartmentId
            };

            return Success(result, "Course created.");
        }
        catch (CourseException ex)
        {
            return Fail(ex.Message);
        }
    }

    public ServiceResult Update(int id, SaveCourseDto dto)
    {
        if (id <= 0)
        {
            return Fail("Id is required.");
        }

        var validation = Validate(dto);

        if (!validation.IsSuccess)
        {
            return validation;
        }

        try
        {
            var model = new CursoModel
            {
                Name = dto.Name.Trim(),
                Credits = dto.Credits,
                DepartmentId = dto.DepartmentId
            };

            var course = _courseRepository.Edit(id, model);

            var result = new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Credits = course.Credits,
                DepartmentId = course.DepartmentId
            };

            return Success(result, "Course updated.");
        }
        catch (CourseException ex)
        {
            return Fail(ex.Message);
        }
    }

    public ServiceResult Delete(int id)
    {
        if (id <= 0)
        {
            return Fail("Id is required.");
        }

        var deleted = _courseRepository.Delete(id);

        if (!deleted)
        {
            return Fail("Course not found.");
        }

        return Success(null, "Course deleted.");
    }

    private ServiceResult Validate(SaveCourseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return Fail("Name is required.");
        }

        if (dto.Name.Trim().Length < 3)
        {
            return Fail("Name must contain at least 3 characters.");
        }

        if (dto.Credits <= 0)
        {
            return Fail("Credits must be greater than 0.");
        }

        if (dto.DepartmentId <= 0)
        {
            return Fail("DepartmentId is required.");
        }

        return Success();
    }
}
