using Common.ApiResult;
using Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IRepos<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        ServiceResult Add(TEntity entity);
        Task<ServiceResult> AddAsync(TEntity entity);
        ServiceResult AddRange(IEnumerable<TEntity> entities);
        Task<ServiceResult> AddRangeAsync(IEnumerable<TEntity> entities);
        void Attach(TEntity entity);
        ServiceResult Delete(TEntity entity);
        Task<ServiceResult> DeleteAsync(TEntity entity);
        ServiceResult DeleteRange(IEnumerable<TEntity> entities);
        Task<ServiceResult> DeleteRangeAsync(IEnumerable<TEntity> entities);
        void Detach(TEntity entity);
        TEntity GetById(params object[] ids);
        Task<TEntity> GetByIdAsync(params object[] ids);
        ServiceResult Update(TEntity entity);
        Task<ServiceResult> UpdateAsync(TEntity entity);
        ServiceResult UpdateRange(IEnumerable<TEntity> entities);
        Task<ServiceResult> UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
