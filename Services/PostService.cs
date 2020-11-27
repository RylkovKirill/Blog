using Entities;
using Repositories;
using Services.Interfaces;
using System;
using System.Linq;

namespace Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repository;

        public PostService(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public Post Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Post> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Post> GetAll(ApplicationUser user)
        {
            return _repository.GetAll().Where(p => p.User.Equals(user));
        }

        public IQueryable<Post> GetAll(PostCategory category)
        {
            return _repository.GetAll().Where(p => p.Category.Equals(category));
        }

        public IQueryable<Post> GetAll(string searchQuery)
        {
            return _repository.GetAll().Where(a => a.Title.Contains(searchQuery));
        }

        public void Add(Post post)
        {
            _repository.Add(post);
        }

        public void Update(Post post)
        {
            _repository.Update(post);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(Get(id));
        }

        public IQueryable<Post> FilterByPostedDate(IQueryable<Post> posts)
        {
            return posts.Where(p => p.PostedDate <= DateTime.UtcNow);
        }

        public IQueryable<Post> SortedByPostedDate(IQueryable<Post> posts)
        {
            return posts.OrderByDescending(s => s.PostedDate);
        }
    }
}
