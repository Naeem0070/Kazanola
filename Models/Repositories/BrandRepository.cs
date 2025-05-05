
namespace Kazanola.Models.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        public AppDbContext db { get; set; }
        public BrandRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive=!data.IsActive;
            data.EditDate=DateTime.Now;
            db.Brands.Update(data);
            db.SaveChanges();
        }

        public void Add(Brand entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            db.Brands.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Brand entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate= DateTime.Now;
            db.Brands.Update(data);
            db.SaveChanges();
        }

        public Brand Find(int Id)
        {
            return db.Brands.SingleOrDefault(x=> x.BrandId==Id);
        }

        public void Update(int Id, Brand entity)
        {
            var data = Find(Id);
            data.BrandName= entity.BrandName;
            data.CategoryId = entity.CategoryId;
            db.Brands.Update(data);
            db.SaveChanges();
        }

        public List<Brand> View()
        {
            return db.Brands.Where(x => x.IsDelete == false).ToList();
        }

        public List<Brand> ViewClient()
        {
            return db.Brands.Where(x=> x.IsActive == true && x.IsDelete==false).ToList();
        }
    }
}
