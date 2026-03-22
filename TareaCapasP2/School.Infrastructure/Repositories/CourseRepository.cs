using School.Domain.Entities;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;

namespace School.Infrastructure.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    private readonly SchoolContext _context;

    public CourseRepository(SchoolContext context) : base(context.Courses)
    {
        _context = context;
    }

    public Course Create(CursoModel model)
    {
        var departmentExists = _context.Departments.Any(x => x.Id == model.DepartmentId);

        if (!departmentExists)
        {
            throw new CourseException("The department does not exist.");
        }

        var course = new Course
        {
            Name = model.Name,
            Credits = model.Credits,
            DepartmentId = model.DepartmentId
        };

        return Add(course);
    }

    public Course Edit(int id, CursoModel model)
    {
        var course = GetById(id);

        if (course is null)
        {
            throw new CourseException("The course was not found.");
        }

        var departmentExists = _context.Departments.Any(x => x.Id == model.DepartmentId);

        if (!departmentExists)
        {
            throw new CourseException("The department does not exist.");
        }

        course.Name = model.Name;
        course.Credits = model.Credits;
        course.DepartmentId = model.DepartmentId;

        return Update(course);
    }
}
