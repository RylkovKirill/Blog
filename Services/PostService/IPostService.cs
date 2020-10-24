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
        IQueryable<Post> GetPostsByCategory(PostCategory category);
        void InsertPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Guid id);
    }
}
