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
            if (produto.CodigoProduto > 0)
                throw new Exception("Não é necessário enviar o CodigoProduto para adicionar um novo produto");

            if (string.IsNullOrWhiteSpace(produto.DescricaoProduto))
                throw new Exception("A DescricaoProduto é obrigatória");

            if (produto.DataFrabricacao >= produto.DataValidade)
                throw new Exception("A DataFrabricacao não pode ser menor ou igual a DataValidade");

            produto.SituacaoProduto = true;
            await _produto.AdicionaProduto(produto);
        }

        public async Task AtualizaProduto(Produto produto)
        {
            if (produto.CodigoProduto <= 0)
                throw new Exception("O CodigoProduto é obrigatório para atualizar um produto");

            if (string.IsNullOrWhiteSpace(produto.DescricaoProduto))
                throw new Exception("A DescricaoProduto é obrigatória");

            if (produto.DataFrabricacao >= produto.DataValidade)
                throw new Exception("A DataFrabricacao não pode ser menor ou igual a DataValidade");

            produto.SituacaoProduto = true;
            await _produto.AtualizaProduto(produto);
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
            if (id <= 0)
                throw new Exception("O CodigoProduto informado é inválido");

            return await _produto.BuscaPorCodigo(id);
        }

        public async Task<bool> RemoveProduto(Produto produto)
        {
            var existeProduto = await _produto.BuscaPorCodigo(produto.CodigoProduto);

            if (existeProduto == null)
                throw new Exception("Não existe nenhum produto ativo com o CodigoProduto informado");

            return false;
        }
    }
}
