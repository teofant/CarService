using CS.Core.Abstract.Interfaces;
using CS.Core.Entities;
using CS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _carRepository;
        public CarService(IGenericRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<int> CreateAsync(Car car)
        {
            return await _carRepository.CreateAsync(car);
        }

        public async Task<int> DeleteAsync(Car car)
        {
            return await _carRepository.DeleteAsync(car);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _carRepository.GetAllAsync();
        }

        public async Task<Car> GetAsync(int id)
        {
            return await _carRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(Car car)
        {
            return await _carRepository.UpdateAsync(car);
        }
    }
}
