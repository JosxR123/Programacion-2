using School.Domain.Core;

namespace School.Domain.Repository;

public interface IRepository<T> where T : BaseEntity
{
    List<T> GetAll();
    T? GetById(int id);
    T Add(T entity);
    T Update(T entity);
    bool Delete(int id);
}
