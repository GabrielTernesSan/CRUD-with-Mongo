using MediatR;
using System.Text.Json.Serialization;

namespace Estoque.Application.Requests
{
    public class SalvarProdutoRequest : IRequest<string>
    {
        [JsonIgnore]
        public string Id { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateTimeOffset Fabricacao { get; set; }
        public string Descricao { get; set; } = null!;
        public IEnumerable<string> Categorias { get; set; } = null!;
    }
}
