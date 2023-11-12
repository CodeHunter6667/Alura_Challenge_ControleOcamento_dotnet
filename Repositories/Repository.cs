using System.Linq.Expressions;

namespace Challenge_2.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

    }
}