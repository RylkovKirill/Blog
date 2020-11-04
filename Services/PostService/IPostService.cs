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
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(Guid id);
    }
}
