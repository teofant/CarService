using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface IRepairStatusService
    {
        Task<IEnumerable<RepairStatus>> GetAllAsync();
        Task<RepairStatus> GetAsync(int id);
        Task<int> CreateAsync(RepairStatus repairStatus);
        Task<int> UpdateAsync(RepairStatus repairStatus);
        Task<int> DeleteAsync(RepairStatus repairStatus);
    }
}
