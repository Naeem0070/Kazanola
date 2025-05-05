
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Kazanola.Models.Repositories
{
    public class ScheduleBillRepository : IRepository<ScheduleBill>
    {
        public AppDbContext db { get; set; }
        public IUserRepository<Users> user { get; set; }
        public ScheduleBillRepository(AppDbContext _db,IUserRepository<Users> user)
        {
            db = _db;
            this.user = user;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.ScheduleBills.Update(data);
            db.SaveChanges();
        }

        public void Add(ScheduleBill entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.ScheduleBills.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, ScheduleBill entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete; 
            data.EditDate = DateTime.Now;
            db.ScheduleBills.Update(data);
            db.SaveChanges();
        }

        public ScheduleBill Find(int Id)
        {
            return db.ScheduleBills.SingleOrDefault(x=> x.ScheduleBillID==Id);
        }

        public void Update(int Id, ScheduleBill entity)
        {
            var data = Find(Id);
            data.BillCompany = entity.BillCompany;
            data.BillDate = entity.BillDate;
            data.BillCost = entity.BillCost;
            data.BillNumber = entity.BillNumber;
            data.EditDate = DateTime.Now;
            data.EditId = entity.EditId; 

            db.ScheduleBills.Update(data);
            db.SaveChanges();
        }

        public List<ScheduleBill> View()
        {
            return db.ScheduleBills.Where(x => x.IsDelete==false).ToList();
        }

        public List<ScheduleBill> ViewClient()
        {
            return db.ScheduleBills.Where(_ => _.IsDelete==false && _.IsActive==true).ToList();
        }
    }
}
