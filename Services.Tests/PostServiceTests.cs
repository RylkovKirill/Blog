using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Services.Tests
{
    public class PostServiceTests
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext applicationDbContext;
        private Repository<Post> repository;
        private PostService postService;

        public PostServiceTests()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
            _configuration = configurationBuilder.Build();
        }

        [Fact]
        public void GetPostTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            applicationDbContext.Posts.Add(new Post() { Id = Guid.Parse("b3d92b9c-89a6-4f28-90de-87a4c9abda53"), Title = "Title", Content = "Content" });
            applicationDbContext.SaveChanges();
            var post = postService.GetPost(Guid.Parse("b3d92b9c-89a6-4f28-90de-87a4c9abda53"));
            Assert.NotNull(post);
            Assert.IsType<Post>(post);
            Assert.Equal(Guid.Parse("b3d92b9c-89a6-4f28-90de-87a4c9abda53"), post.Id);
            Assert.Equal("Title", post.Title);
            Assert.Equal("Content", post.Content);
        }

        [Fact]
        public void GetPostsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Posts.Add(new Post() { Id = Guid.NewGuid(), Title = "Title", Content = "Content" });
            }
            applicationDbContext.SaveChanges();
            var posts = postService.GetPosts();
            Assert.NotNull(posts);
            Assert.Equal(10, posts.Count());
        }

        [Fact]
        public void GetPostsByUserTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            var user = UserHelpers.AddUser(applicationDbContext);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Posts.Add(new Post() { Id = Guid.NewGuid(), Title = "Title", Content = "Content", User = user });
            }
            applicationDbContext.SaveChanges();
            var posts = postService.GetPostsByUser(user);
            Assert.NotNull(posts);
            Assert.Equal(10, posts.Count());
            for (int i = 0; i < posts.Count(); i++)
            {
                Assert.Equal(user, posts.ToArray()[i].User);
            }
        }

        [Fact]
        public void GetPostsByCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            PostCategory category = new PostCategory() { Id = Guid.Parse("0132b26e-2b96-48c0-a281-eccdf37b30a4"), Name = "Category" };
            applicationDbContext.PostCategories.Add(category);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Posts.Add(new Post() { Id = Guid.NewGuid(), Title = "Title", Content = "Content", Category = category });
            }
            applicationDbContext.SaveChanges();
            var posts = postService.GetPostsByCategory(category);
            Assert.NotNull(posts);
            Assert.Equal(10, posts.Count());
            for(int i = 0; i < posts.Count(); i++)
            {
                Assert.Equal(category, posts.ToArray()[i].Category);
            }
        }

        [Fact]
        public void AddPostTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            postService.AddPost(new Post() { Id = Guid.Parse("efd081d5-dcc5-4e70-9ac0-d26a5b9aa293"), Title = "Title", Content = "Content" });
            Assert.Equal(1, applicationDbContext.Posts.Count(p => p.Title == "Title"));
        }

        [Fact]
        public void UpdatePostTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            applicationDbContext.Posts.Add(new Post() { Id = Guid.Parse("aed4a0f0-ef37-4d7d-a463-757acb5e7147"), Title = "Title", Content = "Content" });
            applicationDbContext.SaveChanges();
            Post post = applicationDbContext.Posts.SingleOrDefault(s => s.Id == Guid.Parse("aed4a0f0-ef37-4d7d-a463-757acb5e7147"));
            post.Title = "Update title";
            post.Content = "Update content";
            postService.UpdatePost(post);
            Assert.Equal(1, applicationDbContext.Posts.Count(p => p.Title == "Update title"));
            Assert.Equal("Update title", post.Title);
            Assert.Equal("Update content", post.Content);
        }

        [Fact]
        public void RemovePostTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            applicationDbContext.Posts.Add(new Post() { Id = Guid.Parse("d5da59f4-6cbf-4e36-ad86-70b8e66a872a"), Title = "Title", Content = "Content" });
            applicationDbContext.SaveChanges();
            postService.RemovePost(Guid.Parse("d5da59f4-6cbf-4e36-ad86-70b8e66a872a"));
            Assert.Equal(0, applicationDbContext.Posts.Count(p => p.Title == "Title"));
        }

        [Fact]
        public void SortedByPostedDate()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Post>(applicationDbContext);
            postService = new PostService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Posts.Add(new Post() { Id = Guid.NewGuid(), Title = "Title", Content = "Content", PostedDate = DateTime.Now + TimeSpan.FromMinutes(i) });
            }
            applicationDbContext.SaveChanges();
            var posts = applicationDbContext.Posts.AsQueryable().Where(p => p.Title == "Title").ToArray().Select(p=>p.PostedDate);
            for (int i = 0; i < posts.Count()-1; i++)
            {
                Assert.True(IsSorted(posts));
            }
        }

        public static bool IsSorted<T>(IEnumerable<T> items, Comparer<T> comparer = null)
        {
            if (comparer == null) comparer = Comparer<T>.Default;
            bool ascendingOrder = true; bool descendingOrder = true;

            T last = items.First();
            foreach (T current in items.Skip(1))
            {
                int diff = comparer.Compare(last, current);
                if (diff > 0)
                {
                    ascendingOrder = false;
                }
                if (diff < 0)
                {
                    descendingOrder = false;
                }
                last = current;
                if (!ascendingOrder && !descendingOrder) return false;
            }
            return (ascendingOrder || descendingOrder);
        }
    }
}
