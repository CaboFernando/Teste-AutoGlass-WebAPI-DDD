using Aplicacao.Interfaces;
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

        //[HttpGet()]
        //public async Task<IActionResult> ListarProdutoAtivos()
        //{
        //    return Ok(await _IAplicacaoProduto.ListarProdutoAtivos());
        //}

        //[HttpPost()]
        //public async Task<IActionResult> AdicionaProduto([FromBody] Produto produto)
        //{
        //    try
        //    {
        //        await _IAplicacaoProduto.AdicionaProduto(produto);
        //        return Ok();
        //    }
        //    catch (System.Exception)
        //    {
        //        return BadRequest();
        //    }
            
        //}

        //[HttpPut()]
        //public async Task<IActionResult> AtualizaProduto([FromBody] Produto produto)
        //{
        //    try
        //    {
        //        await _IAplicacaoProduto.AtualizaProduto(produto);
        //        return Ok();
        //    }
        //    catch (System.Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPut()]
        //public async Task<IActionResult> RemoveProduto([FromBody] Produto produto)
        //{
        //    return Ok(await _IAplicacaoProduto.RemoveProduto(produto));
        //}
    }
}
