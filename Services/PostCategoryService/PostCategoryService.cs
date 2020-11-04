using Entities;
using Repositories;
using System;
using System.Linq;

namespace Services.PostCategoryService
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IRepository<PostCategory> _repository;

        public PostCategoryService(IRepository<PostCategory> repository)
        {
            _repository = repository;
        }

        public PostCategory GetCategory(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<PostCategory> GetCategories()
        {
            return _repository.GetAll();
        }

        public void AddCategory(PostCategory category)
        {
            _repository.Add(category);
        }

        public void UpdateCategory(PostCategory category)
        {
            _repository.Update(category);
        }

        public void RemoveCategory(Guid id)
        {
            _repository.Remove(GetCategory(id));
        }
    }
}
