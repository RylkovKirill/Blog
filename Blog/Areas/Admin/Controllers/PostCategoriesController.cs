using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.PostCategoryService;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PostCategoriesController : Controller
    {
        private readonly IPostCategoryService _categoryService;

        public PostCategoriesController(IPostCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostCategory category)
        {
            _categoryService.UpdateCategory(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var category = _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(PostCategory category)
        {
            _categoryService.UpdateCategory(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _categoryService.DeleteCategory(id);

            return RedirectToAction("Index");
        }
    }
}
