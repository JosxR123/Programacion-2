using School.Domain.Core;

namespace School.Domain.Entities;

public class Student : Person
{
    public string EnrollmentNumber { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
}
