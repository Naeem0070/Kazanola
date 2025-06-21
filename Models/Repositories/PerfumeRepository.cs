
using Microsoft.EntityFrameworkCore;

namespace Kazanola.Models.Repositories
{
    public class PerfumeRepository : IPerfumeReposetory<PerfumeDetails>
    {
        public AppDbContext db { get; set; }
        public PerfumeRepository(AppDbContext db)
        {
            this.db=db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.Perfumes.Update(data);
            db.SaveChanges();
        }

        public void Add(PerfumeDetails entity)
        {
            entity.IsActive = true;
            entity.IsDelete= false;
            entity.OutOfStock = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.Perfumes.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int Id, PerfumeDetails entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.Perfumes.Update(data);
            db.SaveChanges();
        }

        public PerfumeDetails Find(int Id)
        {
            return db.Perfumes
               
                .Include(x => x.product)
                .SingleOrDefault(x => x.PerfumeDetailsId == Id);
        }

        public void OutOfStoke(int Id)
        {
            var data = Find(Id);
            data.OutOfStock = !data.OutOfStock;
            data.EditDate = DateTime.Now;
            db.Perfumes.Update(data);
            db.SaveChanges();
        }

        public void Update(int Id, PerfumeDetails entity)
        {
            var data = Find(Id);
            if (data == null) return;

            db.Entry(data).CurrentValues.SetValues(entity);
            data.EditDate = DateTime.Now;

            db.SaveChanges();
        }

        public List<PerfumeDetails> View()
        {
            return db.Perfumes
               
                .Include(x => x.product)
                .Where(x => x.IsDelete == false)
                .ToList();
        }

        public List<PerfumeDetails> ViewClient()
        {
           return db.Perfumes
         
                .Include(x => x.product)
                .Where(x => x.IsDelete == false && x.IsActive == true )
                .ToList();
        }
    }
}
