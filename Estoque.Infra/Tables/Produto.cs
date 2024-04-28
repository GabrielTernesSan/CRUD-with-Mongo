using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Infra.Tables
{
    [Table("Produtos")]
    public class Produto
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public int Id { get; }
        [BsonElement("Nome")]
        public string Nome { get; private set; } = null!;
        [BsonElement("Marca")]
        public string Marca { get; private set; } = null!;
        [BsonElement("Fabricacao")]
        public DateTimeOffset Fabricacao { get; private set; }
        [BsonElement("Descricao")]
        public string Descricao { get; private set; } = null!;
        [BsonElement("Categorias")]
        public IEnumerable<string> Categorias { get; private set; } = null!;
    }
}
