using Aplicacao.Interfaces.Genericos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoProduto : IGenericaAplicacao<Produto>
    {
        Task AdicionaProduto(Produto produto);
        Task AtualizaProduto(Produto produto);
        Task<List<Produto>> ListarProdutoAtivos();
        Task<Produto> BuscaPorCodigo(int id);
        Task RemoveProduto(Produto produto);
    }
}
