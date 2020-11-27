using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Entities;
using Entities.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Blog.Controllers
{
    public class UserRelationshipController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRequestService _requestService;

        public UserRelationshipController(UserManager<ApplicationUser> userManager, IRequestService requestService)
        {
            _userManager = userManager;
            _requestService = requestService;
        }

        public async Task<IActionResult> FriendsAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var friends = _requestService.GetUserFriends(user);
            return View(friends);
        }

        public IActionResult Users()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> RequestsAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var requestsViewModel = new RequestViewModel()
            {
                OutgoingRequests = _requestService.GetAllOutgoingByUser(user),
                IncomingRequests = _requestService.GetAllIncomingByUser(user),
            };
            return View(requestsViewModel);
        }

        public async Task<IActionResult> AddToFriendsAsync(string userId)
        {
            var request = new Request()
            {
                UserReceiverId = userId,
                UserSender = await _userManager.GetUserAsync(HttpContext.User),
            };
            _requestService.Update(request);
            return RedirectToAction("Users");
        }

        public IActionResult ChangeRequestStatus(Guid requestId, bool confirmed)
        {
            var request = _requestService.Get(requestId);
            if (confirmed == true)
            {
                request.RequestStatus = RequestStatus.CONFIRMED;
                _requestService.Update(request);
            }
            else
            {
                _requestService.Remove(request.Id);
            }
            return RedirectToAction("Requests");
        }

        public IActionResult SendMessage()
        {
            var users = _userManager.Users;
            return View(users);
        }
    }
}
