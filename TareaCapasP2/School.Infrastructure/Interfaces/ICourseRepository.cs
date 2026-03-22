using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Models;

namespace School.Infrastructure.Interfaces;

public interface ICourseRepository : IRepository<Course>
{
    Course Create(CursoModel model);
    Course Edit(int id, CursoModel model);
}
