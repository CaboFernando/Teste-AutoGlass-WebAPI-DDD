using Aplicacao.Interfaces;
using Aplicacao.ViewModels;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AplicacaoProduto(IProduto produto, IServicoProduto servicoProduto, IMapper mapper)
        {
            _IProduto = produto;
            _IServicoProduto = servicoProduto;
            _mapper = mapper; 
        }

        #region métodos customizados

        public async Task AdicionaProduto(ProdutoViewModel produto)
        {
            await _IServicoProduto.AdicionaProduto(_mapper.Map<Produto>(produto));
        }

        public async Task AtualizaProduto(ProdutoViewModel produto)
        {
            await _IServicoProduto.AtualizaProduto(_mapper.Map<Produto>(produto));
        }

        public async Task<List<ProdutoViewModel>> ListarProdutoAtivos()
        {
            List<ProdutoViewModel> produtosViewModel = new List<ProdutoViewModel>();

            IEnumerable<Produto> produtos = await _IServicoProduto.ListarProdutoAtivos();

            produtosViewModel = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return produtosViewModel;
        }

        public async Task<ProdutoViewModel> BuscaPorCodigo(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _IServicoProduto.BuscaPorCodigo(id));
        }

        public async Task RemoveProduto(ProdutoViewModel produto)
        {
            await _IServicoProduto.RemoveProduto(_mapper.Map<Produto>(produto));
        }

        #endregion



        #region métodos genéricos

        public async Task Adicionar(ProdutoViewModel Object)
        {
            await _IProduto.Adicionar(_mapper.Map<Produto>(Object));
        }

        public async Task Atualizar(ProdutoViewModel Object)
        {
            await _IProduto.Atualizar(_mapper.Map<Produto>(Object));
        }

        public async Task<ProdutoViewModel> BuscarPorId(int Id)
        {
            return _mapper.Map<ProdutoViewModel>(await _IProduto.BuscarPorId(Id));
        }

        public async Task Excluir(ProdutoViewModel Object)
        {
            await _IProduto.Excluir(_mapper.Map<Produto>(Object));
        }

        public async Task<List<ProdutoViewModel>> Listar()
        {
            List<ProdutoViewModel> produtosViewModel = new List<ProdutoViewModel>();

            IEnumerable<Produto> produtos = await _IProduto.Listar();

            produtosViewModel = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return produtosViewModel;
        }

        #endregion

    }
}
