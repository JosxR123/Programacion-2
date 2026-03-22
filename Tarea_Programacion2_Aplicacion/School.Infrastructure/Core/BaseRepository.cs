using School.Domain.Core;
using School.Domain.Repository;

namespace School.Infrastructure.Core;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly List<T> Data;

    public BaseRepository(List<T> data)
    {
        Data = data;
    }

    public virtual List<T> GetAll()
    {
        return Data.ToList();
    }

    public virtual T? GetById(int id)
    {
        return Data.FirstOrDefault(x => x.Id == id);
    }

    public virtual T Add(T entity)
    {
        var nextId = Data.Count == 0 ? 1 : Data.Max(x => x.Id) + 1;
        entity.Id = nextId;
        Data.Add(entity);
        return entity;
    }

    public virtual T Update(T entity)
    {
        var current = GetById(entity.Id);

        if (current is null)
        {
            throw new InvalidOperationException("Entity not found.");
        }

        var index = Data.FindIndex(x => x.Id == entity.Id);
        Data[index] = entity;

        return entity;
    }

    public virtual bool Delete(int id)
    {
        var current = GetById(id);

        if (current is null)
        {
            return false;
        }

        Data.Remove(current);
        return true;
    }
}
