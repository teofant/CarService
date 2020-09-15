using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface IHistoryStatusService
    {
        Task<IEnumerable<HistoryStatus>> GetAllAsync();
        Task<HistoryStatus> GetAsync(int id);
        Task<int> CreateAsync(HistoryStatus historyStatus);
        Task<int> UpdateAsync(HistoryStatus historyStatus);
        Task<int> DeleteAsync(HistoryStatus historyStatus);
    }
}
