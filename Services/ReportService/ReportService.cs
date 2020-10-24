using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ReportService
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
            return _repository.GetAll().Where(p => p.User.Equals(user));
        }

        public IQueryable<Report> GetReportsByPost(Post post)
        {
            return _repository.GetAll().Where(p => p.Post.Equals(post));
        }

        public void InsertReport(Report report)
        {
            _repository.Insert(report);
        }

        public void UpdateReport(Report report)
        {
            _repository.Update(report);
        }

        public void DeleteReport(Guid id)
        {
            _repository.Delete(GetReport(id));
        }
    }
}
