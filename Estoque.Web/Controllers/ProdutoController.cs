using Estoque.Domain.Estoque;
using Estoque.Domain.Queries;
using Estoque.Domain.ViewModels;
using Estoque.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMongoQuery<Produto> _mongoQuery;
        private readonly ProdutoService _produtoService;

        public ProdutoController(IMongoQuery<Produto> mongoQuery, ProdutoService produtoService)
        {
            _mongoQuery = mongoQuery;
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutosAsync()
        {
            var response = await _mongoQuery.GetAsync();

            return Ok(response);
        }

        [HttpGet("{id:length(24)}", Name = "GetProducts")]
        public async Task<ActionResult<ProdutoViewModel>> GetProdutosByIdAsync(string id)
        {
            var response = await _mongoQuery.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarProdutoAsync([FromBody] ProdutoViewModel request)
        {
            var response = await _produtoService.Create(request);

            return Ok(response);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<ProdutoViewModel>> Update(string id, ProdutoViewModel request)
        {
            var produto = await _mongoQuery.GetByIdAsync(id);

            if (produto is null)
                return NotFound();

            request.Id = id;

            await _produtoService.Update(id, request);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var produto = await _mongoQuery.GetByIdAsync(id);

            if (produto is null)
                return NotFound("Produto não encontrado!");

            await _produtoService.Remove(id);

            return Ok("Produto deletado com sucesso!");
        }
    }
}
