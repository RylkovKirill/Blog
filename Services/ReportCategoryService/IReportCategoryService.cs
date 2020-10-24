using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ReportCategoryService
{
    public interface IReportCategoryService
    {
        ReportCategory GetCategory(Guid id);
        IQueryable<ReportCategory> GetCategories();
        void InsertCategory(ReportCategory category);
        void UpdateCategory(ReportCategory category);
        void DeleteCategory(Guid id);
    }
}
