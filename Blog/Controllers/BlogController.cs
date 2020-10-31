using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Hubs;
using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Services.PostCategoryService;
using Services.CommentService;
using Services.PostService;
using Services.ReportService;
using Services.ReportCategoryService;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IPostCategoryService _categoryService;
        private readonly IReportService _reportService;
        private readonly IReportCategoryService _reportCategoryService;
        private readonly ImageService _image;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<CommentHub> _hubContext;
        private readonly ILogger<BlogController> _logger;


        public BlogController(IPostService postService, ICommentService commentService, IPostCategoryService categoryService, IReportService reportService, IReportCategoryService reportCategoryService, ImageService image, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IHubContext<CommentHub> hubContext, ILogger<BlogController> logger)
        {
            _postService = postService;
            _commentService = commentService;
            _categoryService = categoryService;
            _reportService = reportService;
            _reportCategoryService = reportCategoryService;
            _image = image;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return NotFound();
            }

            return View(_postService.GetPostsByUser(user));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Post post;
            if (id == default)
            {
                post = new Post();
            }
            else
            {
                post = _postService.GetPost(id);
                if (post == null)
                {
                    return NotFound();
                }
            }
            ViewBag.Categories = new SelectList(_categoryService.GetCategories(), "Id", "Name");
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Post post, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                post.User = await _userManager.GetUserAsync(HttpContext.User);
                if (imageFile != null)
                {
                    post.TitleImagePath = _image.Save(imageFile, this._webHostEnvironment);
                }
                _postService.UpdatePost(post);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_categoryService.GetCategories(), "Id", "Name");
            return View(post);
        }

        public IActionResult Delete(Guid id)
        {
            _commentService.DeletePostComments(_postService.GetPost(id));
            _postService.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid id)
        {
            var post = _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            var comments = _commentService.GetCommentsByPost(post);
            ViewBag.Comments = comments;
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string content, Guid id)
        {
            Comment comment = new Comment();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            comment.Post = _postService.GetPost(id);
            comment.User = user;
            comment.Content = content;
            _commentService.InsertComment(comment);
            var comments = _commentService.GetCommentsByPost(comment.Post);
            ViewBag.Comments = comments;
            await _hubContext.Clients.All.SendAsync("Notify", $" {content}", $" {_userManager.GetUserNameAsync(comment.User).Result}", $" {comment.PostedDate}");
            return View("Details", _postService.GetPost(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReport(Guid id, Guid reportCategoryId)
        {
            Report report = new Report();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            report.User = user;
            report.Post = _postService.GetPost(id);
            report.ReportCategory = _reportCategoryService.GetCategory(reportCategoryId);
            _reportService.InsertReport(report);
            return View("Details", _postService.GetPost(id));
        }
    }
}
