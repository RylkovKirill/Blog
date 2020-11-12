using Entities;
using Microsoft.AspNetCore.Identity;
using Repositories;


namespace Services.Tests
{
    public static class UserHelpers
    {
        public static ApplicationUser AddUser(ApplicationDbContext applicationDbContext)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "ba576c28-7530-4fec-871f-02d98b0cb4e5",
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
