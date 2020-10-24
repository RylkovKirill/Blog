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
using Services.PostCategoryService;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IPostCategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPostService postService, ICommentService commentService, IPostCategoryService categoryService, ILogger<HomeController> logger)
        {
            _postService = postService;
            _commentService = commentService;
            _categoryService = categoryService;
            _logger = logger;
        }

        public IActionResult Index()
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
            return View("Index", _postService.GetPosts().Where(p => p.PostedDate >= DateTime.Now.AddDays(-7)));
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
