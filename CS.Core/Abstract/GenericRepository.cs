using CS.Core.Abstract.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.Abstract
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected Task<int> SaveAsync() => _unitOfWork.Context.SaveChangesAsync();

        public async Task<int> CreateAsync(TEntity entity)
        {
            _unitOfWork.Context.Add(entity);
            return await SaveAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _unitOfWork.Context.Remove(entity);
            return await SaveAsync();
        }

        public async Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            _unitOfWork.Context.RemoveRange(entities);
            return await SaveAsync();
        }

        public async Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Context.Set<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Context.Set<TEntity>().FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _unitOfWork.Context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _unitOfWork.Context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            return await SaveAsync();
        }
    }
}
