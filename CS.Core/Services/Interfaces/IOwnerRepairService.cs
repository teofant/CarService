using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface IOwnerRepairService
    {
        Task<IEnumerable<OwnerRepair>> GetAllAsync();
        Task<OwnerRepair> GetAsync(int id);
        Task<int> CreateAsync(OwnerRepair ownerRepair);
        Task<int> UpdateAsync(OwnerRepair ownerRepair);
        Task<int> DeleteAsync(OwnerRepair ownerRepair);
    }
}
