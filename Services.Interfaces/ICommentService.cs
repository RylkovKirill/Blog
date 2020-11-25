using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public interface ICommentService
    {
        Comment Get(Guid id);
        IQueryable<Comment> GetAll();
        IQueryable<Comment> GetAll(ApplicationUser user);
        IQueryable<Comment> GetAll(Post post);
        void Add(Comment user);
        void Update(Comment user);
        void Remove(Guid id);
    }
}
