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
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;


        public ReportsController(IReportService reportService, IPostService postService, IPostCategoryService postCategoryService, ImageService image, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _reportService = reportService;
            _postService = postService;
            _postCategoryService = postCategoryService;
            _image = image;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View(_reportService.GetAll().ToList());
        }

        public IActionResult Delete(Guid id)
        {
            _reportService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPost(Guid id)
        {
            var post = _postService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_postCategoryService.GetAll(), "Id", "Name");

            return View(post);
        }

        [HttpPost]
        public IActionResult EditPost(Post post, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    post.TitleImagePath = _image.Save(imageFile, this._webHostEnvironment, _configuration["ImagePath:Post"], post.UserId + "-" + post.PostedDate.ToString("dd-MM-yyyy-hh-mm-ss"));
                }
                _postService.Update(post);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_postCategoryService.GetAll(), "Id", "Name");
            return View(post);
        }

        public IActionResult DeletePost(Guid id)
        {
            _postService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
