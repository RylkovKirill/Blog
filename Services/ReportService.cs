using Entities;
using Repositories;
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

        public Report GetReport(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Report> GetReports()
        {
            return _repository.GetAll();
        }

        public IQueryable<Report> GetReportsByUser(ApplicationUser user)
        {
            return _repository.GetAll().Where(r => r.User.Equals(user));
        }

        public IQueryable<Report> GetReportsByPost(Post post)
        {
            return _repository.GetAll().Where(r => r.Post.Equals(post));
        }

        public void AddReport(Report report)
        {
            _repository.Add(report);
        }

        public void UpdateReport(Report report)
        {
            _repository.Update(report);
        }

        public void RemoveReport(Guid id)
        {
            _repository.Remove(GetReport(id));
        }
    }
}
