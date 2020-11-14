using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class RoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<string> UserRoles { get; set; }

        public RoleViewModel(string UserId, string UserName, List<IdentityRole> Roles, List<string> UserRoles)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Roles = new List<IdentityRole>(Roles);
            this.UserRoles = new List<string>(UserRoles);
        }
    }
}
