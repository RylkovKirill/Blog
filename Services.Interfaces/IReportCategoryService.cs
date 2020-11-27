using Entities;
using System;
using System.Linq;

namespace Services.Interfaces
{
    public interface IReportCategoryService
    {
        ReportCategory Get(Guid id);
        IQueryable<ReportCategory> GetAll();
        void Add(ReportCategory category);
        void Update(ReportCategory category);
        void Remove(Guid id);
    }
}
