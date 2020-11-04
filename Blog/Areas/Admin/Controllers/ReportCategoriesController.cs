using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ReportCategoryService;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ReportCategoriesController : Controller
    {
        private readonly IReportCategoryService _reportCategoryService;

        public ReportCategoriesController(IReportCategoryService reportCategoryService)
        {
            _reportCategoryService = reportCategoryService;
        }

        public IActionResult Index()
        {
            var categories = _reportCategoryService.GetCategories();

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
        public IActionResult Create(ReportCategory category)
        {
            _reportCategoryService.UpdateCategory(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var category = _reportCategoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(ReportCategory category)
        {
            _reportCategoryService.UpdateCategory(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _reportCategoryService.RemoveCategory(id);

            return RedirectToAction("Index");
        }
    }
}
