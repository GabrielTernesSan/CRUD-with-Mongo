using Estoque.Domain.Queries.Responses;

namespace Estoque.Domain.Queries
{
    public interface IProdutoQuery
    {
        Task<IEnumerable<ProdutoResponse>> ObterProdutosAsync();
        Task<ProdutoResponse> ObterProdutosByIdAsync(int id);
    }
}
