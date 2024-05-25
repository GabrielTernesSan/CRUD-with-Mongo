namespace Estoque.Domain.Queries
{
    public interface IMongoQuery<T>
    {
        List<T> Get();
        T Get(string id);
    }
}
