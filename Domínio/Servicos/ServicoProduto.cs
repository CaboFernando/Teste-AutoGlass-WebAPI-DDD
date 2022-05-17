using Dominio.Interfaces;
using Dominio.Interfaces.InterfacesServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
        private readonly IProduto _produto;

        public ServicoProduto(IProduto produto)
        {
            _produto = produto;
        }

        public async Task AdicionaProduto(Produto produto)
        {
            var validarDescricao = produto.ValidarPropriedadesString(produto.DescricaoProduto, "DescricaoProduto");
            var validarDatas = produto.ValidarDataMaiorQueOutra(produto.DataFrabricacao, produto.DataValidade, "DataFrabricacao", "DataValidade");
            if (validarDescricao && validarDatas)
            {
                produto.SituacaoProduto = true;

                await _produto.AdicionaProduto(produto);
            }
        }

        public async Task AtualizaProduto(Produto produto)
        {
            var validarCodigo = produto.ValidarPropriedadeDecimal(produto.CodigoProduto, "CodigoProduto");
            var validarDescricao = produto.ValidarPropriedadesString(produto.DescricaoProduto, "DescricaoProduto");
            var validarDatas = produto.ValidarDataMaiorQueOutra(produto.DataFrabricacao, produto.DataValidade, "DataFrabricacao", "DataValidade");
            if (validarCodigo && validarDescricao && validarDatas)
            {
                produto.SituacaoProduto = true;

                await _produto.AtualizaProduto(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutoAtivos()
        {
            var listaProdutos = await _produto.ListarProdutos(x => x.SituacaoProduto);

            if (listaProdutos.Count > 0)
                return listaProdutos;

            return new List<Produto>();
        }

        public async Task<Produto> BuscaPorCodigo(int id)
        {
            Produto produto = new Produto();
            var validarCodigo = produto.ValidarPropriedadeDecimal(id, "CodigoProduto");
            if(validarCodigo)
                return await _produto.BuscaPorCodigo(id);

            return produto;
        }

        public async Task<bool> RemoveProduto(Produto produto)
        {
            var existeProduto = await _produto.BuscaPorCodigo(produto.CodigoProduto);

            if (existeProduto.CodigoProduto > 0)
                return await _produto.RemoveProduto(produto);

            return false;
        }
    }
}
