
namespace Kazanola.Models.Repositories
{
    public class SaleBanerRepository : ISaleBanerReposetory<SaleBaner>
    {
        public AppDbContext db { get; set; }
        public SaleBanerRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data =Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.SaleBaners.Update(data);
            db.SaveChanges();
        }

        public void Add(SaleBaner entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.IsFeatured = true;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.SaleBaners.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, SaleBaner entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate = DateTime.Now;
            db.SaleBaners.Update(data);
            db.SaveChanges();
        }

        public void Featured(int Id)
        {
            var data = Find(Id);
            data.IsFeatured = !data.IsFeatured;
            data.EditDate = DateTime.Now;
            db.SaleBaners.Update(data);
            db.SaveChanges();
        }

        public SaleBaner Find(int Id)
        {
            return db.SaleBaners.SingleOrDefault(x => x.SaleBanerId == Id);
        }

        public void Update(int Id, SaleBaner entity)
        {
            var data = Find(Id);
            data.PromotionalText = entity.PromotionalText;
            data.Price=entity.Price;
            data.Description=entity.Description;
            data.FeaturedUntil = entity.FeaturedUntil;
            data.ImageUrl = entity.ImageUrl;
            data.Title = entity.Title;
            db.SaleBaners.Update(data);
            db.SaveChanges();
        }

        public List<SaleBaner> View()
        {
            return db.SaleBaners.Where(x => x.IsDelete == false).ToList();
        }

        public List<SaleBaner> ViewClient()
        {
            return db.SaleBaners.Where(_ => _.IsDelete == false && _.IsActive == true).ToList();
        }
    }
}
