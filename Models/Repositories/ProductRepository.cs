
namespace Kazanola.Models.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public AppDbContext db { get; set; }
        public ProductRepository(AppDbContext _db)
        {
            db= _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data .IsActive=!data.IsActive;
            data.EditDate = DateTime.Now;
            db.Products.Update(data);
            db.SaveChanges();
        }

        public void Add(Product entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.Products.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Product entity)
        {
            var data = Find(Id);
            data .IsDelete= true;
            data.EditDate= DateTime.Now;
            db.Products.Update(entity);
            db.SaveChanges();
        }

        public Product Find(int Id)
        {
            return db.Products.SingleOrDefault(x=> x.ProductID==Id);
        }

        public void Update(int Id, Product entity)
        {
            var data = Find(Id);
            data.ProductName = entity.ProductName;
            data.ProductPrice = entity.ProductPrice;
            data.ProductCost = entity.ProductCost;
            data.Benefit = entity.Benefit;
            data.BrandId = entity.BrandId;
            data.ProductImageUrl = entity.ProductImageUrl;
            data.BillID = entity.BillID;
            db.Products.Update(data);
            db.SaveChanges();
        }

        public List<Product> View()
        {
            return db.Products.Where(x => x.IsDelete==false).ToList();
        }

        public List<Product> ViewClient()
        {
            return db.Products.Where(_ => _.IsDelete==false&&_.IsActive==true).ToList();
        }
    }
}
