﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class PostCategory : Base
    {
        [Required(ErrorMessage = "Название не может быть пустым")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Список постов")]
        public List<Post> Posts { get; set; }
    }
}