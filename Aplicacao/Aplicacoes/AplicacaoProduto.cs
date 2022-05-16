using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfacesServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoProduto : IAplicacaoProduto
    {
        IProduto _IProduto;
        IServicoProduto _IServicoProduto;

        public AplicacaoProduto(IProduto produto, IServicoProduto servicoProduto)
        {
            _IProduto = produto;
            _IServicoProduto = servicoProduto;
        }

        #region métodos customizados

        public async Task AdicionaProduto(Produto produto)
        {
            await _IServicoProduto.AdicionaProduto(produto);
        }

        public async Task AtualizaProduto(Produto produto)
        {
            await _IServicoProduto.AtualizaProduto(produto);
        }

        public async Task<List<Produto>> ListarProdutoAtivos()
        {
            return await _IServicoProduto.ListarProdutoAtivos();
        }

        public async Task<Produto> BuscaPorCodigo(int id)
        {
            return await _IServicoProduto.BuscaPorCodigo(id);
        }

        public async Task<bool> RemoveProduto(Produto produto)
        {
            return await _IServicoProduto.RemoveProduto(produto);
        }

        #endregion



        #region métodos genéricos

        public async Task Adicionar(Produto Object)
        {
            await _IProduto.Adicionar(Object);
        }

        public async Task Atualizar(Produto Object)
        {
            await _IProduto.Atualizar(Object);
        }

        public async Task<Produto> BuscarPorId(int Id)
        {
            return await _IProduto.BuscarPorId(Id);
        }

        public async Task Excluir(Produto Object)
        {
            await _IProduto.Excluir(Object);
        }

        public async Task<List<Produto>> Listar()
        {
            return await _IProduto.Listar();
        }

        #endregion

    }
}
