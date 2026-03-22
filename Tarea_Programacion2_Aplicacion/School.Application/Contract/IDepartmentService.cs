using School.Application.Dtos.Department;

namespace School.Application.Contract;

public interface IDepartmentService : IBaseService<DepartmentDto, SaveDepartmentDto>
{
}
