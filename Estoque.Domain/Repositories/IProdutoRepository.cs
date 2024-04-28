using Estoque.Domain.Estoque;

namespace Estoque.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<int> SalvarAsync(Produto produto);
        Task<Produto> GetByIdAsync(int id);
    }
}
