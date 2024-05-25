namespace Estoque.Domain.Repositories
{
    public interface IMongoRepository<T>
    {
        T Create(T news);
        void Update(string id, T news);
        void Remove(string id);
    }
}
