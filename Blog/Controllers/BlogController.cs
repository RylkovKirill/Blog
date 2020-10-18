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
using Services.CategoryService;
using Services.CommentService;
using Services.PostService;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;
        private readonly ImageService _image;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<CommentHub> _hubContext;
        private readonly ILogger<BlogController> _logger;

        public BlogController(IPostService postService, ICommentService commentService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IHubContext<CommentHub> hubContext, ILogger<BlogController> logger, ImageService image)
        {
            _postService = postService;
            _commentService = commentService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _hubContext = hubContext;
            _logger = logger;
            _image = image;
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
                return RedirectToAction(nameof(EditPosts));
            }
            ViewBag.Categories = new SelectList(_categoryService.GetCategories(), "Id", "Name");
            return View(post);
        }

        public async Task<IActionResult> EditPosts()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(_postService.GetPostsByUser(user));
        }

        public async Task<IActionResult> Posts()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(_postService.GetPostsByUser(user));
        }

        public IActionResult Delete(Guid id)
        {
            _commentService.DeletePostComments(_postService.GetPost(id));
            _postService.DeletePost(id);
            return RedirectToAction(nameof(EditPosts));
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
            return View("Detail", _postService.GetPost(id));
        }
    }
}
