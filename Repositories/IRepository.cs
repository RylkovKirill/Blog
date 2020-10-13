using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
