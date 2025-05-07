using Kazanola.Areas.Admin.MyClass;
using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.MyClass;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClassHelper, HelperClass>();
builder.Services.AddScoped<IUserRepository<Users>, UserRepository>();
builder.Services.AddScoped<IRepository<BillPayment>,BillPaymentRepository>();
builder.Services.AddScoped<IRepository<ScheduleBill> ,ScheduleBillRepository>();
builder.Services.AddScoped<IRepository<Page>,PageRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Brand>, BrandRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IOrderRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<OrderDetail>, OrderDetailsRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<EmployeeSchedule>, EmployeeScheduleRepository>();
builder.Services.AddScoped<IRepository<EmployeeWithdrawal>, EmployeeWithdrawalRepository>();
builder.Services.AddScoped<IRepository<CampaignPayment>, CampaignPaymentRepository>();
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
    //options here

    options.LoginPath = "/Admin/Accounts/Login";

    //...
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
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
