using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class RepairService : IRepairService
    {
        private readonly IGenericRepository<Repair> _repairRepository;
        public RepairService(IGenericRepository<Repair> repairRepository)
        {
            _repairRepository = repairRepository;
        }

        public async Task<int> CreateAsync(Repair repair)
        {
            return await _repairRepository.CreateAsync(repair);
        }

        public async Task<int> DeleteAsync(Repair repair)
        {
            return await _repairRepository.DeleteAsync(repair);
        }

        public async Task<IEnumerable<Repair>> GetAllAsync()
        {
            return await _repairRepository.GetAllAsync();
        }

        public async Task<Repair> GetAsync(int id)
        {
            return await _repairRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(Repair repair)
        {
            return await _repairRepository.UpdateAsync(repair);
        }
    }
}
