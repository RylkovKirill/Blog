using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class UsersViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
