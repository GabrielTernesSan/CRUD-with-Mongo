using Estoque.Application.Requests;
using Estoque.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoQuery _produtoQuery;
        private readonly IMediator _mediator;

        public ProdutoController(IProdutoQuery produtoQuery, IMediator mediator)
        {
            _produtoQuery = produtoQuery;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutosAsync()
        {
            var response = await _produtoQuery.ObterProdutosAsync();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProdutosByIdAsync(int id)
        {
            var response = await _produtoQuery.ObterProdutosByIdAsync(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarProdutoAsync([FromBody] SalvarProdutoRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
