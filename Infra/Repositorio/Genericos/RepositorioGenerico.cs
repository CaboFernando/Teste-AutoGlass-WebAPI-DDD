using Dominio.Interfaces.Genericos;
using Infra.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : IGenericos<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioGenerico()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }

        public async Task Adicionar(T Object)
        {
            using (var data = new Contexto(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T Object)
        {
            using (var data = new Contexto(_OptionsBuilder))
            {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscarPorId(int Id)
        {
            using (var data = new Contexto(_OptionsBuilder))
            {   
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task Excluir(T Object)
        {
            using (var data = new Contexto(_OptionsBuilder))
            {
                data.Set<T>().Remove(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> Listar()
        {
            using (var data = new Contexto(_OptionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        #region implementação do Dispose de acordo com a doc da MS

        // To detect redundant calls
        bool _disposedValue = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            _disposedValue = true;
        }

        #endregion

    }
}
