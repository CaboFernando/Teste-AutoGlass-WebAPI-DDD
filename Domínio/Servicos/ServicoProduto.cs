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
                await _produto.Adicionar(produto);
            }
        }

        public async Task AtualizaProduto(Produto produto)
        {
            var validarCodigo = produto.ValidarPropriedadeDecimal(produto.CodigoProduto, "CodigoProduto");
            var validarDescricao = produto.ValidarPropriedadesString(produto.DescricaoProduto, "DescricaoProduto");
            var validarDatas = produto.ValidarDataMaiorQueOutra(produto.DataFrabricacao, produto.DataValidade, "DataFrabricacao", "DataValidade");
            if (validarCodigo && validarDescricao && validarDatas)
            {
                await _produto.Atualizar(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutoAtivos()
        {
            return await _produto.ListarProdutos(x => x.SituacaoProduto);
        }
    }
}
