
namespace Kazanola.Models.Repositories
{
    public class OrderDetailsRepository : IRepository<OrderDetail>
    {
        public AppDbContext db { get; set; }
        public OrderDetailsRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive=!data.IsActive;
            data.EditDate = DateTime.Now;
            db.OrderDetails.Update(data);
            db.SaveChanges();
        }

        public void Add(OrderDetail entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            db.OrderDetails.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, OrderDetail entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate = DateTime.Now;
            db.OrderDetails.Update(data);
            db.SaveChanges();
        }

        public OrderDetail Find(int Id)
        {
            return db.OrderDetails.SingleOrDefault(x=> x.OrderDetailID==Id);
        }

        public void Update(int Id, OrderDetail entity)
        {
            var data = Find(Id);
            data.Quantity = entity.Quantity;
            data.ProductSalePrice = entity.ProductSalePrice;
            data.TotalPrice = entity.TotalPrice;
            data.OrderID= entity.OrderID;
            data.ProductID= entity.ProductID;
            db.OrderDetails.Update(data);
            db.SaveChanges();
        }

        public List<OrderDetail> View()
        {
            return db.OrderDetails.Where(x => x.IsDelete == false).ToList();
        }

        public List<OrderDetail> ViewClient()
        {
            return db.OrderDetails.Where(x=> x.IsDelete==false&&x.IsActive==true).ToList();
        }
    }
}
