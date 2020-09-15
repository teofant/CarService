using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class OwnerRepairService : IOwnerRepairService
    {
        private readonly IGenericRepository<OwnerRepair> _ownerRepairRepository;
        public OwnerRepairService(IGenericRepository<OwnerRepair> ownerRepairRepository)
        {
            _ownerRepairRepository = ownerRepairRepository;
        }

        public async Task<int> CreateAsync(OwnerRepair ownerRepair)
        {
            return await _ownerRepairRepository.CreateAsync(ownerRepair);
        }

        public async Task<int> DeleteAsync(OwnerRepair ownerRepair)
        {
            return await _ownerRepairRepository.DeleteAsync(ownerRepair);
        }

        public async Task<IEnumerable<OwnerRepair>> GetAllAsync()
        {
            return await _ownerRepairRepository.GetAllAsync();
        }

        public async Task<OwnerRepair> GetAsync(int id)
        {
            return await _ownerRepairRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(OwnerRepair ownerRepair)
        {
            return await _ownerRepairRepository.UpdateAsync(ownerRepair);
        }
    }
}
