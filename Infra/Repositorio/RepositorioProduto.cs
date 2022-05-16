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
            try
            {
                using (var db = new Contexto(_OptionsBuilder))
                {
                    return await db.Produto.Where(exProduto).AsNoTracking().ToListAsync();
                }
            }
            catch (Exception)
            {
                return new List<Produto>();
            }
        }

        public async Task<Produto> BuscaPorCodigo(int id)
        {
            try
            {
                return await BuscarPorId(id);
            }
            catch (Exception)
            {
                return new Produto();
            }
        }

        public async Task<bool> AdicionaProduto(Produto produto)
        {
            try
            {
                await Adicionar(produto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AtualizaProduto(Produto produto)
        {
            try
            {
                await AtualizaProduto(produto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveProduto(Produto produto)
        {
            try
            {
                produto.SituacaoProduto = false;
                await Atualizar(produto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
