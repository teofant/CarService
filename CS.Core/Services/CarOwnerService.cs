using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class CarOwnerService : ICarOwnerService
    {
        private readonly IGenericRepository<CarOwner> _carOwnerRepository;
        public CarOwnerService(IGenericRepository<CarOwner> carOwnerRepository)
        {
            _carOwnerRepository = carOwnerRepository;
        }

        public async Task<int> CreateAsync(CarOwner carOwner)
        {
            return await _carOwnerRepository.CreateAsync(carOwner);
        }

        public async Task<int> DeleteAsync(CarOwner carOwner)
        {
            return await _carOwnerRepository.DeleteAsync(carOwner);
        }

        public async Task<IEnumerable<CarOwner>> GetAllAsync()
        {
            return await _carOwnerRepository.GetAllAsync();
        }

        public async Task<CarOwner> GetAsync(int id)
        {
            return await _carOwnerRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(CarOwner carOwner)
        {
            return await _carOwnerRepository.UpdateAsync(carOwner);
        }
    }
}
