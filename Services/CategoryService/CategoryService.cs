using Entities;
using Repositories;
using System;
using System.Linq;

namespace Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public Category GetCategory(Guid id)
        {
            return repository.Get(id);
        }

        public IQueryable<Category> GetCategories()
        {
            return repository.GetAll();
        }

        public void InsertCategoriy(Category category)
        {
            repository.Insert(category);
        }

        public void UpdateCategoriy(Category category)
        {
            repository.Update(category);
        }

        public void DeleteCategoriy(Guid id)
        {
            repository.Delete(GetCategory(id));
        }
    }
}
