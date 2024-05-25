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
        public List<T> Get() => _model.Find(active => true).ToList();

        public T Get(string id) => _model.Find(x => x.Id == id).FirstOrDefault();
    }
}
