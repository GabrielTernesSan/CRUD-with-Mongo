namespace Estoque.Domain.ViewModels
{
    public class ProdutoViewModel
    {
        public string Id { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateTimeOffset Fabricacao { get; set; }
        public string Descricao { get; set; } = null!;
        public ICollection<string> Categorias { get; set; } = null!;

    }
}
