using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection db
builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectedDb")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(option =>
{
	option.IdleTimeout = TimeSpan.FromMinutes(30);
	option.Cookie.IsEssential = true;
});

// Identity

builder.Services.AddIdentity<AppUserModel, IdentityRole>()
	.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	// Password settings.
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 4;
	//options.Password.RequiredUniqueChars = 1;

	// Lockout settings.
	//options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	//options.Lockout.MaxFailedAccessAttempts = 5;
	//options.Lockout.AllowedForNewUsers = true;

	// User settings.
	//options.User.AllowedUserNameCharacters =
	//"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

	options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

// 404
app.UseStatusCodePagesWithRedirects("/Home/Error?statuscode={0}");

// 
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

// Identity on UseAuthorization
app.UseAuthentication(); // Login

app.UseAuthorization(); // Check role

app.MapControllerRoute(
	name: "Areas",
	pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "category",
	pattern: "/category/{Slug?}",
	defaults: new { controller = "Category", action = "Index" });

app.MapControllerRoute(
	name: "brand",
	pattern: "/brand/{Slug?}",
	defaults: new { controller = "Brand", action = "Index" });



app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");



// Seeding Data
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedingData(context);


app.Run();
