using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Blog.Tests
{
    public class PostServiceTests
    {
        //private Repository<Post> _repository;
        //private PostService _postService;
        //IConfiguration _configuration;

        ////[Fact]
        ////public void AddPostTests()
        ////{
        ////    var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        ////    var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
        ////    _configuration = configurationBuilder.Build();
        ////    using (var applicationDbContext = new ApplicationDbContext(builder.Options, _configuration))
        ////    {
        ////        applicationDbContext.Posts.Add(new Post() { Id = Guid.Parse("443241de-a708-4f03-a801-5439264facd7"), Title = "Title", Content = "Content" });
        ////        applicationDbContext.SaveChanges();
        ////        Assert.Equal(1, applicationDbContext.Posts.Count(p => p.Title == "Title"));
        ////    }

        ////}

        //[Fact]
        //public void AddPostTests()
        //{
        //    var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        //    var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
        //    _configuration = configurationBuilder.Build();
        //    var applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
        //    _repository = new Repository<Post>(applicationDbContext);
        //    _postService = new PostService(_repository);
        //    using (applicationDbContext)
        //    {

        //        _postService.AddPost(new Post() { Id = Guid.Parse("443241de-a708-4f03-a801-5439264facd7"), Title = "Title", Content = "Content" });
        //        Assert.Equal(1, applicationDbContext.Posts.Count(p => p.Title == "Title"));
        //    }
        //}
    }
}
