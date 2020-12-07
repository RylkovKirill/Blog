using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class FriendsViewModel
    {
        public List<ApplicationUser> Friends { get; set; }
        public List<Request> Requests { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
