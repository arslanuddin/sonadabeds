using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SonadaBeds.Web.Data;
using SonadaBeds.Web.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SonadaDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(o => { o.SignIn.RequireConfirmedAccount = false; o.Password.RequireNonAlphanumeric = false; o.Password.RequiredLength = 8; }).AddRoles<IdentityRole>().AddEntityFrameworkStores<SonadaDbContext>();
builder.Services.AddSession(o => { o.Cookie.HttpOnly = true; o.Cookie.IsEssential = true; });
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CartService>();
var app = builder.Build();
if (!app.Environment.IsDevelopment()) { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); }
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute("areas", "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
using (var scope = app.Services.CreateScope()) { await SeedData.Initialize(scope.ServiceProvider); }
app.Run();
