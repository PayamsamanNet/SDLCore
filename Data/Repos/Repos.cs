using Common.ApiResult;
using Core.Base;
using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class Repos<TEntity> : IRepos<TEntity> where TEntity : class, IEntity
    {

        #region Properties
        protected readonly SDLDbContext DbContext;
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        #endregion

        #region DbSet
        public DbSet<TEntity> Entities { get; }

        #endregion

        #region Dbcontext


        public Repos(SDLDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>();
        }

        #endregion

        #region Add Method

        public virtual ServiceResult Add(TEntity entity)
        {
            try
            {
                var typeId = entity.GetType().GetProperty("Id").PropertyType.Name;
                if (typeId == "Guid")
                {
                    entity.GetType().GetProperty("Id").SetValue(entity, null);
                }
                Entities.Add(entity);
                DbContext.SaveChanges();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }


        public virtual ServiceResult AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.AddRange(entities);
                DbContext.SaveChanges();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }

        }
        public virtual async Task<ServiceResult> AddAsync(TEntity entity)
        {
            try
            {
                var typeId = entity.GetType().GetProperty("Id").PropertyType.Name;
                if (typeId == "Guid")
                {
                    entity.GetType().GetProperty("Id").SetValue(entity, null);
                }
                await Entities.AddAsync(entity);
                await DbContext.SaveChangesAsync();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return new ServiceResult(ResponseStatus.BadRequest);
                }
                else
                {
                    return new ServiceResult(ResponseStatus.ServerError);
                }

            }

        }
        public async Task<ServiceResult> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await Entities.AddRangeAsync(entities);
                await DbContext.SaveChangesAsync();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }



        #endregion

        #region Delete Method
        public ServiceResult Delete(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
                DbContext.SaveChanges();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

        public ServiceResult DeleteRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.RemoveRange(entities);
                DbContext.SaveChanges();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {
                return new ServiceResult(ResponseStatus.ServerError);

            }
        }

        public virtual async Task<ServiceResult> DeleteAsync(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
                await DbContext.SaveChangesAsync();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

        public virtual async Task<ServiceResult> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.RemoveRange(entities);
                await DbContext.SaveChangesAsync();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

        #endregion

        #region UpDate Method
        public virtual ServiceResult Update(TEntity entity)
        {
            try
            {
                Entities.Update(entity);
                DbContext.SaveChanges();
                return new ServiceResult(ResponseStatus.Success);

            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

        public virtual ServiceResult UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.UpdateRange(entities);
                DbContext.SaveChanges();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }

        }

        public virtual async Task<ServiceResult> UpdateAsync(TEntity entity)
        {
            try
            {
                Entities.Update(entity);
                await DbContext.SaveChangesAsync();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }


        public async Task<ServiceResult> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.UpdateRange(entities);
                await DbContext.SaveChangesAsync();
                return new ServiceResult(ResponseStatus.Success);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }




        #endregion

        #region GetById
        public virtual async Task<TEntity> GetByIdAsync(params object[] ids)
        {
            return await Entities.FindAsync(ids);
        }

        public virtual TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }

        #endregion

        #region Attach & Detach
        public virtual void Attach(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
        }

        public virtual void Detach(TEntity entity)
        {
            var entry = DbContext.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }


        #endregion


    }


}
