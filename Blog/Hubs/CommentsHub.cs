using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Services;
using System;
using System.Threading.Tasks;

namespace Blog.Hubs
{
    public class CommentsHub : Hub
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TimeZoneService _timeZoneService;

        public CommentsHub(ICommentService commentService, UserManager<ApplicationUser> userManager, TimeZoneService timeZoneService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _timeZoneService = timeZoneService;
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendComment(string postId, string content)
        {
            var user = await _userManager.GetUserAsync(Context.User);

            Comment comment = new Comment
            {
                PostId = Guid.Parse(postId),
                User = user,
                Content = content
            };

            _commentService.AddComment(comment);
            //var postedDate = _timeZoneService.GetLocalDateTime(comment.PostedDate).ToString("G");
            await Clients.Group(postId).SendAsync("Send", user.UserName, comment.Content, comment.PostedDate.ToString("G"));
        }
    }
}
