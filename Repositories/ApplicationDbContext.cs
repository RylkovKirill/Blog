using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories.Mappings;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportCategory> ReportCategories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ApplicationUserMap(modelBuilder.Entity<ApplicationUser>());
            new PostMap(modelBuilder.Entity<Post>());
            new ChatMap(modelBuilder.Entity<Chat>());
            new CommentMap(modelBuilder.Entity<Comment>());
            new MessageMap(modelBuilder.Entity<Message>());
            new PostCategoryMap(modelBuilder.Entity<PostCategory>());
            new PostTagMap(modelBuilder.Entity<PostTag>());
            new ReportMap(modelBuilder.Entity<Report>());
            new ReportCategoryMap(modelBuilder.Entity<ReportCategory>());
            new RequestMap(modelBuilder.Entity<Request>());
            new ReviewMap(modelBuilder.Entity<Review>());
            new TagMap(modelBuilder.Entity<Tag>());

            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("e0124c8f-cd37-4093-b8d1-b62dfac7f2cb"), Name = "Дом и сад", });
            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("cab6fa8f-6467-4f1f-9267-af8d35d3a0a7"), Name = "Еда и напитки", });
            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("5177e626-a357-4722-af79-9a9efb43193e"), Name = "Здоровье и фитнес", });
            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("b9afdb0b-87f1-484a-886d-a66d591b6cfa"), Name = "Наука и техника", });
            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("d1ef5ca8-6510-4768-9207-b1aac15989fd"), Name = "Новости и политика", });
            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("e2fe0327-4d9a-4d6f-ba7c-4f58a107fd15"), Name = "Развлечение", });
            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("e6fd90a4-ffbc-498b-a3d8-646ae10784a9"), Name = "Разное", });
            modelBuilder.Entity<PostCategory>().HasData(new PostCategory { Id = Guid.Parse("2c1bd27d-1cf7-46bd-ad38-ae8b0199eedf"), Name = "Спорт", });

            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("6c8b430f-99bf-460d-903e-198728353a72"), Name = "Контент сексуального характера", });
            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("0d50b5d6-2274-4f74-a478-7671242e1348"), Name = "Жестокие или отталкивающие сцены", });
            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("83ba1239-4ef7-44a7-ae91-c5c9d0e6c100"), Name = "Оскорбления или проявления нетерпимости", });
            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("06568472-51b4-4292-b7e0-a220b789c885"), Name = "Вредные или опасные действия", });
            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("520eeb61-256a-4edd-9476-5fbe69cc3f20"), Name = "Жестокое обращение с детьми", });
            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("516fff94-dfd1-4c94-bebd-9498048eac3d"), Name = "Нарушение моих прав", });
            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("bacc901a-c8fd-4f8c-b4f7-30e8a5b0d502"), Name = "Пропаганда терроризма", });
            modelBuilder.Entity<ReportCategory>().HasData(new ReportCategory { Id = Guid.Parse("7eca2608-2bf8-482b-a630-8e7eb2bc8724"), Name = "Спам или ложная информация", });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "e16895dd-7352-4cb4-b1b6-2a97f596e2ae",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "b809eea3-e39d-4721-b56e-7a19be0b34d4",
                UserName = _configuration["AdminSettings:UserName"],
                NormalizedUserName = _configuration["AdminSettings:UserName"].ToUpper(),
                Email = _configuration["AdminSettings:Email"],
                NormalizedEmail = _configuration["AdminSettings:Email"].ToUpper(),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, _configuration["AdminSettings:Password"]),
                EmailConfirmed = bool.Parse(_configuration["AdminSettings:EmailConfirmed"]),
                SecurityStamp = string.Empty,
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "e16895dd-7352-4cb4-b1b6-2a97f596e2ae",
                UserId = "b809eea3-e39d-4721-b56e-7a19be0b34d4"
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connection = "Data Source=tcp:blogdbserver.database.windows.net,1433;Initial Catalog=Blog_db;User Id=bsa@blogdbserver;Password=m8RwntY%ew";
            //optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("Blog"));
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ApplicationDbContextConnection"), b => b.MigrationsAssembly("Blog"));
        }
    }
}
