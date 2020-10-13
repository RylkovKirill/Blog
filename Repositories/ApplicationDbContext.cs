using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Mappings;
using System;

namespace Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ApplicationUserMap(modelBuilder.Entity<ApplicationUser>());
            new CategoryMap(modelBuilder.Entity<Category>());
            new CommentMap(modelBuilder.Entity<Comment>());
            new PostMap(modelBuilder.Entity<Post>());
            new PostTagMap(modelBuilder.Entity<PostTag>());
            new TagMap(modelBuilder.Entity<Tag>());

            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Дом и сад", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Еда и напитки", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Здоровье и фитнес", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Наука и техника", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Новости и политика", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Развлечение", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Разное", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Спорт", });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Blog-3A40BBA8-4AF9-4810-ABB8-D2E890670A43;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connection, (b => b.MigrationsAssembly("Blog")));
        }
    }
}
