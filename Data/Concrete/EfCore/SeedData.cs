using Microsoft.EntityFrameworkCore;
using DogusBlog.Entity;

namespace DogusBlog.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){
                context.Database.Migrate();
            }

            if(!context.Tags.Any()){
                context.Tags.AddRange(
                    new Tag{Text="web programlama"},
                    new Tag{Text="backend"},
                    new Tag{Text="frontend"},
                    new Tag{Text="game"},
                    new Tag{Text="fullstack"}
                );
                context.SaveChanges();
            }

            if(!context.Users.Any()){
                context.Users.AddRange(
                    new User{UserName = "ahmetkaya"},
                    new User{UserName = "mehmetguvercin"}
                );
                context.SaveChanges();

                }
            if(!context.Posts.Any()){
                context.Posts.AddRange(
                    new Post{
                        Title = "Doğuş Teknoloji Bootcamp.",
                        Content = "Doğuş Teknoloji.",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-20),
                        Tags = context.Tags.Take(2).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Asp.Net Core Bootcamp.",
                        Content = "Asp.Net Core dersleri başladı.",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-10),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Backend Bootcamp.",
                        Content = "Backend hakkında.",
                        IsActive = true,
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