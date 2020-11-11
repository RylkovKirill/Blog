using System;
using System.Threading.Tasks;
using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Services.PostCategoryService;
using Services.CommentService;
using Services.PostService;
using Services.ReportService;
using Services.ReportCategoryService;
using Microsoft.AspNetCore.Authorization;
using Services.ReviewService;

namespace Blog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IPostCategoryService _postCategoryService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IReviewService _reviewService;
        private readonly IReportCategoryService _reportCategoryService;
        private readonly IReportService _reportService;
        private readonly ImageService _image;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<BlogController> _logger;


        public BlogController(IPostCategoryService postCategoryService, IPostService postService, ICommentService commentService, IReviewService reviewService, IReportCategoryService reportCategoryService, IReportService reportService,  ImageService image, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, ILogger<BlogController> logger)
        {
            _postCategoryService = postCategoryService;
            _postService = postService;
            _commentService = commentService;
            _reviewService = reviewService;
            _reportCategoryService = reportCategoryService;
            _reportService = reportService;
            _image = image;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
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
            ViewBag.Categories = new SelectList(_postCategoryService.GetCategories(), "Id", "Name");
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
            ViewBag.Categories = new SelectList(_postCategoryService.GetCategories(), "Id", "Name");
            return View(post);
        }

        public IActionResult Delete(Guid id)
        {
            _postService.RemovePost(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DetailsAsync(Guid id)
        {
            var post = _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }
            var comments = _commentService.GetCommentsByPost(post);
            ViewBag.Comments = comments;
            var reviews = _reviewService.GetReviewsByPost(post);
            var reviewCount = _reviewService.GetReviewsCount(reviews);
            var averageScore = _reviewService.GetReviewsAverageScore(reviews);
            ViewBag.ReviewCount = reviewCount;
            ViewBag.AverageScore = averageScore;
            if (ViewBag.AverageScore == null)
            {
                ViewBag.AverageScore = "У поста ещё нет рейтинга";
            }
            return View(post);
        }

        [HttpPost]
        public async  Task<JsonResult> AddReview(Guid id, int score)
        {
            var post = _postService.GetPost(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var reviews = _reviewService.GetReviewsByPost(post);
            var review = _reviewService.GetReview(user, post);
            
            if(review == null)
            {
                review = new Review
                {
                    User = user,
                    Post = post,
                    Score = score
                };
            }
            else
            {
                review.Score = score;
            }

            _reviewService.UpdateReview(review);

            int reviewCount = _reviewService.GetReviewsCount(reviews);
            double? averageScore = _reviewService.GetReviewsAverageScore(reviews);

            return Json(new { reviewCount, averageScore });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReport(Guid id, Guid reportCategoryId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            Report report = new Report
            {
                User = user,
                Post = _postService.GetPost(id),
                ReportCategory = _reportCategoryService.GetCategory(reportCategoryId)
            };

            _reportService.AddReport(report);
            return View("Details", _postService.GetPost(id));
        }
    }
}
