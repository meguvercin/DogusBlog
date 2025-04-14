using Microsoft.EntityFrameworkCore;
using DogusBlog.Entity;

namespace DogusBlog.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.primary },
                        new Tag { Text = "backend", Url = "backend", Color = TagColors.danger },
                        new Tag { Text = "frontend", Url = "frontend", Color = TagColors.secondary },
                        new Tag { Text = "game", Url = "game", Color = TagColors.success },
                        new Tag { Text = "fullstack", Url = "full-stack", Color = TagColors.warning }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "ahmetkaya", Image = "img1.jpg", Name = "Ahmet Kaya", Email = "info@ahmetkaya.com", Password = "123456" },
                        new User { UserName = "meguvercin", Image = "img2.jpg", Name = "Mehmet Emin Güvercin", Email = "info@meguvercin.com", Password = "123456" }
                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Doğuş Teknoloji Bootcamp.",
                            Content = "Doğuş Teknoloji.",
                            Description = "Dogus teknoloji bootcap başladı .",
                            Url = "dogus-teknoloji-bootcamp",
                            IsActive = true,
                            Image = "Yazılım.jpg",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1,
                            Comments = new List<Comment>{
                                new Comment {Text = "Başarılı bir şekilde başlamadı",PublishedOn = new DateTime(),UserId =2},
                                new Comment {Text = "Başarılı bir şekilde başladı",PublishedOn = new DateTime(),UserId =1},
                            }
                        },
                        new Post
                        {
                            Title = "Asp.Net Core Bootcamp.",
                            Content = "Asp.Net Core dersleri başladı.",
                            Description = "Asp.net core dersleri .",
                            Url = "asp-net-core-bootcamp",
                            IsActive = true,
                            Image = "Yazılım2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Backend Bootcamp.",
                            Content = "Backend hakkında.",
                            Description = "Backend dersleri.",
                            Url = "backend-bootcamp",
                            IsActive = true,
                            Image = "Yazılım3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-25),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}