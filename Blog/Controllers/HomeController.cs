using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Services.PostService;
using Services.CommentService;
using Services.CategoryService;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IPostService postService, ICommentService commentService, ICategoryService categoryService)
        {
            _postService = postService;
            _commentService = commentService;
            _categoryService = categoryService;
            _logger = logger;
        }

        public IActionResult Posts()
        {
            //throw new ArgumentException("Test Error");
            return View(_postService.GetPosts());
        }

        public IActionResult Search(string name)
        {
            if (name != null)
            {
                return PartialView(_postService.GetPosts().Where(a => a.Title.Contains(name)));
            }
            else
            {
                return PartialView(_postService.GetPosts());
            }
        }

        public IActionResult NewPosts()
        {
            return View("Posts", _postService.GetPosts().Where(p => p.PostedDate >= DateTime.Now.AddDays(-7)));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
