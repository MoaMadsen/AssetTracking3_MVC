using AssetTracking3_MVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));;

/* Moa 2rd change builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();; */

// Add services to the container.
/* Moa 2nd change builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); */
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Moa --- options.SignIn.RequireConfirmedAccount = true.. This checking valid email address
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()   
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Display the name of the current culture.
Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
// Change the current culture to th-TH.
CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
Console.WriteLine("CurrentCulture is now {0}.", CultureInfo.CurrentCulture.Name);
// Display the name of the current UI culture.
Console.WriteLine("CurrentUICulture is {0}.", CultureInfo.CurrentUICulture.Name);
// Change the current UI culture to ja-JP.
CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
Console.WriteLine("CurrentUICulture is now {0}.", CultureInfo.CurrentUICulture.Name);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
