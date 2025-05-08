
namespace Kazanola.Models.Repositories
{
    public class OrderRepository : IOrderRepository<Order>
    {
        public AppDbContext db { get; set; }
        public OrderRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate= DateTime.Now;
            db.Orders.Update(data);
            db.SaveChanges();
        }
        public void Delivered(int Id)
        {
            var data = Find(Id);
            data.IsDelivered = !data.IsDelivered;
            data.EditDate= DateTime.Now;
            db.Orders.Update(data);
            db.SaveChanges();
        }
        public void Paid(int Id)
        {
            var data = Find(Id);
            data.IsPaid = !data.IsPaid;
            data.EditDate= DateTime.Now;
            db.Orders.Update(data);
            db.SaveChanges();
        }

        public void Add(Order entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.IsDelivered = false;
            entity.IsPaid = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate=DateTime.Now;
            db.Orders.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Order entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate = DateTime.Now;
            db.Orders.Update(data);
            db.SaveChanges();
        }

        public Order Find(int Id)
        {
            return db.Orders.SingleOrDefault(x=> x.OrderID==Id);
        }

        public void Update(int Id, Order entity)
        {
            var data = Find(Id);
            data.OrderTotalPrice = entity.OrderTotalPrice;
            data.CustomerName= entity.CustomerName;
            data.DeliveryCompany=entity.DeliveryCompany;
            data.OrderDate = entity.OrderDate;
            data.IsDelivered= entity.IsDelivered;
            data.PageID= entity.PageID;
            data.LocationCity=entity.LocationCity;
            data.Neighborhood=entity.Neighborhood;
            data.Street=entity.Street;
            data.EditDate = DateTime.Now;
            db.Orders.Update(data);
            db.SaveChanges();
        }

        public List<Order> View()
        {
            return db.Orders.Where(x=> x.IsDelete==false).ToList();
        }

        public List<Order> ViewClient()
        {
            return db.Orders.Where(_ => _.IsDelete==false&&_.IsActive==true).ToList();
        }
    }
}
