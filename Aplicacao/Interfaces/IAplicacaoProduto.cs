using Aplicacao.Interfaces.Genericos;
using Aplicacao.ViewModels;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoProduto : IGenericaAplicacao<ProdutoViewModel>
    {
        Task AdicionaProduto(ProdutoViewModel produto);
        Task AtualizaProduto(ProdutoViewModel produto);
        Task<List<ProdutoViewModel>> ListarProdutoAtivos();
        Task<ProdutoViewModel> BuscaPorCodigo(int id);
        Task RemoveProduto(ProdutoViewModel produto);
    }
}
