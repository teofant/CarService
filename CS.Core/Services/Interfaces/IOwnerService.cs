using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner> GetAsync(int id);
        Task<int> CreateAsync(Owner owner);
        Task<int> UpdateAsync(Owner owner);
        Task<int> DeleteAsync(Owner owner);
    }
}
