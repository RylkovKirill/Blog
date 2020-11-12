using Entities;
using System;
using System.Linq;

namespace Services
{
    public interface IReviewService
    {
        Review GetReview(Guid id);
        Review GetReview(ApplicationUser user, Post post);
        IQueryable<Review> GetReviews();
        IQueryable<Review> GetReviewsByUser(ApplicationUser user);
        IQueryable<Review> GetReviewsByPost(Post post);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void RemoveReview(Guid id);
        int GetReviewsCount(IQueryable<Review> reviews);
        double? GetReviewsAverageScore(IQueryable<Review> reviews);
    }
}
