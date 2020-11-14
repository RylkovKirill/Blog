using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories;
using System;
using System.Linq;
using Xunit;
namespace Services.Tests
{
    public class PostCategoryServiceTests
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext applicationDbContext;
        private Repository<PostCategory> repository;
        private PostCategoryService postCategoryService;

        public PostCategoryServiceTests()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddJsonFile("adminsettings.json").AddJsonFile("emailsettings.json");
            _configuration = configurationBuilder.Build();
        }

        [Fact]
        public void GetCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<PostCategory>(applicationDbContext);
            postCategoryService = new PostCategoryService(repository);
            applicationDbContext.PostCategories.Add(new PostCategory() { Id = Guid.Parse("44c8487f-6cd4-49c7-ae20-0af6f08e557d") });
            applicationDbContext.SaveChanges();
            var postCategory = postCategoryService.GetCategory(Guid.Parse("44c8487f-6cd4-49c7-ae20-0af6f08e557d"));
            Assert.NotNull(postCategory);
            Assert.IsType<PostCategory>(postCategory);
            Assert.Equal(Guid.Parse("44c8487f-6cd4-49c7-ae20-0af6f08e557d"), postCategory.Id);
        }

        [Fact]
        public void GetCategoriesTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<PostCategory>(applicationDbContext);
            postCategoryService = new PostCategoryService(repository);
            for (int i = 0; i < 10; i++)
            {
                applicationDbContext.PostCategories.Add(new PostCategory() { Id = Guid.NewGuid() });
            }
            applicationDbContext.SaveChanges();
            var postCategory = postCategoryService.GetCategories();
            Assert.NotNull(postCategory);
            Assert.Equal(10, postCategory.Count());
        }

        [Fact]
        public void AddCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<PostCategory>(applicationDbContext);
            postCategoryService = new PostCategoryService(repository);
            postCategoryService.AddCategory(new PostCategory() { Id = Guid.Parse("60a233e0-5fa1-4ee4-97aa-ddaa786d80fa") });
            Assert.Equal(1, applicationDbContext.PostCategories.Count());
        }

        [Fact]
        public void UpdateCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<PostCategory>(applicationDbContext);
            postCategoryService = new PostCategoryService(repository);
            postCategoryService.AddCategory(new PostCategory() { Id = Guid.Parse("117f991d-1f09-4a02-9880-e8fb1bdf287d") });
            applicationDbContext.SaveChanges();
            PostCategory postCategory = applicationDbContext.PostCategories.SingleOrDefault(s => s.Id == Guid.Parse("117f991d-1f09-4a02-9880-e8fb1bdf287d"));
            postCategoryService.UpdateCategory(postCategory);
            Assert.Equal(1, applicationDbContext.PostCategories.Count());
        }

        [Fact]
        public void RemoveCategoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            applicationDbContext = new ApplicationDbContext(builder.Options, _configuration);
            repository = new Repository<PostCategory>(applicationDbContext);
            postCategoryService = new PostCategoryService(repository);
            postCategoryService.AddCategory(new PostCategory() { Id = Guid.Parse("1717fcb1-f767-4652-ac64-7c265eafd571") });
            applicationDbContext.SaveChanges();
            postCategoryService.RemoveCategory(Guid.Parse("1717fcb1-f767-4652-ac64-7c265eafd571"));
            Assert.Equal(0, applicationDbContext.PostCategories.Count());
        }
    }
}
