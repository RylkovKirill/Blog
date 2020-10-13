using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Список постов")]
        public List<Post> Posts { get; set; }

        [Display(Name = "Список комментариев")]
        public List<Comment> Comments { get; set; }
    }
}
