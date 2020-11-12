using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IPostService _postService;
        private readonly IPostCategoryService _postCategoryService;
        private readonly ImageService _image;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;


        public ReportsController(IReportService reportService, IPostService postService, IPostCategoryService postCategoryService, ImageService image, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _reportService = reportService;
            _postService = postService;
            _postCategoryService = postCategoryService;
            _image = image;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_reportService.GetReports());
        }

        public IActionResult Delete(Guid id)
        {
            _reportService.RemoveReport(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPost(Guid id)
        {
            var post = _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_postCategoryService.GetCategories(), "Id", "Name");

            return View(post);
        }

        [HttpPost]
        public IActionResult EditPost(Post post, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    post.TitleImagePath = _image.Save(imageFile, this._webHostEnvironment);
                }
                _postService.UpdatePost(post);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_postCategoryService.GetCategories(), "Id", "Name");
            return View(post);
        }

        public IActionResult DeletePost(Guid id)
        {
            _postService.RemovePost(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
