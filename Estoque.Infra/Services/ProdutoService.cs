using AutoMapper;
using Estoque.Domain.Estoque;
using Estoque.Domain.Queries;
using Estoque.Domain.Repositories;
using Estoque.Domain.ViewModels;

namespace Estoque.Infra.Services
{
    public class ProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMongoRepository<Produto> _mongoRepository;
        private readonly IMongoQuery<Produto> _mongoQuery;

        public ProdutoService(IMapper mapper, IMongoRepository<Produto> mongoRepository, IMongoQuery<Produto> mongoQuery)
        {
            _mapper = mapper;
            _mongoRepository = mongoRepository;
            _mongoQuery = mongoQuery;
        }

        public async Task<ProdutoViewModel> Create(ProdutoViewModel produto)
        {
            var entity = new Produto(produto.Nome, produto.Descricao, produto.Categorias, produto.Marca, produto.Fabricacao);

            await _mongoRepository.Create(entity);

            return _mapper.Map<ProdutoViewModel>(await _mongoQuery.GetByIdAsync(entity.Id));
        }

        public async Task Update(string id, ProdutoViewModel request)
        {
            await _mongoRepository.Update(id, _mapper.Map<Produto>(request));
        }

        public async Task Remove(string id) => await _mongoRepository.Remove(id);

    }
}
