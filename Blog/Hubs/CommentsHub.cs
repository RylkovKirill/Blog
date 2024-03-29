﻿using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Services;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Blog.Hubs
{
    public class CommentsHub : Hub
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsHub(ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
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

            _commentService.Add(comment);
            await Clients.Group(postId).SendAsync("Send", user.UserName, comment.Content, comment.PostedDate.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
        }
    }
}
