using CHEZSWA.Models.Repositories;
using CHEZSWA.Models;   
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ChezSwaDbContext>(options =>
    options.UseSqlServer(conString));

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ChezSwaDbContext>(x => x.UseSqlServer(conString));

builder.Services.AddSingleton<MenuRepository>();
builder.Services.AddScoped<ReservatieRepository>();
var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
