using Entities;
using System;
using System.Linq;

namespace Services
{
    public interface IPostCategoryService
    {
        PostCategory GetCategory(Guid id);
        IQueryable<PostCategory> GetCategories();
        void AddCategory(PostCategory category);
        void UpdateCategory(PostCategory category);
        void RemoveCategory(Guid id);
    }
}
