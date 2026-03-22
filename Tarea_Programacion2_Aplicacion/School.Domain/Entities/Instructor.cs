using School.Domain.Core;

namespace School.Domain.Entities;

public class Instructor : Person
{
    public string EmployeeCode { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
}
