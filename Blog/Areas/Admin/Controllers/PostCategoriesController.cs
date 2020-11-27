using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;
using Services.Interfaces;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PostCategoriesController : Controller
    {
        private readonly IPostCategoryService _categoryService;
        private readonly ImageService _imageService;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PostCategoriesController(IPostCategoryService categoryService, ImageService imageService, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _imageService = imageService;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var category = new PostCategory()
            {
                Id = Guid.NewGuid()
            };
            return View(category);
        }

        [HttpPost]
        public IActionResult Create(PostCategory category, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    category.TitleImagePath = _imageService.Save(imageFile, _webHostEnvironment, _configuration["ImagePath:PostCategory"], category.CreatedDate.ToString("dd-MM-yyyy-hh-mm-ss"));
                }
                _categoryService.Update(category);

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(PostCategory category, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    category.TitleImagePath = _imageService.Save(imageFile, _webHostEnvironment, _configuration["ImagePath:PostCategory"], category.CreatedDate.ToString("dd-MM-yyyy-hh-mm-ss"));
                }
                _categoryService.Update(category);

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(Guid id, string imagePath)
        {
            if (imagePath != null)
            {
                _imageService.Delete(imagePath, _webHostEnvironment, _configuration["ImagePath:PostCategory"]);
            }
            _categoryService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
