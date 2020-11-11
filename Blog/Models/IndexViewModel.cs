﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
