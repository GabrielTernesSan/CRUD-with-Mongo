namespace Estoque.Domain.Estoque
{
    public class Produto
    {
        public int Id { get; }
        public string Nome { get; private set; } = null!;
        public string Marca { get; private set; } = null!;
        public DateTimeOffset Fabricacao { get; private set; }
        public string Descricao { get; private set; } = null!;
        public ICollection<string> Categorias { get; private set; } = null!;

        public Produto(string nome, string descricao, ICollection<string> categorias, string marca, DateTimeOffset fabricacao)
        {
            Nome = nome;
            Descricao = descricao;
            Categorias = categorias;
            Marca = marca;
            Fabricacao = fabricacao;
        }

        public Produto(int id, string nome, string descricao, ICollection<string> categorias, string marca, DateTimeOffset fabricacao) : this(nome, descricao, categorias, marca, fabricacao)
        {
            Id = id;
        }
    }
}
