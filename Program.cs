using Kazanola.Areas.Admin.MyClass;
using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.MyClass;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClassHelper, HelperClass>();
builder.Services.AddScoped<IUserRepository<Users>, UserRepository>();
builder.Services.AddScoped<ISaleBanerReposetory<SaleBaner>, SaleBanerRepository>();
builder.Services.AddScoped<IOrderRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IPerfumeReposetory<PerfumeDetails>, PerfumeRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DBC").ToString());
});

builder.Services.AddIdentity<Users, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Accounts/Login";
});

builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    x.Password.RequiredLength = 3;
});

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ✅ كود إنشاء الرول والمستخدم الأدمن
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();

    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // إنشاء مستخدم أدمن
    string adminEmail = "Admin$123@kazanola.com";
    string adminPassword = "Admin@123";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        var user = new Users
        {
         
            EmailConfirmed = true,
            Dis_Name = adminEmail,
            Email=adminEmail,
            UserName = adminEmail,
            
        };

        var result = await userManager.CreateAsync(user, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

app.Run();
