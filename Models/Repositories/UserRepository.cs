
namespace Kazanola.Models.Repositories
{
    public class UserRepository : IUserRepository<Users>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

       
        public Users Find(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        void IUserRepository<Users>.Active(string id)
        {
            throw new NotImplementedException();
        }

        void IUserRepository<Users>.Add(Users entity)
        {
            throw new NotImplementedException();
        }

        void IUserRepository<Users>.Delete(string id)
        {
            var data = Find(id);
            data.IsDelete = true;
            _context.Users.Remove(data);
            _context.SaveChanges();
        }

        Users IUserRepository<Users>.Find(string id)
        {
            return _context.User.FirstOrDefault(x=> x.Id==id);
        }

        void IUserRepository<Users>.Update(string id, Users entity)
        {
            throw new NotImplementedException();
        }

        List<Users> IUserRepository<Users>.View()
        {
            return _context.User.Where(x=> x.IsDelete==false).ToList();
        }
    }
}
