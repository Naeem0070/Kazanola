
using Microsoft.EntityFrameworkCore;

namespace Kazanola.Models.Repositories
{
    public class BillPaymentRepository : IRepository<BillPayment>
    {
        public AppDbContext db{ get; set; }
        public BillPaymentRepository(AppDbContext _db)
        {
            db=_db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive=!data.IsActive;
            data.EditDate= DateTime.Now;
            db.BillPayments.Update(data);
            db.SaveChanges();
        }

        public void Add(BillPayment entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.BillPayments.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, BillPayment entity)
        {
            var data = Find(Id);
            data.IsDelete =!data.IsDelete;
            data.EditDate = DateTime.Now;
            db.BillPayments.Update(data);
            db.SaveChanges();
        }

        public BillPayment Find(int Id)
        {
            return db.BillPayments.SingleOrDefault(X => X.BillPaymentID == Id);
        }

        public void Update(int Id, BillPayment entity)
        {
            var data = Find(Id);
            data.BillPaymentDate = entity.BillPaymentDate;
            data.PaymentAmount = entity.PaymentAmount;
            data.PaymentMethod = entity.PaymentMethod;
            data.BillID = entity.BillID;
            data.EditDate= DateTime.Now;
            db.BillPayments.Update(data);
            db.SaveChanges();
        }

        public List<BillPayment> View()
        {
            return db.BillPayments.Where(x => x.IsDelete==false).Include(x=> x.Bill).ToList();
        }

        public List<BillPayment> ViewClient()
        {
            return db.BillPayments.Where(x=> x.IsDelete==false && x.IsActive==true).Include(x => x.Bill).ToList();
        }
    }
}
