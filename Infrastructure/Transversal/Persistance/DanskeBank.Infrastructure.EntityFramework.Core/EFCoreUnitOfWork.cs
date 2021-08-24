using DanskeBank.Infrastructure.EntityFramework.Core.Context;
using DanskeBank.Infrastructure.EntityFramework.Core.Repository;
using DanskeBank.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank.Infrastructure.EntityFramework.Core
{
    public class EFCoreUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EFCoreDbContext _context;

        public EFCoreUnitOfWork(EFCoreDbContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
