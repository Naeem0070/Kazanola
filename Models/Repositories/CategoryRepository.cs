
namespace Kazanola.Models.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public AppDbContext db { get; set; }
        public CategoryRepository(AppDbContext _db)
        {
            db=_db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive=!data.IsActive;
            data.EditDate = DateTime.Now;
            db.Categories.Update(data);
            db.SaveChanges();
        }

        public void Add(Category entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Category entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.CreateDate = DateTime.Now;
            data.EditDate = DateTime.Now;
            db.Categories.Update(entity);   
            db.SaveChanges();
        }

        public Category Find(int Id)
        {
            return db.Categories.SingleOrDefault(x => x.CategoryID == Id);
        }

        public void Update(int Id, Category entity)
        {
            var data = Find (Id);
            data.IsActive = entity.IsActive;
            data.CategoryID = entity.CategoryID;
            data.CategoryName = entity.CategoryName;
            data.EditDate = DateTime.Now;
            db.Categories.Update(data);
            db.SaveChanges();
        }

        public List<Category> View()
        {
            return db.Categories.Where(x => x.IsDelete==false).ToList();
        }

        public List<Category> ViewClient()
        {
            return db.Categories.Where(x=> x.IsActive==true && x.IsDelete==false).ToList();
        }
    }
}
