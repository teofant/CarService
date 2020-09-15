using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Services.Interfaces
{
    public interface ICarOwnerService
    {
        Task<IEnumerable<CarOwner>> GetAllAsync();
        Task<CarOwner> GetAsync(int id);
        Task<int> CreateAsync(CarOwner carOwner);
        Task<int> UpdateAsync(CarOwner carOwner);
        Task<int> DeleteAsync(CarOwner carOwner);
    }
}
