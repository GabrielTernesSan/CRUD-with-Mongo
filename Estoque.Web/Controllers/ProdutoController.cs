using Estoque.Application.Requests;
using Estoque.Domain.Estoque;
using Estoque.Domain.Queries;
using Estoque.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMongoQuery<Produto> _mongoQuery;
        private readonly IMediator _mediator;

        public ProdutoController(IMongoQuery<Produto> mongoQuery, IMediator mediator)
        {
            _mongoQuery = mongoQuery;
            _mediator = mediator;
        }

        [HttpGet]
        public  IActionResult GetProdutosAsync()
        {
            var response = _mongoQuery.Get();

            return Ok(response);
        }

        [HttpGet("{id:length(24)}", Name = "GetProducts")]
        public ActionResult<ProdutoViewModel> GetProdutosByIdAsync(string id)
        {
            var response = _mongoQuery.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarProdutoAsync([FromBody] SalvarProdutoRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<ProdutoViewModel>> Update(string id, SalvarProdutoRequest request)
        {
            var produto = _mongoQuery.Get(id);

            if (produto is null)
                return NotFound();

            request.Id = id;

            await _mediator.Send(request);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var produto = _mongoQuery.Get(id);

            if (produto is null)
                return NotFound("Produto não encontrado!");

            var request = new ExcluirProdutoRequest() { Id = id };

            await _mediator.Send(request);

            return Ok("Noticia deletada com sucesso!");
        }
    }
}
