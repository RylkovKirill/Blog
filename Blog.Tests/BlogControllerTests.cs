using Blog.Controllers;
using Blog.Hubs;
using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Blog.Tests
{
    public class BlogControllerTests
    {
        //public static UserManager<TUser> TestUserManager<TUser>(IUserStore<TUser> store = null) where TUser : class
        //{
        //    store = store ?? new Mock<IUserStore<TUser>>().Object;
        //    var options = new Mock<IOptions<IdentityOptions>>();
        //    var idOptions = new IdentityOptions();
        //    idOptions.Lockout.AllowedForNewUsers = false;
        //    options.Setup(o => o.Value).Returns(idOptions);
        //    var userValidators = new List<IUserValidator<TUser>>();
        //    var validator = new Mock<IUserValidator<TUser>>();
        //    userValidators.Add(validator.Object);
        //    var pwdValidators = new List<PasswordValidator<TUser>>();
        //    pwdValidators.Add(new PasswordValidator<TUser>());
        //    var userManager = new UserManager<TUser>(store, options.Object, new PasswordHasher<TUser>(),
        //        userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
        //        new IdentityErrorDescriber(), null,
        //        new Mock<ILogger<UserManager<TUser>>>().Object);
        //    validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<TUser>()))
        //        .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
        //    return userManager;
        //}

        //private IQueryable<Post> GetTestPosts()
        //{
        //    var posts = new List<Post>
        //    {
        //        new Post { Id=Guid.Parse("0a3e6a5b-dbc8-4c7a-92e8-b19241dfc2a0"), Title="Test Post 1", Content = "Test Post 1"},
        //        new Post { Id=Guid.Parse("b199f8b7-da09-4ac9-a876-5777c0061a13"), Title="Test Post 2", Content = "Test Post 2"},
        //        new Post { Id=Guid.Parse("00304dc4-6600-42fa-84ee-3b6fec0ef93a"), Title="Test Post 3", Content = "Test Post 3"},
        //        new Post { Id=Guid.Parse("aa43c16d-df57-40be-9f01-a274a75cd94c"), Title="Test Post 4", Content = "Test Post 4"},
        //        new Post { Id=Guid.Parse("e886fe3f-5dea-4deb-aec2-8f21a9335f6d"), Title="Test Post 5", Content = "Test Post 5"},
        //    };
        //    return posts.AsQueryable();
        //}

        //[Fact]
        //public void EditReturnsNotFound()
        //{
        //    Guid testId = Guid.Parse("00304dc4-6600-42fa-84ee-3b6fec0ef93a");
        //    var postService = new Mock<IPostService>();
        //    postService.Setup(p => p.GetPost(testId)).Returns(null as Post);
        //    var commentService = new Mock<ICommentService>();
        //    var categoryService = new Mock<IPostCategoryService>();
        //    var reportService = new Mock<IReportService>();
        //    var reportCategoryService = new Mock<IReportCategoryService>();
        //    var image = new Mock<ImageService>();
        //    var webHostEnvironment = new Mock<IWebHostEnvironment>();
        //    var userManager = TestUserManager<ApplicationUser>();
        //    var hubContext = new Mock<IHubContext<CommentsHub>>();
        //    var logger = new Mock<ILogger<BlogController>>();


        //    var controller = new BlogController(postService.Object, commentService.Object, categoryService.Object, reportService.Object, reportCategoryService.Object, image.Object, webHostEnvironment.Object, userManager, hubContext.Object, logger.Object);

        //    var result = controller.Edit(testId);

        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public void EditReturnsView()
        //{
        //    Guid testId = Guid.Parse("00304dc4-6600-42fa-84ee-3b6fec0ef93a");
        //    var postService = new Mock<IPostService>();
        //    postService.Setup(p => p.GetPost(testId)).Returns(GetTestPosts().FirstOrDefault(p => p.Id == testId));
        //    var commentService = new Mock<ICommentService>();
        //    var categoryService = new Mock<IPostCategoryService>();
        //    var reportService = new Mock<IReportService>();
        //    var reportCategoryService = new Mock<IReportCategoryService>();
        //    var image = new Mock<ImageService>();
        //    var webHostEnvironment = new Mock<IWebHostEnvironment>();
        //    var userManager = TestUserManager<ApplicationUser>();
        //    var hubContext = new Mock<IHubContext<CommentsHub>>();
        //    var logger = new Mock<ILogger<BlogController>>();

        //    var controller = new BlogController(postService.Object, commentService.Object, categoryService.Object, reportService.Object, reportCategoryService.Object, image.Object, webHostEnvironment.Object, userManager, hubContext.Object, logger.Object);

        //    var result = controller.Edit(testId);


        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model = Assert.IsType<Post>(viewResult.ViewData.Model);
        //    Assert.Equal("Test Post 3", model.Title);
        //    Assert.Equal("Test Post 3", model.Content);
        //    Assert.Equal(testId, model.Id);
        //}

        //[Fact]
        //public void DeteilsReturnsNotFound()
        //{
        //    Guid testId = Guid.Parse("00304dc4-6600-42fa-84ee-3b6fec0ef93a");
        //    var postService = new Mock<IPostService>();
        //    postService.Setup(p => p.GetPost(testId)).Returns(null as Post);
        //    var commentService = new Mock<ICommentService>();
        //    var categoryService = new Mock<IPostCategoryService>();
        //    var reportService = new Mock<IReportService>();
        //    var reportCategoryService = new Mock<IReportCategoryService>();
        //    var image = new Mock<ImageService>();
        //    var webHostEnvironment = new Mock<IWebHostEnvironment>();
        //    var userManager = TestUserManager<ApplicationUser>();
        //    var hubContext = new Mock<IHubContext<CommentsHub>>();
        //    var logger = new Mock<ILogger<BlogController>>();

        //    var controller = new BlogController(postService.Object, commentService.Object, categoryService.Object, reportService.Object, reportCategoryService.Object, image.Object, webHostEnvironment.Object, userManager, hubContext.Object, logger.Object);

        //    var result = controller.DetailsAsync(testId);

        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public void DeteilsReturnsView()
        //{
        //    Guid testId = Guid.Parse("00304dc4-6600-42fa-84ee-3b6fec0ef93a");
        //    var postService = new Mock<IPostService>();
        //    postService.Setup(p => p.GetPost(testId)).Returns(GetTestPosts().FirstOrDefault(p => p.Id == testId));
        //    var commentService = new Mock<ICommentService>();
        //    var categoryService = new Mock<IPostCategoryService>();
        //    var reportService = new Mock<IReportService>();
        //    var reportCategoryService = new Mock<IReportCategoryService>();
        //    var image = new Mock<ImageService>();
        //    var webHostEnvironment = new Mock<IWebHostEnvironment>();
        //    var userManager = TestUserManager<ApplicationUser>();
        //    var hubContext = new Mock<IHubContext<CommentsHub>>();
        //    var logger = new Mock<ILogger<BlogController>>();

        //    var controller = new BlogController(postService.Object, commentService.Object, categoryService.Object, reportService.Object, reportCategoryService.Object, image.Object, webHostEnvironment.Object, userManager, hubContext.Object, logger.Object);

        //    var result = controller.DetailsAsync(testId);

        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model = Assert.IsType<Post>(viewResult.ViewData.Model);
        //    Assert.Equal("Test Post 3", model.Title);
        //    Assert.Equal("Test Post 3", model.Content);
        //    Assert.Equal(testId, model.Id);
        //}

    }
}
