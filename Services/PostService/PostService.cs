using Entities;
using Repositories;
using System;
using System.Linq;

namespace Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> repository;

        public PostService(IRepository<Post> repository)
        {
            this.repository = repository;
        }

        public Post GetPost(Guid id)
        {
            return repository.Get(id);
        }

        public IQueryable<Post> GetPosts()
        {
            return repository.GetAll();
        }

        public IQueryable<Post> GetPostsByUser(ApplicationUser user)
        {
            return repository.GetAll().Where(p => p.User.Equals(user));
        }

        public IQueryable<Post> GetPostsByCategory(Category category)
        {
            return repository.GetAll().Where(p => p.Category.Equals(category));
        }

        public void InsertPost(Post post)
        {
            repository.Insert(post);
        }

        public void UpdatePost(Post post)
        {
            repository.Update(post);
        }

        public void DeletePost(Guid id)
        {
            repository.Delete(GetPost(id));
        }
    }
}
