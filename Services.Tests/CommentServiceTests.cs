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
    public class CommentServiceTests
    {
        private IConfiguration configuration;
        private ApplicationDbContext applicationDbContext;
        private Repository<Comment> repository;
        private CommentService commentService;

        public CommentServiceTests()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
            configuration = configurationBuilder.Build();
        }

        [Fact]
        public void GetCommemtTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            applicationDbContext.Comments.Add(new Comment() { Id = Guid.Parse("8ded3d9a-8e35-4a6f-8f0a-5b2ef13eab80"), Content = "Content"});
            applicationDbContext.SaveChanges();
            var comment = commentService.GetComment(Guid.Parse("8ded3d9a-8e35-4a6f-8f0a-5b2ef13eab80"));
            Assert.NotNull(comment);
            Assert.IsType<Comment>(comment);
            Assert.Equal(Guid.Parse("8ded3d9a-8e35-4a6f-8f0a-5b2ef13eab80"), comment.Id);
            Assert.Equal("Content", comment.Content);
        }

        [Fact]
        public void GetCommemtsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Comments.Add(new Comment() { Id = Guid.NewGuid(), Content = "Content" });
            }
            applicationDbContext.SaveChanges();
            var comments = commentService.GetComments();
            Assert.NotNull(comments);
            Assert.Equal(10, comments.Count());
        }

        [Fact]
        public void GetCommentsByUserTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            ApplicationUser user = new ApplicationUser()
            {
                Id = "8b2d1851-852c-45e6-974a-3a382ce6a5c4",
                UserName = "user",
                Email = "email",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password"),
            };
            applicationDbContext.ApplicationUsers.Add(user);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Comments.Add(new Comment() { Id = Guid.NewGuid(), Content = "Content", User = user });
            }
            applicationDbContext.SaveChanges();
            var comments = commentService.GetCommentsByUser(user);
            Assert.NotNull(comments);
            Assert.Equal(10, comments.Count());
            for (int i = 0; i < comments.Count(); i++)
            {
                Assert.Equal(user, comments.ToArray()[i].User);
            }
        }

        [Fact]
        public void GetCommentsByPostTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new  CommentService(repository);
            Post post = new Post() { Id = Guid.Parse("7de75e92-d9cb-4de3-8503-8f325e624df9"), Title = "Title", Content = "Content" };
            applicationDbContext.Posts.Add(post);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Comments.Add(new Comment() { Id = Guid.NewGuid(), Content = "Content", Post = post });
            }
            applicationDbContext.SaveChanges();
            var comments = commentService.GetCommentsByPost(post);
            Assert.NotNull(comments);
            Assert.Equal(10, comments.Count());
            for (int i = 0; i < comments.Count(); i++)
            {
                Assert.Equal(post, comments.ToArray()[i].Post);
            }
        }

        [Fact]
        public void AddCommentTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            commentService.AddComment(new Comment() { Id = Guid.Parse("40d81482-ae77-4ec3-8b43-616cf5197c71"), Content = "Content" });
            Assert.Equal(1, applicationDbContext.Comments.Count(p => p.Content == "Content"));
        }

        [Fact]
        public void UpdateCommentTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            applicationDbContext.Comments.Add(new Comment() { Id = Guid.Parse("84104694-0983-4cf8-a93d-25b9c2f7327d"), Content = "Content" });
            applicationDbContext.SaveChanges();
            Comment comment = applicationDbContext.Comments.SingleOrDefault(s => s.Id == Guid.Parse("84104694-0983-4cf8-a93d-25b9c2f7327d"));
            comment.Content = "Update content";
            commentService.UpdateComment(comment);
            Assert.Equal(1, applicationDbContext.Comments.Count(p => p.Content == "Update content"));
        }

        [Fact]
        public void RemoveCommentTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            applicationDbContext.Comments.Add(new Comment() { Id = Guid.Parse("cecc9972-0e9f-499a-8005-a52a3ca42ec1"), Content = "Content" });
            applicationDbContext.SaveChanges();
            commentService.RemoveComment(Guid.Parse("cecc9972-0e9f-499a-8005-a52a3ca42ec1"));
            Assert.Equal(0, applicationDbContext.Comments.Count(p => p.Content == "Content"));
        }
    }
}
