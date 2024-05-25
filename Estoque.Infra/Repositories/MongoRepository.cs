using Estoque.Domain;
using Estoque.Domain.Repositories;
using MongoDB.Driver;

namespace Estoque.Infra.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _model;

        public MongoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _model = database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public T Create(T produto)
        {
            _model.InsertOne(produto);
            return produto;
        }

        public void Remove(string id) => _model.DeleteOne(x => x.Id == id);

        public void Update(string id, T produto) => _model.ReplaceOne(x => x.Id == id, produto);
    }
}
