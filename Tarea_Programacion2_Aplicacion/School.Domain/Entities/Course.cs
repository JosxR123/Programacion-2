using School.Domain.Core;

namespace School.Domain.Entities;

public class Course : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int DepartmentId { get; set; }
}
