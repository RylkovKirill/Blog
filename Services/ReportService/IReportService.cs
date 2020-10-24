using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ReportService
{
    public interface IReportService
    {
        Report GetReport(Guid id);
        IQueryable<Report> GetReports();
        IQueryable<Report> GetReportsByUser(ApplicationUser user);
        IQueryable<Report> GetReportsByPost(Post post);
        void InsertReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(Guid id);
    }
}
