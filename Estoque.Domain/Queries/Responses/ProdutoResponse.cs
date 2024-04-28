namespace Estoque.Domain.Queries.Responses
{
    public class ProdutoResponse
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateTimeOffset Fabricacao { get; set; }
        public ICollection<string> Categorias { get; set; } = null!;
    }
}
