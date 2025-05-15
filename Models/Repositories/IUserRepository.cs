namespace Kazanola.Models.Repositories
{
    public interface IUserRepository<T>
    {
        void Add(T entity);
        void Update(string id, T entity);
        void Delete(string id);
        void Active(string id);
        List<T> View();
        T Find(string id);
    }
}
