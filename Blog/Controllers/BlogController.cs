using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Hubs;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Services.CategoryService;
using Services.CommentService;
using Services.PostService;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHubContext<CommentHub> hubContext;

        public BlogController(IPostService postService, ICommentService commentService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IHubContext<CommentHub> hubContext)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Post model;
            if (id == default)
            {
                model = new Post();
            }
            else
            {
                model = postService.GetPost(id);
            }
            IQueryable<Category> categories = categoryService.GetCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post model, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                model.User = await userManager.GetUserAsync(HttpContext.User);
                if (imageFile != null)
                {
                    model.TitleImagePath = imageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "images/", imageFile.FileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                }
                postService.UpdatePost(model);
                return RedirectToAction(nameof(BlogController.EditPosts), nameof(BlogController).Replace("Controller", ""));
            }
            return View(model);
        }

        public async Task<IActionResult> EditPosts()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(postService.GetPostsByUser(user));
        }

        public async Task<IActionResult> Posts()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(postService.GetPostsByUser(user));
        }

        public IActionResult Delete(Guid id)
        {
            postService.DeletePost(id);
            return RedirectToAction(nameof(BlogController.EditPosts), nameof(BlogController).Replace("Controller", ""));
        }

        public IActionResult Detail(Guid id)
        {
            var article = postService.GetPost(id);
            var comments = commentService.GetCommentsByPost(article);
            ViewBag.Comments = comments;
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string content, Guid id)
        {
            Comment comment = new Comment();
            var user = await userManager.GetUserAsync(HttpContext.User);
            comment.Post = postService.GetPost(id);
            comment.User = user;
            comment.Content = content;
            commentService.InsertComment(comment);
            var comments = commentService.GetCommentsByPost(comment.Post);
            ViewBag.Comments = comments;
            await hubContext.Clients.All.SendAsync("Notify", $" {content}");
            return View("Detail", postService.GetPost(id));
        }
    }
}
