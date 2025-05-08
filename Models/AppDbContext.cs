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
        public DbSet<NotePositoin> NotePositoins { get; set; }
        public DbSet<PerfumeNoteRelatoin> PerfumeNoteRelatoins { get; set; }
        public DbSet<PerfumeDetails> Perfumes { get; set; }
        public DbSet<AdsPanelsModel> AdsPanels { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<ContactUsForm> contactUs { get; set; }
        public DbSet<FadeBack> FadeBacks { get; set; }
        public DbSet<FAQModel> FAQModels { get; set; }
        public DbSet<MenuModel> MenuModels { get; set; }
        public DbSet<MenuOfMenuModel> MenuOfMenus { get; set; }
        public DbSet<NewsLetterTarncaction> NewsLetters { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<SaleBaner> SaleBaners { get; set; }
        public DbSet<SliderModel> Sliders { get; set; }
        public DbSet<SocialMediaModel> SocialMedias{ get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Terms_ConditionsModel> terms_Conditions { get; set; }
        public DbSet<WhoWeAreModel> WhoWeAres { get; set; }
        public DbSet<WhyChooseUsModel> WhyChooseUs { get; set; }


        


    }
}
