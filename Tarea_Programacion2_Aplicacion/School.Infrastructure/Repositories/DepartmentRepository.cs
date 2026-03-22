using School.Domain.Entities;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;

namespace School.Infrastructure.Repositories;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(SchoolContext context) : base(context.Departments)
    {
    }

    public Department Create(DepartmentModel model)
    {
        var exists = Data.Any(x => x.Code.Equals(model.Code, StringComparison.OrdinalIgnoreCase));

        if (exists)
        {
            throw new DepartmentException("The department code already exists.");
        }

        var department = new Department
        {
            Name = model.Name,
            Code = model.Code
        };

        return Add(department);
    }

    public Department Edit(int id, DepartmentModel model)
    {
        var department = GetById(id);

        if (department is null)
        {
            throw new DepartmentException("The department was not found.");
        }

        var exists = Data.Any(x => x.Id != id && x.Code.Equals(model.Code, StringComparison.OrdinalIgnoreCase));

        if (exists)
        {
            throw new DepartmentException("The department code already exists.");
        }

        department.Name = model.Name;
        department.Code = model.Code;

        return Update(department);
    }
}
