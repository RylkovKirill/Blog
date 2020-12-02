using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UsersMapController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersMapController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public List<PlacemarkViewModel> GetMarks()
        {
            var users = _userManager.Users.Where(p => (p.Latitude != 0 && p.Longitude != 0)).ToList();

            List<PlacemarkViewModel> markers = new List<PlacemarkViewModel>();

            foreach (var user in users)
            {
                markers.Add(
                    new PlacemarkViewModel
                    {
                        x = user.Latitude,
                        y = user.Longitude,
                        balloonCloseButton = true,
                        balloonContent = $"<div>" + user.Email + "</div>",
                        hideIconOnBalloonOpen = false,
                        preset = "islands#yellowStretchyIcon"
                    });
            }
            return markers;
        }
    }
}
