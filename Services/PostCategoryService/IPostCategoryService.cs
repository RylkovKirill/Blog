using Entities;
using System;
using System.Linq;

namespace Services.PostCategoryService
{
    public interface IPostCategoryService
    {
        PostCategory GetCategory(Guid id);
        IQueryable<PostCategory> GetCategories();
        void InsertCategory(PostCategory category);
        void UpdateCategory(PostCategory category);
        void DeleteCategory(Guid id);
    }
}
