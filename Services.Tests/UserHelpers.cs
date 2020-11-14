using Entities;
using Microsoft.AspNetCore.Identity;
using Repositories;
using System;

namespace Services.Tests
{
    public static class UserHelpers
    {
        public static ApplicationUser AddUser(ApplicationDbContext applicationDbContext)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user",
                Email = "email",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password"),
            };
            applicationDbContext.ApplicationUsers.Add(user);
            applicationDbContext.SaveChanges();
            return user;
        }
    }
}
