using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ReportCategoryService
{
    public class ReportCategoryService : IReportCategoryService
    {
        private readonly IRepository<ReportCategory> _repository;

        public ReportCategoryService(IRepository<ReportCategory> repository)
        {
            this._repository = repository;
        }

        public ReportCategory GetCategory(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<ReportCategory> GetCategories()
        {
            return _repository.GetAll();
        }

        public void InsertCategory(ReportCategory category)
        {
            _repository.Insert(category);
        }

        public void UpdateCategory(ReportCategory category)
        {
            _repository.Update(category);
        }

        public void DeleteCategory(Guid id)
        {
            _repository.Delete(GetCategory(id));
        }
    }
}
