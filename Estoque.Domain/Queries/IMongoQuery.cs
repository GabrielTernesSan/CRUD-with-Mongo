namespace Estoque.Domain.Queries
{
    public interface IMongoQuery<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(string id);
    }
}
