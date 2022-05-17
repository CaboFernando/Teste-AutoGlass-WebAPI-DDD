using Dominio.Interfaces;
using Entidades.Entidades;
using Infra.Configuracoes;
using Infra.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioProduto : RepositorioGenerico<Produto>, IProduto
    {
        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioProduto()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }

        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var db = new Contexto(_OptionsBuilder))
            {
                return await db.Produto.Where(exProduto).AsNoTracking().ToListAsync();
            }

        }

        public async Task<Produto> BuscaPorCodigo(int id)
        {
            using (var db = new Contexto(_OptionsBuilder))
            {
                return await db.Produto.FirstOrDefaultAsync(x => x.CodigoProduto == id && x.SituacaoProduto);
            }
        }

        public async Task<bool> AdicionaProduto(Produto produto)
        {
            await Adicionar(produto);
            return true;

        }

        public async Task<bool> AtualizaProduto(Produto produto)
        {
            await Atualizar(produto);
            return true;

        }

        public async Task<bool> RemoveProduto(Produto produto)
        {
            produto.SituacaoProduto = false;
            await Atualizar(produto);
            return true;

        }
    }
}
