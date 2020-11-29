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
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;

        public UserRelationshipController(UserManager<ApplicationUser> userManager, IRequestService requestService, IChatService chatService, IMessageService messageService)
        {
            _userManager = userManager;
            _requestService = requestService;
            _chatService = chatService;
            _messageService = messageService;
        }

        public async Task<IActionResult> FriendsAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var friends = _requestService.GetUserFriends(user).ToList();
            List<Request> requests = new List<Request>();
            foreach (var friend in friends)
            {
                requests.Add(_requestService.Get(user, friend));
            }
            var friendsViewModel = new FriendsViewModel()
            {
                Friends = friends,
                Requests = requests

            };
            return View(friendsViewModel);
        }

        public async Task<IActionResult> UsersAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var users = new UsersViewModel()
            {
                Users = _userManager.Users.Where(u => u != user).ToList(),
                Friends = _requestService.GetUserFriends(user).ToList()
            };
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

        public async Task<IActionResult> ChatAsync(string userId)
        {
            var user1 = await _userManager.GetUserAsync(HttpContext.User);
            var user2 = _userManager.FindByIdAsync(userId).Result;
            var chat = _chatService.Get(user1, user2);
            if(chat == default)
            {
                chat = new Chat()
                {
                    FirstUser = user1,
                    SecondUser = user2,
                };
                _chatService.Update(chat);
            }
            chat.Messages = _messageService.GetAll(chat).ToList();
            return View(chat);
        }
    }
}
