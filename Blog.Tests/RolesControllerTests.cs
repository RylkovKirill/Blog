using Blog.Areas.Admin.Controllers;
using Blog.Controllers;
using Blog.Hubs;
using Blog.Service;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Services.CategoryService;
using Services.CommentService;
using Services.PostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Blog.Tests
{
    public class RolesControllerTests
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

        public static Mock<RoleManager<TRole>> MockRoleManager<TRole>(IRoleStore<TRole> store = null) where TRole : class
        {
            store = store ?? new Mock<IRoleStore<TRole>>().Object;
            var roles = new List<IRoleValidator<TRole>>();
            roles.Add(new RoleValidator<TRole>());
            return new Mock<RoleManager<TRole>>(store, roles, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null);
        }

        private IQueryable<IdentityRole> Roles()
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id="3102e72c-db4e-4e34-96fc-82897328eab6", Name="role 1"},
                new IdentityRole { Id="fee4b05f-9376-4de5-bee2-623acd11c4c5", Name="role 2"},
                new IdentityRole { Id="2b5284ff-e2f5-4ffd-8d3d-4d951d81165f", Name="role 3"},
                new IdentityRole { Id="24452a95-0b6a-4882-9c9c-0374258b2613", Name="role 4"},
                new IdentityRole { Id="fa6b2367-7898-4a60-8445-792befff8703", Name="role 5"},
            };
            return roles.AsQueryable();
        }

        [Fact]
        public void Index()
        {
            var userManager = MockUserManager<ApplicationUser>();
            var roleManager = MockRoleManager<IdentityRole>();
            roleManager.Setup(p => p.Roles).Returns(Roles());

            var controller = new RolesController(userManager.Object, roleManager.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IQueryable<IdentityRole>>(viewResult.Model);
            Assert.Equal(Roles().Count(), model.Count());
        }

        [Fact]
        public void Create()
        {

        }
    }
}
