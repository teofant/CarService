using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class MasterService : IMasterService
    {
        private readonly IGenericRepository<Master> _masterRepository;
        public MasterService(IGenericRepository<Master> masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<int> CreateAsync(Master master)
        {
            return await _masterRepository.CreateAsync(master);
        }

        public async Task<int> DeleteAsync(Master master)
        {
            return await _masterRepository.DeleteAsync(master);
        }

        public async Task<IEnumerable<Master>> GetAllAsync()
        {
            return await _masterRepository.GetAllAsync();
        }

        public async Task<Master> GetAsync(int id)
        {
            return await _masterRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(Master master)
        {
            return await _masterRepository.UpdateAsync(master);
        }
    }
}
