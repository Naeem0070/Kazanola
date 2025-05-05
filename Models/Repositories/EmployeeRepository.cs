
namespace Kazanola.Models.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public AppDbContext db{ get; set; }
        public EmployeeRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive=!data.IsActive;
            data.EditDate = DateTime.Now;
            db.Employees.Update(data);
            db.SaveChanges();
        }

        public void Add(Employee entity)
        {
            entity.IsActive = true;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.Employees.Add(entity);
            db.SaveChanges() ;
        }

        public void Delete(int Id, Employee entity)
        {
            var data = Find(Id);
            data.IsDelete=!data.IsDelete;
            data.EditDate= DateTime.Now;
            db.Employees.Update(data) ;
            db.SaveChanges() ;
        }

        public Employee Find(int Id)
        {
            return db.Employees.SingleOrDefault(x => x.EmployeeID == Id);
        }

        public void Update(int Id, Employee entity)
        {
            var data = Find(Id);
            data.IsActive=entity.IsActive;
            data.EmployeeName = entity.EmployeeName;
            data.HourlyRate = entity.HourlyRate;
            data.Salary = entity.Salary;
            data.EditDate= DateTime.Now;
            db.Employees.Update(data);
            db.SaveChanges();
        }

        public List<Employee> View()
        {
            return db.Employees.Where(x => x.IsDelete == false).ToList();
        }

        public List<Employee> ViewClient()
        {
            return db.Employees.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
