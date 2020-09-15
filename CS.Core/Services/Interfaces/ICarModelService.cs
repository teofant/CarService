using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface ICarModelService
    {
        Task<IEnumerable<CarModel>> GetAllAsync();
        Task<CarModel> GetAsync(int id);
        Task<int> CreateAsync(CarModel carModel);
        Task<int> UpdateAsync(CarModel carModel);
        Task<int> DeleteAsync(CarModel carModel);
    }
}
