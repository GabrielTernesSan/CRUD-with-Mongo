using Estoque.Domain.Estoque;
using Estoque.Domain.Repositories;

namespace Estoque.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Task<Produto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvarAsync(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
