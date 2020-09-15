using CS.Core.Abstract.Interfaces;
using CS.Core.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Abstract
{
    public class UnitOfWork : IUnitOfWork
    {
        public MainContext Context { get; }

        public UnitOfWork(MainContext context) => Context = context;

        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync().ConfigureAwait(false);

        public void Dispose() => Context.Dispose();
    }
}
