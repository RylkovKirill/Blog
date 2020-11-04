using System;
using System.Linq;

namespace Repositories
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
