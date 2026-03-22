namespace School.Application.Dtos.Course;

public class CourseDto : DtoBase
{
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int DepartmentId { get; set; }
}
