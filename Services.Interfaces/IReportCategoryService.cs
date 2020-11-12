using Entities;
using System;
using System.Linq;

namespace Services
{
    public interface IReportCategoryService
    {
        ReportCategory GetCategory(Guid id);
        IQueryable<ReportCategory> GetCategories();
        void AddCategory(ReportCategory category);
        void UpdateCategory(ReportCategory category);
        void RemoveCategory(Guid id);
    }
}
