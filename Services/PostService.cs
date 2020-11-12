using Entities;
using Repositories;
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

        public Post GetPost(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Post> GetPosts()
        {
            return _repository.GetAll();
        }

        public IQueryable<Post> GetPostsByUser(ApplicationUser user)
        {
            return _repository.GetAll().Where(p => p.User.Equals(user));
        }

        public IQueryable<Post> GetPostsByCategory(PostCategory category)
        {
            return _repository.GetAll().Where(p => p.Category.Equals(category));
        }

        public void AddPost(Post post)
        {
            _repository.Add(post);
        }

        public void UpdatePost(Post post)
        {
            _repository.Update(post);
        }

        public void RemovePost(Guid id)
        {
            _repository.Remove(GetPost(id));
        }
    }
}
