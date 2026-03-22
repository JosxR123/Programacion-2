using School.Domain.Entities;

namespace School.Infrastructure.Context;

public class SchoolContext
{
    public List<Department> Departments { get; set; }
    public List<Course> Courses { get; set; }

    public SchoolContext()
    {
        Departments =
        [
            new Department { Id = 1, Name = "Software Development", Code = "SD" },
            new Department { Id = 2, Name = "Networks", Code = "NW" }
        ];

        Courses =
        [
            new Course { Id = 1, Name = "Programming 2", Credits = 4, DepartmentId = 1 },
            new Course { Id = 2, Name = "Database", Credits = 3, DepartmentId = 1 },
            new Course { Id = 3, Name = "Routing", Credits = 3, DepartmentId = 2 }
        ];
    }
}
