
namespace Kazanola.Models.Repositories
{
    public class CampaignPaymentRepository : IRepository<CampaignPayment>
    {
        public AppDbContext db { get; set; }
        public CampaignPaymentRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
           var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.Marketing.Update(data);
            db.SaveChanges();
        }

        public void Add(CampaignPayment entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            db.Marketing.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, CampaignPayment entity)
        {
            var data = Find(Id);
            data.IsDelete = !data.IsDelete;
            data.EditDate = DateTime.Now;
            db.Marketing.Update(data);
            db.SaveChanges();
        }

        public CampaignPayment Find(int Id)
        {
            return db.Marketing.SingleOrDefault(x => x.CampaignPaymentID == Id);
        }

        public void Update(int Id, CampaignPayment entity)
        {
            var data = Find(Id);
            data.CampaignName = entity.CampaignName;
            data.PageID = entity.PageID;
            data.Payment = entity.Payment;
            db.Marketing.Update(data);
            db.SaveChanges();
        }

        public List<CampaignPayment> View()
        {
            return db.Marketing.Where(x => x.IsDelete == false).ToList();
        }

        public List<CampaignPayment> ViewClient()
        {
            return db.Marketing.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
