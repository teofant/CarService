using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class RepairStatusService : IRepairStatusService
    {
        private readonly IGenericRepository<RepairStatus> _repairStatusRepository;
        public RepairStatusService(IGenericRepository<RepairStatus> repairStatusRepository)
        {
            _repairStatusRepository = repairStatusRepository;
        }

        public async Task<int> CreateAsync(RepairStatus repairStatus)
        {
            return await _repairStatusRepository.CreateAsync(repairStatus);
        }

        public async Task<int> DeleteAsync(RepairStatus repairStatus)
        {
            return await _repairStatusRepository.DeleteAsync(repairStatus);
        }

        public async Task<IEnumerable<RepairStatus>> GetAllAsync()
        {
            return await _repairStatusRepository.GetAllAsync();
        }

        public async Task<RepairStatus> GetAsync(int id)
        {
            return await _repairStatusRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(RepairStatus repairStatus)
        {
            return await _repairStatusRepository.UpdateAsync(repairStatus);
        }
    }
}
