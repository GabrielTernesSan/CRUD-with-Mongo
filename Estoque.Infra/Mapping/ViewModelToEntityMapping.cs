using AutoMapper;
using Estoque.Domain.Estoque;
using Estoque.Domain.ViewModels;

namespace Estoque.Infra.Mapping
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {
            CreateMap<ProdutoViewModel, Produto>().ConstructUsing(x => new Produto(x.Id, x.Nome, x.Descricao, x.Categorias, x.Marca, x.Fabricacao));
        }
    }
}
