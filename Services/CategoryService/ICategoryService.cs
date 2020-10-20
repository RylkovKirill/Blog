using Entities;
using System;
using System.Linq;

namespace Services.CategoryService
{
    public interface ICategoryService
    {
        Category GetCategory(Guid id);
        IQueryable<Category> GetCategories();
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Guid id);
    }
}
