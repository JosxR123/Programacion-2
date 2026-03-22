using School.Application.Dtos.Course;

namespace School.Application.Contract;

public interface ICourseService : IBaseService<CourseDto, SaveCourseDto>
{
}
