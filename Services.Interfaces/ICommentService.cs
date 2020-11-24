using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public interface ICommentService
    {
        Comment GetComment(Guid id);
        IQueryable<Comment> GetComments();
        IQueryable<Comment> GetCommentsByUser(ApplicationUser user);
        IList<Comment> GetCommentsByPost(Post post);
        ///IQueryable<Comment> GetCommentsByPost(Post post);
        void AddComment(Comment user);
        void UpdateComment(Comment user);
        void RemoveComment(Guid id);
    }
}
