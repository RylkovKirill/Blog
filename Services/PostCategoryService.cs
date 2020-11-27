using Entities;
using Repositories;
using Services.Interfaces;
using System;
using System.Linq;

namespace Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IRepository<PostCategory> _repository;

        public PostCategoryService(IRepository<PostCategory> repository)
        {
            _repository = repository;
        }

        public PostCategory Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<PostCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(PostCategory category)
        {
            _repository.Add(category);
        }

        public void Update(PostCategory category)
        {
            _repository.Update(category);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(Get(id));
        }
    }
}
