
namespace Kazanola.Models.Repositories
{
    public class EmployeeWithdrawalRepository : IRepository<EmployeeWithdrawal>
    {
        public AppDbContext db { get; set; }
        public EmployeeWithdrawalRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.EmployeeWithdrawals.Update(data);
            db.SaveChanges();
        }

        public void Add(EmployeeWithdrawal entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.EmployeeWithdrawals.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, EmployeeWithdrawal entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate = DateTime.Now;
            db.EmployeeWithdrawals.Update(data);
            db.SaveChanges() ;
        }

        public EmployeeWithdrawal Find(int Id)
        {
            return db.EmployeeWithdrawals.SingleOrDefault(x => x.EmployeeWithdrawalID == Id);
        }

        public void Update(int Id, EmployeeWithdrawal entity)
        {
            var data = Find(Id);
            data.WithdrawalAmount = entity.WithdrawalAmount;
            data.WithdrawalDate = entity.WithdrawalDate;
            data.EmployeeID = entity.EmployeeID;
            data.EditDate = DateTime.Now;
            data.Details = entity.Details;
            db.EmployeeWithdrawals.Update(data);
            db.SaveChanges() ;
        }

        public List<EmployeeWithdrawal> View()
        {
            return db.EmployeeWithdrawals.Where(x => x.IsDelete == false).ToList();
        }

        public List<EmployeeWithdrawal> ViewClient()
        {
            return db.EmployeeWithdrawals.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
