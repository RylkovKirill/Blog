using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;

        public CommentService(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public Comment GetComment(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Comment> GetComments()
        {
            return _repository.GetAll();
        }

        public IQueryable<Comment> GetCommentsByUser(ApplicationUser user)
        {
            return _repository.GetAll().Where(c => c.User.Equals(user));
        }

        public IList<Comment> GetCommentsByPost(Post post)
        {
            return _repository.GetAll().Where(c => c.Post.Equals(post)).OrderByDescending(c => c.PostedDate).ToList();
        }

        //public IQueryable<Comment> GetCommentsByPost(Post post)
        //{
        //    return _repository.GetAll().Where(c => c.Post.Equals(post)).OrderByDescending(c=> c.PostedDate);
        //}

        public void AddComment(Comment comment)
        {
            _repository.Add(comment);
        }

        public void UpdateComment(Comment comment)
        {
            _repository.Update(comment);
        }

        public void RemoveComment(Guid id)
        {
            _repository.Remove(GetComment(id));
        }
    }
}
