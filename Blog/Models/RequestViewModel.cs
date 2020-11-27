using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class RequestViewModel
    {
        public IQueryable<Request> OutgoingRequests { get; set; }
        public IQueryable<Request> IncomingRequests { get; set; }
    }
}
