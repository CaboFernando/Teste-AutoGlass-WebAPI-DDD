using Aplicacao.Interfaces;
using Aplicacao.ViewModels;
using Entidades.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IAplicacaoProduto _IAplicacaoProduto;

        public ProdutoController(IAplicacaoProduto IAplicacaoProduto)
        {
            _IAplicacaoProduto = IAplicacaoProduto;
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> BuscaPorCodigo([FromRoute] int codigo)
        {
            return Ok(await _IAplicacaoProduto.BuscaPorCodigo(codigo));
        }

        [HttpGet()]
        public async Task<IActionResult> ListarProdutoAtivos()
        {
            return Ok(await _IAplicacaoProduto.ListarProdutoAtivos());
        }

        [HttpPost()]
        public async Task<IActionResult> AdicionaProduto([FromBody] ProdutoViewModel produto)
        {
            try
            {
                await _IAplicacaoProduto.AdicionaProduto(produto);
                return Ok("Produto adicionado com sucesso");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao adicionar o produto");
            }

        }

        [HttpPut()]
        public async Task<IActionResult> AtualizaProduto([FromBody] ProdutoViewModel produto)
        {
            try
            {
                await _IAplicacaoProduto.AtualizaProduto(produto);
                return Ok("Produto atualizado com sucesso");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao atualizar o produto");
            }
        }

        [HttpPut("/api/RemoveProduto")]
        public async Task<IActionResult> RemoveProduto([FromBody] ProdutoViewModel produto)
        {
            try
            {
                await _IAplicacaoProduto.RemoveProduto(produto);
                return Ok("Produto removido com sucesso");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao remover o produto");
            }
        }
    }
}
