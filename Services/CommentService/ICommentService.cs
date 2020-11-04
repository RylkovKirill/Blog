using Entities;
using System;
using System.Linq;

namespace Services.CommentService
{
    public interface ICommentService
    {
        Comment GetComment(Guid id);
        IQueryable<Comment> GetComments();
        IQueryable<Comment> GetCommentsByUser(ApplicationUser user);
        IQueryable<Comment> GetCommentsByPost(Post post);
        void AddComment(Comment user);
        void UpdateComment(Comment user);
        void RemoveComment(Guid id);
    }
}
