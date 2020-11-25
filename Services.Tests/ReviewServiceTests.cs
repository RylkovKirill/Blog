using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Services.Tests
{
    public class ReviewServiceTests
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext applicationDbContext;
        private Repository<Review> repository;
        private ReviewService reviewService;

        public ReviewServiceTests()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
            _configuration = configurationBuilder.Build();
        }

        [Fact]
        public void GetReviewTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            applicationDbContext.Reviews.Add(new Review() { Id = Guid.Parse("0602e418-69c8-499c-94af-0466139fc504") });
            applicationDbContext.SaveChanges();
            var review = reviewService.Get(Guid.Parse("0602e418-69c8-499c-94af-0466139fc504"));
            Assert.NotNull(review);
            Assert.IsType<Review>(review);
            Assert.Equal(Guid.Parse("0602e418-69c8-499c-94af-0466139fc504"), review.Id);
        }

        [Fact]
        public void GetReviewsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reviews.Add(new Review() { Id = Guid.NewGuid() });
            }
            applicationDbContext.SaveChanges();
            var review = reviewService.GetAll();
            Assert.NotNull(review);
            Assert.Equal(10, review.Count());
        }

        [Fact]
        public void GetReviewsByUserTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            var user = UserHelpers.AddUser(applicationDbContext);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reviews.Add(new Review() { Id = Guid.NewGuid(), User = user });
            }
            applicationDbContext.SaveChanges();
            var reports = reviewService.GetAll(user);
            Assert.NotNull(reports);
            Assert.Equal(10, reports.Count());
            for (int i = 0; i < reports.Count(); i++)
            {
                Assert.Equal(user, reports.ToArray()[i].User);
            }
        }

        [Fact]
        public void GetReviewsByPostTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            Post post = new Post() { Id = Guid.Parse("b7db8ddd-6637-4321-8a8f-9899e1ba99aa"), Title = "Title", Content = "Content" };
            applicationDbContext.Posts.Add(post);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reviews.Add(new Review() { Id = Guid.NewGuid(), Post = post });
            }
            applicationDbContext.SaveChanges();
            var reports = reviewService.GetAll(post);
            Assert.NotNull(reports);
            Assert.Equal(10, reports.Count());
            for (int i = 0; i < reports.Count(); i++)
            {
                Assert.Equal(post, reports.ToArray()[i].Post);
            }
        }

        [Fact]
        public void AddReviewsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            reviewService.Add(new Review() { Id = Guid.Parse("1b7b7549-9338-43dc-a1a1-de9b9a40bf60") });
            Assert.Equal(1, applicationDbContext.Reviews.Count());
        }

        [Fact]
        public void UpdateReviewsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            reviewService.Add(new Review() { Id = Guid.Parse("5df72e56-a5af-4fcb-8151-5d7812640dc8") });
            applicationDbContext.SaveChanges();
            Review reports = applicationDbContext.Reviews.SingleOrDefault(s => s.Id == Guid.Parse("5df72e56-a5af-4fcb-8151-5d7812640dc8"));
            reviewService.Update(reports);
            Assert.Equal(1, applicationDbContext.Reviews.Count());
        }

        [Fact]
        public void RemoveReviewsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            reviewService.Add(new Review() { Id = Guid.Parse("22e34370-ee6f-415c-a177-159e87a2b4d8") });
            applicationDbContext.SaveChanges();
            reviewService.Remove(Guid.Parse("22e34370-ee6f-415c-a177-159e87a2b4d8"));
            Assert.Equal(0, applicationDbContext.Reports.Count());
        }

        [Fact]
        public void GetReviewsCount() 
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reviews.Add(new Review() { Id = Guid.NewGuid() });
            }
            applicationDbContext.SaveChanges();
            var reviews = applicationDbContext.Reviews.AsQueryable();
            var count = reviewService.GetReviewsCount(reviews);
            Assert.IsType<int>(count);
            Assert.Equal(10, count);

        }

        [Fact]
        public void GetReviewsAverageScore()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Review>(applicationDbContext);
            reviewService = new ReviewService(repository);
            var reviews = applicationDbContext.Reviews.AsQueryable();
            Assert.Null(reviewService.GetReviewsAverageScore(reviews));
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reviews.Add(new Review() { Id = Guid.NewGuid(), Score = 5});
            }
            applicationDbContext.SaveChanges();
            reviews = applicationDbContext.Reviews.AsQueryable();
            var AverageScore = reviewService.GetReviewsAverageScore(reviews);
            Assert.IsType<double>(AverageScore);
            Assert.Equal(5, AverageScore);
        }
    }
}
