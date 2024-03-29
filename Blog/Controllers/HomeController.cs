﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Services;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;

namespace Blog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPostCategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IReviewService _reviewService;
        private readonly ILogger<HomeController> _logger;
        private int pageSize = 5;

        public HomeController(IPostCategoryService categoryService, IPostService postService, ICommentService commentService, ILogger<HomeController> logger, IReviewService reviewService)
        {
            _categoryService = categoryService;
            _postService = postService;
            _commentService = commentService;
            _reviewService = reviewService;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync(string name = null, int page = 1)
        {
            //throw new ArgumentException("Test Error");
            IQueryable<Post> source;

            ViewBag.Name = name;

            if (name != null)
            {
                source = _postService.FilterByPostedDate(_postService.GetAll(name));
            }
            else
            {
                source = _postService.FilterByPostedDate(_postService.GetAll());
            }

            var count =await source.CountAsync();
            var items =await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            PostsViewModel viewModel = new PostsViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };



            return View(viewModel);
        }

        public IActionResult Search(string name, int page = 1)
        {
            IQueryable<Post> source;

            ViewBag.Name = name;

            if (name != null)
            {
                source = _postService.FilterByPostedDate(_postService.GetAll(name));
            }
            else
            {
                source = _postService.FilterByPostedDate(_postService.GetAll());
            }

            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            PostsViewModel viewModel = new PostsViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };

            return PartialView(viewModel);
        }

        public IActionResult SpecialIndex(string sortCategory)
        {
            var source = _postService.FilterByPostedDate(_postService.GetAll());

            switch (sortCategory)
            {
                case "PostedDate": 
                    source = _postService.SortedByPostedDate(source).Take(20);
                    ViewData["Title"] = "Новые";
                    break;
                case "Score": 
                    source = _reviewService.SortedByScore(source).Take(20);
                    ViewData["Title"] = "Популярные";
                    break;
            };

            return View(source.ToList());
        }

        public IActionResult IndexCategories()
        {
            var categories = _categoryService.GetAll();
            return View(categories.ToList());
        }

        public async Task<IActionResult> IndexByCategoryAsync(string id, int page = 1)
        {
            var posts = _postService.FilterByPostedDate(_postService.GetAll(_categoryService.Get(Guid.Parse(id))));

            if (posts == null)
            {
                return NotFound();
            }

            var count = await posts.CountAsync();
            var items = await posts.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            PostsViewModel viewModel = new PostsViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
