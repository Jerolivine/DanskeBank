using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
