using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public List<MapMarker> GetMarks()
        {
            var places = _userManager.Users.ToList();

            List<MapMarker> markers = new List<MapMarker>();


            foreach (var place in places)
            {
                markers.Add(
                    new MapMarker
                    {
                        x = place.Latitude,
                        y = place.Longitude,
                        balloonCloseButton = true,
                        balloonContent =
                            $"<div> В этом месте проголоcовало: </div>",
                        hideIconOnBalloonOpen = false,
                        preset = "islands#yellowStretchyIcon"
                    });
            }
            return markers;
        }
    }

    public  class MapMarker : ApplicationUser
    {
        public double x { get; set; }
        public double y { get; set; }
        public bool balloonCloseButton { get; set; }
        public string balloonContent { get; set; }
        public bool hideIconOnBalloonOpen { get; set; }
        public string iconContent { get; set; }
        public string preset { get; set; }
    }
}
