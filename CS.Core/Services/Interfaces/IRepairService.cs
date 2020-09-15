using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface IRepairService
    {
        Task<IEnumerable<Repair>> GetAllAsync();
        Task<Repair> GetAsync(int id);
        Task<int> CreateAsync(Repair repair);
        Task<int> UpdateAsync(Repair repair);
        Task<int> DeleteAsync(Repair repair);
    }
}
