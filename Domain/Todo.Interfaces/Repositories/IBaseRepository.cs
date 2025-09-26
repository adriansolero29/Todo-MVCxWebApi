using Todo.Entities;

namespace Todo.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<bool> Insert(T entity);
    Task<bool> Update(T entity);
    Task<bool> DeleteById(int id);
    Task<bool> DeleteAll();
}
