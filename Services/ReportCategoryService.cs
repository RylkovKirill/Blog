using Entities;
using Repositories;
using System;
using System.Linq;

namespace Services
{
    public class ReportCategoryService : IReportCategoryService
    {
        private readonly IRepository<ReportCategory> _repository;

        public ReportCategoryService(IRepository<ReportCategory> repository)
        {
           _repository = repository;
        }

        public ReportCategory Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<ReportCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(ReportCategory category)
        {
            _repository.Add(category);
        }

        public void Update(ReportCategory category)
        {
            _repository.Update(category);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(Get(id));
        }
    }
}
