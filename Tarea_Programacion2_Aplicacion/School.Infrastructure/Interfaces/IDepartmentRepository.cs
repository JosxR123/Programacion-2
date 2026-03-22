using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Models;

namespace School.Infrastructure.Interfaces;

public interface IDepartmentRepository : IRepository<Department>
{
    Department Create(DepartmentModel model);
    Department Edit(int id, DepartmentModel model);
}
