
namespace Kazanola.Models.Repositories
{
    public class EmployeeScheduleRepository : IRepository<EmployeeSchedule>
    {
        public AppDbContext db { get; set; }
        public EmployeeScheduleRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.EmployeeSchedules.Update(data);
            db.SaveChanges();
        }

        public void Add(EmployeeSchedule entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.EmployeeSchedules.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, EmployeeSchedule entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate = DateTime.Now;
            db.EmployeeSchedules.Update(data);
            db.SaveChanges();
        }

        public EmployeeSchedule Find(int Id)
        {
            return db.EmployeeSchedules.SingleOrDefault(x => x.EmployeeScheduleID == Id);
        }

        public void Update(int Id, EmployeeSchedule entity)
        {
            var data = Find(Id);
            data.EmployeeID = entity.EmployeeID;
            data.EndTime = entity.EndTime;
            data.StartTime = entity.StartTime;
            
            data.EditDate = DateTime.Now;
            data.Hours = entity.Hours;
            db.EmployeeSchedules.Update(data);
            db.SaveChanges();
        }

        public List<EmployeeSchedule> View()
        {
            return db.EmployeeSchedules.Where(x => x.IsDelete == false).ToList();
        }

        public List<EmployeeSchedule> ViewClient()
        {
            return db.EmployeeSchedules.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
