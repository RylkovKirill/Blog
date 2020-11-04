using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _entities = applicationDbContext.Set<T>();
        }

        public T Get(Guid id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
