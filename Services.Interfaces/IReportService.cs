using Entities;
using System;
using System.Linq;

namespace Services
{
    public interface IReportService
    {
        Report GetReport(Guid id);
        IQueryable<Report> GetReports();
        IQueryable<Report> GetReportsByUser(ApplicationUser user);
        IQueryable<Report> GetReportsByPost(Post post);
        void AddReport(Report report);
        void UpdateReport(Report report);
        void RemoveReport(Guid id);
    }
}
