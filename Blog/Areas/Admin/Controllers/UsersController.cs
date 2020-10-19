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
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Message message;
        public UsersController(UserManager<ApplicationUser> userManager, Message message)
        {
            this.userManager = userManager;
            this.message = message;
        }

        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        public IActionResult Edit()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            MailMessage model = new MailMessage();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MailMessage model, Guid? Id)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(Id.ToString());
                model.From = new MailAddress("asp.net.core.blog@gmail.com", "Blog");
                model.To.Add(user.Email);
                message.SendMessage(model);
                return RedirectToAction(nameof(UsersController.Index), nameof(UsersController).Replace("Controller", ""));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Users");
        }
    }
}
