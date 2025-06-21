using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kazanola.Models.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Update(int id, T entity)
        {
            var data = Find(id);
            if (data == null) return;
            Boolean isActive = data.IsActive;
            _db.Entry(data).CurrentValues.SetValues(entity);
            data.EditDate = DateTime.Now;
            data.IsActive = isActive;
            _db.SaveChanges();
        }

        public void Delete(int id, T entity)
        {
            var data = Find(id);
            data.IsDelete = !data.IsDelete;
            data.EditDate = DateTime.Now;
            _dbSet.Update(data);
            _db.SaveChanges();
        }

        public void Active(int id)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            _dbSet.Update(data);
            _db.SaveChanges();
        }
        
        public List<T> View()
        {
            return _dbSet.Where(x => x.IsDelete==false).ToList();
        }

        public List<T> ViewClient()
        {
            return _dbSet.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
