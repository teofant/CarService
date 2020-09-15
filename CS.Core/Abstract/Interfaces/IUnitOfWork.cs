using CS.Core.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Abstract.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        MainContext Context { get; }
        Task<int> SaveChangesAsync();
    }
}
