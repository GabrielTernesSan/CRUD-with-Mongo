using MongoDB.Bson.Serialization.Attributes;

namespace Estoque.Domain.Estoque
{
    public class Produto : BaseEntity
    {
        [BsonElement("nome")]
        public string Nome { get; private set; } = null!;
        [BsonElement("marca")]
        public string Marca { get; private set; } = null!;
        [BsonElement("fabricacao")]
        public DateTimeOffset Fabricacao { get; private set; }
        [BsonElement("descricao")]
        public string Descricao { get; private set; } = null!;
        [BsonElement("categorias")]
        public ICollection<string> Categorias { get; private set; } = null!;

        public Produto(string nome, string descricao, ICollection<string> categorias, string marca, DateTimeOffset fabricacao)
        {
            Nome = nome;
            Descricao = descricao;
            Categorias = categorias;
            Marca = marca;
            Fabricacao = fabricacao;
        }

        public Produto(string id, string nome, string descricao, ICollection<string> categorias, string marca, DateTimeOffset fabricacao) : this(nome, descricao, categorias, marca, fabricacao)
        {
            Id = id;
        }
    }
}
