using System.Linq.Expressions;

namespace Challenge_2.Repositories;

public interface IRepository<T>
{
    IQueryable<T> Get();
    Task<T> GetById(Expression<Func<T, bool>> predicate);
    void Insert(T entity);
    void Update(T entity);
    void Delete (T entity);
}
