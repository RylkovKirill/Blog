using Entities;
using Repositories;
using System;
using System.Linq;

namespace Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> repository;

        public CommentService(IRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public Comment GetComment(Guid id)
        {
            return repository.Get(id);
        }

        public IQueryable<Comment> GetComments()
        {
            return repository.GetAll();
        }

        public IQueryable<Comment> GetCommentsByUser(ApplicationUser user)
        {
            return repository.GetAll().Where(c => c.User.Equals(user));
        }

        public IQueryable<Comment> GetCommentsByPost(Post post)
        {
            return repository.GetAll().Where(c => c.Post.Equals(post)).OrderByDescending(c=> c.PostedDate);
        }

        public void AddComment(Comment comment)
        {
            repository.Add(comment);
        }

        public void UpdateComment(Comment comment)
        {
            repository.Update(comment);
        }

        public void RemoveComment(Guid id)
        {
            repository.Remove(GetComment(id));
        }
    }
}
