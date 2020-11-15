using Entities;
using System;
using System.Linq;

namespace Services
{
    public interface IPostService
    {
        Post GetPost(Guid id);
        IQueryable<Post> GetPosts();
        IQueryable<Post> GetPostsByUser(ApplicationUser user);
        IQueryable<Post> GetPostsByCategory(PostCategory category);
        IQueryable<Post> GetPostsBySearchQuery(string searchQuery);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(Guid id);
        IQueryable<Post> SortedPostsByPostedDate(IQueryable<Post> posts);
    }
}
