using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        public UsersController(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public IActionResult Edit()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            MailMessage model = new MailMessage();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Guid Id, string subject, string htmlMessage)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Id.ToString());
                await _emailSender.SendEmailAsync(user.Email, subject, htmlMessage);
                return RedirectToAction(nameof(UsersController.Index), nameof(UsersController).Replace("Controller", ""));
            }
            return View();
        }
    }
}
