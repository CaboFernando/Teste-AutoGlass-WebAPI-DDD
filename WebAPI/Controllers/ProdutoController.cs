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
        public async Task<Produto> BuscaPorCodigo([FromRoute] int codigo)
        {
            return await _IAplicacaoProduto.BuscaPorCodigo(codigo);
        }

        [HttpGet()]
        public async Task<List<Produto>> ListarProdutoAtivos()
        {
            return await _IAplicacaoProduto.ListarProdutoAtivos();
        }

        [HttpPost()]
        public async Task<bool> AdicionaProduto([FromBody] Produto produto)
        {
            try
            {
                await _IAplicacaoProduto.AdicionaProduto(produto);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }

        [HttpPut()]
        public async Task<bool> AtualizaProduto([FromBody] Produto produto)
        {
            try
            {
                await _IAplicacaoProduto.AtualizaProduto(produto);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        [HttpPut()]
        public async Task<bool> RemoveProduto([FromBody] Produto produto)
        {
            return await _IAplicacaoProduto.RemoveProduto(produto);
        }
    }
}
