using Estoque.Domain;
using Estoque.Domain.Queries;
using MongoDB.Driver;

namespace Estoque.Infra.Queries
{
    public class MongoQuery<T> : IMongoQuery<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _model;

        public MongoQuery(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _model = database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task<List<T>> GetAsync() => await _model.Find(active => true).ToListAsync();

        public async Task<T> GetByIdAsync(string id) => await _model.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
