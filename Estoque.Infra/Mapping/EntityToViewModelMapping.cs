using AutoMapper;
using Estoque.Domain.Estoque;
using Estoque.Domain.ViewModels;

namespace Estoque.Infra.Mapping
{
    public class EntityToViewModelMapping : Profile
    {
        public EntityToViewModelMapping()
        {
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
