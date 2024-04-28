using Estoque.Domain.Queries;
using Estoque.Domain.Queries.Responses;

namespace Estoque.Infra.Queries
{
    public class ProdutoQuery : IProdutoQuery
    {
        public Task<IEnumerable<ProdutoResponse>> ObterProdutosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoResponse> ObterProdutosByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
