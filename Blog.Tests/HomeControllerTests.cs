using Blog.Controllers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Services.PostCategoryService;
using Services.CommentService;
using Services.PostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Blog.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            var _postService = new Mock<IPostService>();
            _postService.Setup(p => p.GetPosts()).Returns(GetTestPosts());
            var _commentService = new Mock<ICommentService>();
            var _categoryService = new Mock<IPostCategoryService>();
            var _logger = new Mock<ILogger<HomeController>>();

            HomeController controller = new HomeController(_postService.Object, _commentService.Object, _categoryService.Object, _logger.Object);

            var result = controller.IndexAsync();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IQueryable<Post>>(viewResult.Model);
            Assert.Equal(GetTestPosts().Count(), model.Count());
        }

        private IQueryable<Post> GetTestPosts()
        {
            var posts = new List<Post>
            {
                new Post { Id=Guid.NewGuid(), Title="Test Post 1", Content = "Test Post 1"},
                new Post { Id=Guid.NewGuid(), Title="Test Post 2", Content = "Test Post 2"},
                new Post { Id=Guid.NewGuid(), Title="Test Post 3", Content = "Test Post 3"},
                new Post { Id=Guid.NewGuid(), Title="Test Post 4", Content = "Test Post 4"},
                new Post { Id=Guid.NewGuid(), Title="Test Post 5", Content = "Test Post 5"},
            };
            return posts.AsQueryable();
        }
    }
}
