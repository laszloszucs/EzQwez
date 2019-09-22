using EzQwez.Application.Services;
using System;
using System.Threading.Tasks;

namespace EzQwez.Infrastructure.EntityFrameworkDataAccess
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext Context;

        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }

        public async Task<int> Save()
        {
            int affectedRows = await Context.SaveChangesAsync();
            return affectedRows;
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
