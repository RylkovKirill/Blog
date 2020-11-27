using Entities;
using System;
using System.Linq;

namespace Services.Interfaces
{
    public interface IReportService
    {
        Report Get(Guid id);
        Report Get(ApplicationUser user, Post post);
        IQueryable<Report> GetAll();
        IQueryable<Report> GetAll(ApplicationUser user);
        IQueryable<Report> GetAll(Post post);
        void Add(Report report);
        void Update(Report report);
        void Remove(Guid id);
    }
}
