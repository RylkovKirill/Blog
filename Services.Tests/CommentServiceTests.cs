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
        private readonly IConfiguration _configuration;
        private ApplicationDbContext applicationDbContext;
        private Repository<Comment> repository;
        private CommentService commentService;

        public CommentServiceTests()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
            _configuration = configurationBuilder.Build();
        }

        [Fact]
        public void GetCommemtTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            Guid id = Guid.NewGuid();
            applicationDbContext.Comments.Add(new Comment() { Id = id, Content = "Content"});
            applicationDbContext.SaveChanges();
            var comment = commentService.GetComment(id);
            Assert.NotNull(comment);
            Assert.IsType<Comment>(comment);
            Assert.Equal(id, comment.Id);
            Assert.Equal("Content", comment.Content);
        }

        [Fact]
        public void GetCommemtsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
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
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            var user = UserHelpers.AddUser(applicationDbContext);
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
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new  CommentService(repository);
            Guid id = Guid.NewGuid();
            Post post = new Post() { Id = id, Title = "Title", Content = "Content" };
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
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            commentService.AddComment(new Comment() { Id = Guid.NewGuid(), Content = "Content" });
            Assert.Equal(1, applicationDbContext.Comments.Count(p => p.Content == "Content"));
        }

        [Fact]
        public void UpdateCommentTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            Guid id = Guid.NewGuid();
            applicationDbContext.Comments.Add(new Comment() { Id = id, Content = "Content" });
            applicationDbContext.SaveChanges();
            Comment comment = applicationDbContext.Comments.SingleOrDefault(s => s.Id == id);
            comment.Content = "Update content";
            commentService.UpdateComment(comment);
            Assert.Equal(1, applicationDbContext.Comments.Count(p => p.Content == "Update content"));
        }

        [Fact]
        public void RemoveCommentTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<Comment>(applicationDbContext);
            commentService = new CommentService(repository);
            Guid id = Guid.NewGuid();
            applicationDbContext.Comments.Add(new Comment() { Id = id, Content = "Content" });
            applicationDbContext.SaveChanges();
            commentService.RemoveComment(id);
            Assert.Equal(0, applicationDbContext.Comments.Count(p => p.Content == "Content"));
        }
    }
}
