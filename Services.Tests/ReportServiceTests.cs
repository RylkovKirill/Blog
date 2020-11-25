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
    public class ReportServiceTests
    {
        private IConfiguration configuration;
        private ApplicationDbContext applicationDbContext;
        private Repository<Report> repository;
        private ReportService reportService;

        public ReportServiceTests()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
            configuration = configurationBuilder.Build();
        }

        [Fact]
        public void GetReportTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Report>(applicationDbContext);
            reportService = new ReportService(repository);
            applicationDbContext.Reports.Add(new Report() { Id = Guid.Parse("401a67e1-e241-456e-b8d9-def83405bdbc") });
            applicationDbContext.SaveChanges();
            var report = reportService.Get(Guid.Parse("401a67e1-e241-456e-b8d9-def83405bdbc"));
            Assert.NotNull(report);
            Assert.IsType<Report>(report);
            Assert.Equal(Guid.Parse("401a67e1-e241-456e-b8d9-def83405bdbc"), report.Id);
        }

        [Fact]
        public void GetReportsTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Report>(applicationDbContext);
            reportService = new ReportService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reports.Add(new Report() { Id = Guid.NewGuid() });
            }
            applicationDbContext.SaveChanges();
            var reports = reportService.GetAll();
            Assert.NotNull(reports);
            Assert.Equal(10, reports.Count());
        }

        [Fact]
        public void GetReportsByUserTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Report>(applicationDbContext);
            reportService = new ReportService(repository);
            var user = UserHelpers.AddUser(applicationDbContext);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reports.Add(new Report() { Id = Guid.NewGuid(), User = user });
            }
            applicationDbContext.SaveChanges();
            var reports = reportService.GetAll(user);
            Assert.NotNull(reports);
            Assert.Equal(10, reports.Count());
            for (int i = 0; i < reports.Count(); i++)
            {
                Assert.Equal(user, reports.ToArray()[i].User);
            }
        }

        [Fact]
        public void GetReportsByPostTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Report>(applicationDbContext);
            reportService = new ReportService(repository);
            Post post = new Post() { Id = Guid.Parse("9204045b-6695-4bb8-8359-81b77c19dd3f"), Title = "Title", Content = "Content" };
            applicationDbContext.Posts.Add(post);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.Reports.Add(new Report() { Id = Guid.NewGuid(), Post = post });
            }
            applicationDbContext.SaveChanges();
            var reports = reportService.GetAll(post);
            Assert.NotNull(reports);
            Assert.Equal(10, reports.Count());
            for (int i = 0; i < reports.Count(); i++)
            {
                Assert.Equal(post, reports.ToArray()[i].Post);
            }
        }

        [Fact]
        public void AddReportTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Report>(applicationDbContext);
            reportService = new ReportService(repository);
            reportService.Add(new Report() { Id = Guid.Parse("1b7b7549-9338-43dc-a1a1-de9b9a40bf60") });
            Assert.Equal(1, applicationDbContext.Reports.Count());
        }

        [Fact]
        public void UpdateReportTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Report>(applicationDbContext);
            reportService = new ReportService(repository);
            reportService.Add(new Report() { Id = Guid.Parse("5df72e56-a5af-4fcb-8151-5d7812640dc8") });
            applicationDbContext.SaveChanges();
            Report reports = applicationDbContext.Reports.SingleOrDefault(s => s.Id == Guid.Parse("5df72e56-a5af-4fcb-8151-5d7812640dc8"));
            reportService.Update(reports);
            Assert.Equal(1, applicationDbContext.Reports.Count());
        }

        [Fact]
        public void RemoveReportTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, configuration);
            repository = new Repository<Report>(applicationDbContext);
            reportService = new ReportService(repository);
            reportService.Add(new Report() { Id = Guid.Parse("22e34370-ee6f-415c-a177-159e87a2b4d8") });
            applicationDbContext.SaveChanges();
            reportService.Remove(Guid.Parse("22e34370-ee6f-415c-a177-159e87a2b4d8"));
            Assert.Equal(0, applicationDbContext.Reports.Count());
        }
    }
}
