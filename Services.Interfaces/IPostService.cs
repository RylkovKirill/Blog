using Entities;
using System;
using System.Linq;

namespace Services.Interfaces
{
    public interface IPostService
    {
        Post Get(Guid id);
        IQueryable<Post> GetAll();
        IQueryable<Post> GetAll(ApplicationUser user);
        IQueryable<Post> GetAll(PostCategory category);
        IQueryable<Post> GetAll(string searchQuery);
        void Add(Post post);
        void Update(Post post);
        void Remove(Guid id);
        IQueryable<Post> FilterByPostedDate(IQueryable<Post> posts);
        IQueryable<Post> SortedByPostedDate(IQueryable<Post> posts);
    }
}
