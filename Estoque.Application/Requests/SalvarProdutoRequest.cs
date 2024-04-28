using MediatR;

namespace Estoque.Application.Requests
{
    public class SalvarProdutoRequest : IRequest<int>
    {
        public string Nome { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateTimeOffset Fabricacao { get; set; }
        public string Descricao { get; set; } = null!;
        public ICollection<string> Categorias { get; set; } = null!;
    }
}
