using Entities;
using Repositories;
using Services.Interfaces;
using System;
using System.Linq;

namespace Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report> _repository;

        public ReportService(IRepository<Report> repository)
        {
            _repository = repository;
        }

        public Report Get(Guid id)
        {
            return _repository.Get(id);
        }

        public Report Get( ApplicationUser user, Post post)
        {
            return _repository.GetAll().Where(r => r.User.Equals(user)).Where(r => r.Post.Equals(post)).SingleOrDefault();
        }

        public IQueryable<Report> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Report> GetAll(ApplicationUser user)
        {
            return _repository.GetAll().Where(r => r.User.Equals(user));
        }

        public IQueryable<Report> GetAll(Post post)
        {
            return _repository.GetAll().Where(r => r.Post.Equals(post));
        }

        public void Add(Report report)
        {
            _repository.Add(report);
        }

        public void Update(Report report)
        {
            _repository.Update(report);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(Get(id));
        }
    }
}
