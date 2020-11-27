using Entities;
using System;
using System.Linq;

namespace Services.Interfaces
{
    public interface IPostCategoryService
    {
        PostCategory Get(Guid id);
        IQueryable<PostCategory> GetAll();
        void Add(PostCategory category);
        void Update(PostCategory category);
        void Remove(Guid id);
    }
}
