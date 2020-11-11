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
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostCategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IPostCategoryService categoryService, IPostService postService, ICommentService commentService,  ILogger<HomeController> logger)
        {
            _categoryService = categoryService;
            _postService = postService;
            _commentService = commentService;

            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync(string name = null, int page = 1)
        {
            //throw new ArgumentException("Test Error");
            ViewBag.Name = name;
            int pageSize = 5;   // количество элементов на странице

            IQueryable<Post> source;
            if (name != null)
            {
                source = (_postService.GetPosts().Where(a => a.Title.Contains(name)));
            }
            else
            {
                source = (_postService.GetPosts());
            }
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };
            return View(viewModel);

            //return View(_postService.GetPosts());
        }

        public async Task<IActionResult> SearchAsync(string name, int page = 1)
        {
            int pageSize = 5;   // количество элементов на странице
            ViewBag.Name = name;
            IQueryable<Post> source;

            if (name != null)
            {
                source=(_postService.GetPosts().Where(a => a.Title.Contains(name)));
            }
            else
            {
                source = (_postService.GetPosts());
            }
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };
            return PartialView(viewModel);
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
