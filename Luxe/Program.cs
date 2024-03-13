using Luxe.Models;
using Luxe.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LuxeDbContext>( options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:LuxeConnectionString"]);
});

var app = builder.Build();

app.UseStaticFiles();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

DbIntializer.Seed(app);

app.Run();
