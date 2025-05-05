using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kazanola.Models
{
    public partial class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BillPayment> BillPayments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual DbSet<EmployeeWithdrawal> EmployeeWithdrawals { get; set; }
        public virtual DbSet<CampaignPayment> Marketing { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ScheduleBill> ScheduleBills { get; set; }
        public DbSet<Users> User { get; set; } = default!;

      
    }
}
