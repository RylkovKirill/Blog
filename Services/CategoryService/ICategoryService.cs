using Entities;
using System;
using System.Linq;

namespace Services.CategoryService
{
    public interface ICategoryService
    {
        Category GetCategory(Guid id);
        IQueryable<Category> GetCategories();
        void InsertCategoriy(Category category);
        void UpdateCategoriy(Category category);
        void DeleteCategoriy(Guid id);
    }
}
