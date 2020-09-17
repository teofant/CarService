using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class HistoryStatusService : IHistoryStatusService
    {
        private readonly IGenericRepository<HistoryStatus> _historyStatusRepository;
        public HistoryStatusService(IGenericRepository<HistoryStatus> historyStatusRepository)
        {
            _historyStatusRepository = historyStatusRepository;
        }

        public async Task<int> CreateAsync(HistoryStatus historyStatus)
        {
            return await _historyStatusRepository.CreateAsync(historyStatus);
        }
        public async Task<IEnumerable<HistoryStatus>> GetByRepairIdAsync(int id)
        {
            return await _historyStatusRepository.FindAsync(h => h.RepairId == id);
        }
        public async Task<int> DeleteAsync(HistoryStatus historyStatus)
        {
            return await _historyStatusRepository.DeleteAsync(historyStatus);
        }

        public async Task<IEnumerable<HistoryStatus>> GetAllAsync()
        {
            return await _historyStatusRepository.GetAllAsync();
        }

        public async Task<HistoryStatus> GetAsync(int id)
        {
            return await _historyStatusRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(HistoryStatus historyStatus)
        {
            return await _historyStatusRepository.UpdateAsync(historyStatus);
        }
    }
}
