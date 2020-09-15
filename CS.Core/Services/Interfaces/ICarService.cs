using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetAsync(int id);
        Task<int> CreateAsync(Car car);
        Task<int> UpdateAsync(Car car);
        Task<int> DeleteAsync(Car car);
    }
}
