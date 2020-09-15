using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface ICarBrandService
    {
        Task<IEnumerable<CarBrand>> GetAllAsync();
        Task<CarBrand> GetAsync(int id);
        Task<int> CreateAsync(CarBrand carBrand);
        Task<int> UpdateAsync(CarBrand carBrand);
        Task<int> DeleteAsync(CarBrand carBrand);
    }
}
