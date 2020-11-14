using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Services.Tests
{
    public class ReportCategoryServiceTests
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext applicationDbContext;
        private Repository<ReportCategory> repository;
        private ReportCategoryService reportCategoryService;

        public ReportCategoryServiceTests()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
            _configuration = configurationBuilder.Build();
        }

        [Fact]
        public void GetCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<ReportCategory>(applicationDbContext);
            reportCategoryService = new ReportCategoryService(repository);
            applicationDbContext.ReportCategories.Add(new ReportCategory() { Id = Guid.Parse("6441e6a4-db3b-4701-b1d5-d5ab9f1c6793") });
            applicationDbContext.SaveChanges();
            var reportCategory = reportCategoryService.GetCategory(Guid.Parse("6441e6a4-db3b-4701-b1d5-d5ab9f1c6793"));
            Assert.NotNull(reportCategory);
            Assert.IsType<ReportCategory>(reportCategory);
            Assert.Equal(Guid.Parse("6441e6a4-db3b-4701-b1d5-d5ab9f1c6793"), reportCategory.Id);
        }

        [Fact]
        public void GetCategoriesTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<ReportCategory>(applicationDbContext);
            reportCategoryService = new ReportCategoryService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.ReportCategories.Add(new ReportCategory() { Id = Guid.NewGuid() });
            }
            applicationDbContext.SaveChanges();
            var reportCategories = reportCategoryService.GetCategories();
            Assert.NotNull(reportCategories);
            Assert.Equal(10, reportCategories.Count());
        } 

        [Fact]
        public void AddCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<ReportCategory>(applicationDbContext);
            reportCategoryService = new ReportCategoryService(repository);
            reportCategoryService.AddCategory(new ReportCategory() { Id = Guid.Parse("791ea5ae-a4c6-4f20-8b8f-f3c150fb62ec") });
            Assert.Equal(1, applicationDbContext.ReportCategories.Count());
        }

        [Fact]
        public void UpdateCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<ReportCategory>(applicationDbContext);
            reportCategoryService = new ReportCategoryService(repository);
            reportCategoryService.AddCategory(new ReportCategory() { Id = Guid.Parse("2eb1d729-8d4c-4a94-90b6-ed9dfbd0bc76") });
            applicationDbContext.SaveChanges();
            ReportCategory reports = applicationDbContext.ReportCategories.SingleOrDefault(s => s.Id == Guid.Parse("2eb1d729-8d4c-4a94-90b6-ed9dfbd0bc76"));
            reportCategoryService.UpdateCategory(reports);
            Assert.Equal(1, applicationDbContext.ReportCategories.Count());
        }

        [Fact]
        public void RemoveCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<ReportCategory>(applicationDbContext);
            reportCategoryService = new ReportCategoryService(repository);
            reportCategoryService.AddCategory(new ReportCategory() { Id = Guid.Parse("2d531f40-d0c2-474f-ab60-9cfcb07a999d") });
            applicationDbContext.SaveChanges();
            reportCategoryService.RemoveCategory(Guid.Parse("2d531f40-d0c2-474f-ab60-9cfcb07a999d"));
            Assert.Equal(0, applicationDbContext.ReportCategories.Count());
        }
    }
}
