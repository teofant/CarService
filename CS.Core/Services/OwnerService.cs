using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IGenericRepository<Owner> _ownerRepository;
        public OwnerService(IGenericRepository<Owner> ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<int> CreateAsync(Owner owner)
        {
            return await _ownerRepository.CreateAsync(owner);
        }

        public async Task<int> DeleteAsync(Owner owner)
        {
            return await _ownerRepository.DeleteAsync(owner);
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _ownerRepository.GetAllAsync();
        }

        public async Task<Owner> GetAsync(int id)
        {
            return await _ownerRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(Owner owner)
        {
            return await _ownerRepository.UpdateAsync(owner);
        }
    }
}
