using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;

        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public Review GetReview(Guid id)
        {
            return _repository.Get(id);
        }

        public Review GetReview(ApplicationUser user, Post post)
        {
            return _repository.GetAll().Where(r => r.User.Equals(user) && r.Post.Equals(post)).SingleOrDefault();
        }

        public IQueryable<Review> GetReviews()
        {
            return _repository.GetAll();
        }

        public IQueryable<Review> GetReviewsByUser(ApplicationUser user)
        {
            return _repository.GetAll().Where(r => r.User.Equals(user));
        }

        public IQueryable<Review> GetReviewsByPost(Post post)
        {
            return _repository.GetAll().Where(r => r.Post.Equals(post));
        }

        public void AddReview(Review review)
        {
            _repository.Add(review);
        }

        public void UpdateReview(Review review)
        {
            _repository.Update(review);
        }

        public void RemoveReview(Guid id)
        {
            _repository.Remove(GetReview(id));
        }

        public int GetReviewsCount(IQueryable<Review> reviews)
        {
            return reviews.Count();
        }

        public double? GetReviewsAverageScore(IQueryable<Review> reviews)
        {
            int reviewCount = GetReviewsCount(reviews);
            if (reviewCount == 0)
            {
                return null;
            }
            else
            {
                return reviews.Sum(r => r.Score) / reviewCount;
            }
        }

        public IQueryable<Post> SortedPostsByScore(IQueryable<Post> posts)
        {
            return posts.ToList().Select(
            (p, s) => new
            {
                post = p,
                averagescore = _repository.GetAll().Where(r => r.Post.Equals(p)).Sum(r => r.Score)
            }).OrderByDescending(p => p.averagescore).Select(p => p.post).AsQueryable();
        }
    }
}
