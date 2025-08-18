using System.Net;
using AppMVC.Net.ExtendMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSingleton<AppMVC.Net.Models.ProductService>(); // Register ProductService as a singleton
builder.Services.AddSingleton<AppMVC.Net.Services.PlanetService>(); // Register PlanetModel as a singleton


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

app.UseAuthentication(); // xac dinh danh tinh
app.UseAuthorization(); // xacs thuc quyen truy cap

// chỉ tạo route đến các controller không có area 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "product",
    pattern: "/{controller}/{action=Index}/{id?}",
    areaName: "ProductManager"    
);
app.MapRazorPages();

app.AddStatusCodePage(); // Tuy bien respone error 400-599 trong file AppExtends.cs

app.Run();
