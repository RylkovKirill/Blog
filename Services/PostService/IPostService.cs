using Entities;
using System;
using System.Linq;

namespace Services.PostService
{
    public interface IPostService
    {
        Post GetPost(Guid id);
        IQueryable<Post> GetPosts();
        IQueryable<Post> GetPostsByUser(ApplicationUser user);
        IQueryable<Post> GetPostsByCategory(Category category);
        void InsertPost(Post user);
        void UpdatePost(Post user);
        void DeletePost(Guid id);
    }
}
