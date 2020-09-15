using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface IMasterService
    {
        Task<IEnumerable<Master>> GetAllAsync();
        Task<Master> GetAsync(int id);
        Task<int> CreateAsync(Master master);
        Task<int> UpdateAsync(Master master);
        Task<int> DeleteAsync(Master master);
    }
}
