using DogusBlog.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sql_connection")));

var app = builder.Build();
SeedData.TestVerileriniDoldur(app);

app.MapDefaultControllerRoute();

app.Run();
