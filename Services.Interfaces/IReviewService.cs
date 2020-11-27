using Entities;
using System;
using System.Linq;

namespace Services.Interfaces
{
    public interface IReviewService
    {
        Review Get(Guid id);
        Review Get(ApplicationUser user, Post post);
        IQueryable<Review> GetAll();
        IQueryable<Review> GetAll(ApplicationUser user);
        IQueryable<Review> GetAll(Post post);
        void Add(Review review);
        void Update(Review review);
        void Remove(Guid id);
        int GetReviewsCount(IQueryable<Review> reviews);
        double? GetReviewsAverageScore(IQueryable<Review> reviews);
        IQueryable<Post> SortedByScore(IQueryable<Post> posts);
    }
}
