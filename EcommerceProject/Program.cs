using EcommerceProject.Data;
using EcommerceProject.Helper;
using EcommerceProject.Interface;
using EcommerceProject.Models;
using EcommerceProject.Repositories;
using EcommerceProject.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnection")));
builder.Services.AddIdentity<AppUsers, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddRoles<IdentityRole>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddTransient<IPhotoServices, PhotoServices>();
builder.Services.AddTransient<IMensRepository, MensRepository>();
builder.Services.AddTransient<IWomensRepository, WomensRepository>();
builder.Services.AddTransient<IAddToCartRepository, AddToCartRepository>();
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    await Seed.SeedUsersAndRolesAsync(app);
    //Seed.SeedData(app);
}

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
