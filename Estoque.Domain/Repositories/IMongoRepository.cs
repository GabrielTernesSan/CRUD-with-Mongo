namespace Estoque.Domain.Repositories
{
    public interface IMongoRepository<T>
    {
        Task<T> Create(T news);
        Task Update(string id, T news);
        Task Remove(string id);
    }
}
