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

        public async Task<T> Create(T produto)
        {
            await _model.InsertOneAsync(produto);
            return produto;
        }

        public async Task Remove(string id) => await _model.DeleteOneAsync(x => x.Id == id);

        public async Task Update(string id, T produto) => await _model.ReplaceOneAsync(x => x.Id == id, produto);
    }
}
