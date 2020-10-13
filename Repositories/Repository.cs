using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private readonly ApplicationDbContext applicationDbContext;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.entities = applicationDbContext.Set<T>();
        }

        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            applicationDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }
    }
}
