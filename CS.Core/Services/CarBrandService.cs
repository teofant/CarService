using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IGenericRepository<CarBrand> _carBrandRepository;
        public CarBrandService(IGenericRepository<CarBrand> carBrandRepository)
        {
            _carBrandRepository = carBrandRepository;
        }
        public async Task<int> CreateAsync(CarBrand carBrand)
        {
            return await _carBrandRepository.CreateAsync(carBrand);
        }

        public async Task<int> DeleteAsync(CarBrand carBrand)
        {
            return await _carBrandRepository.DeleteAsync(carBrand);
        }

        public async Task<IEnumerable<CarBrand>> GetAllAsync()
        {
            return await _carBrandRepository.GetAllAsync();
        }

        public async Task<CarBrand> GetAsync(int id)
        {
            return await _carBrandRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(CarBrand carBrand)
        {
            return await _carBrandRepository.CreateAsync(carBrand);
        }
    }
}
