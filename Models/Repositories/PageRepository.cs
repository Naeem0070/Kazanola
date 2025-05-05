
namespace Kazanola.Models.Repositories
{
    public class PageRepository : IRepository<Page>
    {
        public AppDbContext db { get; set; }
        public PageRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive= !data.IsActive;
            data.EditDate = DateTime.Now;
            db.Pages.Update(data);
            db.SaveChanges();

        }

        public void Add(Page entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.Pages.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Page entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate= DateTime.Now;
            db.Pages.Update(entity);
            db.SaveChanges();
        }

        public Page Find(int Id)
        {
            return db.Pages.SingleOrDefault(x=>x.PageID==Id);
        }

        public void Update(int Id, Page entity)
        {
            var data= Find(Id);
            data.PageName = entity.PageName;
            db.Pages.Update(data);
            db.SaveChanges();
        }

        public List<Page> View()
        {
            return db.Pages.Where(x => x.IsDelete==false).ToList();
        }

        public List<Page> ViewClient()
        {
            return db.Pages.Where(X=>X.IsActive==true&&X.IsDelete==false).ToList();
        }
    }
}
