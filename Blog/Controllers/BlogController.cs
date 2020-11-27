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
using Microsoft.AspNetCore.Authorization;
using Services;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Services.Interfaces;

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
        private readonly ImageService _imageService;
        private readonly TimeZoneService _timeZoneService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<BlogController> _logger;
        private readonly IConfiguration _configuration;


        public BlogController(IPostCategoryService postCategoryService, IPostService postService, ICommentService commentService, IReviewService reviewService, IReportCategoryService reportCategoryService, IReportService reportService, ImageService imageService, TimeZoneService timeZoneService, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, ILogger<BlogController> logger, IConfiguration configuration)
        {
            _postCategoryService = postCategoryService;
            _postService = postService;
            _commentService = commentService;
            _reviewService = reviewService;
            _reportCategoryService = reportCategoryService;
            _reportService = reportService;
            _imageService = imageService;
            _timeZoneService = timeZoneService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            return View(_postService.GetAll(user));
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
                post = _postService.Get(id);
                if (post == null)
                {
                    return NotFound();
                }
            }
            post.PostedDate = _timeZoneService.GetLocalDateTime(post.PostedDate);
            ViewBag.Categories = new SelectList(_postCategoryService.GetAll(), "Id", "Name");
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Post post, IFormFile imageFile)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                post.UserId = user.Id;

                if (imageFile != null)
                {
                    post.TitleImagePath = _imageService.Save(imageFile, this._webHostEnvironment, _configuration["ImagePath:Post"], post.UserId + "-" + post.PostedDate.ToString("dd-MM-yyyy-hh-mm-ss"));
                }
                post.PostedDate = _timeZoneService.GetUTCDateTime(post.PostedDate);
                _postService.Update(post);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_postCategoryService.GetAll(), "Id", "Name");
            return View(post);
        }

        public IActionResult Delete(Guid id, string imagePath)
        {
            if (imagePath != null)
            {
                _imageService.Delete(imagePath, _webHostEnvironment, _configuration["ImagePath:Post"]);
            }
            _postService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetailsAsync(Guid id)
        {
            var post = _postService.Get(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var review = _reviewService.Get(user, post);

            if (post == null)
            {
                return NotFound();
            }

            var comments = _commentService.GetAll(post).ToList();
            foreach (Comment comment in comments)
            {
                comment.User = await _userManager.FindByIdAsync(comment.UserId);
            }

            ViewBag.Comments = comments;
            var reviews = _reviewService.GetAll(post);
            var reviewCount = _reviewService.GetReviewsCount(reviews);
            var averageScore = _reviewService.GetReviewsAverageScore(reviews);
            ViewBag.ReviewCount = reviewCount;
            ViewBag.AverageScore = averageScore;
            if (review == null)
            {
                ViewBag.Score = 0;
            }
            else
            {
                ViewBag.Score = review.Score;
            }

            if (ViewBag.AverageScore == null)
            {
                ViewBag.AverageScore = "У поста ещё нет рейтинга";
            }
            return View(post);
        }

        [HttpPost]
        public async Task<JsonResult> AddReview(Guid id, int score)
        {
            var post = _postService.Get(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var reviews = _reviewService.GetAll(post);
            var review = _reviewService.Get(user, post);

            if (review == null)
            {
                review = new Review
                {
                    User = user,
                    Post = post,
                };
            }
            review.Score = score;

            _reviewService.Update(review);

            int reviewCount = _reviewService.GetReviewsCount(reviews);
            double? averageScore = _reviewService.GetReviewsAverageScore(reviews);

            return Json(new { reviewCount, averageScore });
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(Guid id, Guid reportCategoryId)
        {
            var post = _postService.Get(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var report = _reportService.Get(user, post);

            if (report == null)
            {
                report = new Report
                {
                    Post = post,
                    User = user,
                };
            }
            report.CategoryId = reportCategoryId;

            _reportService.Update(report);
            return RedirectToAction("Details", new { id });
        }
    }
}
