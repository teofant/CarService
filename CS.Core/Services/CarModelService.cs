using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly IGenericRepository<CarModel> _carModelRepository;
        public CarModelService(IGenericRepository<CarModel> carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public async Task<int> CreateAsync(CarModel carModel)
        {
            return await _carModelRepository.CreateAsync(carModel);
        }

        public async Task<int> DeleteAsync(CarModel carModel)
        {
            return await _carModelRepository.DeleteAsync(carModel);
        }

        public async Task<IEnumerable<CarModel>> GetAllAsync()
        {
            return await _carModelRepository.GetAllAsync();
        }

        public async Task<CarModel> GetAsync(int id)
        {
            return await _carModelRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(CarModel carModel)
        {
            return await _carModelRepository.UpdateAsync(carModel);
        }
    }
}
