using Entities;
using Repositories;
using System;
using System.Linq;

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

        public void AddCategory(ReportCategory category)
        {
            _repository.Add(category);
        }

        public void UpdateCategory(ReportCategory category)
        {
            _repository.Update(category);
        }

        public void RemoveCategory(Guid id)
        {
            _repository.Remove(GetCategory(id));
        }
    }
}
