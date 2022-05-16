using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfacesServicos
{
    public interface IServicoProduto
    {
        Task AdicionaProduto(Produto produto);
        Task AtualizaProduto(Produto produto);
        Task<List<Produto>> ListarProdutoAtivos();
    }
}
