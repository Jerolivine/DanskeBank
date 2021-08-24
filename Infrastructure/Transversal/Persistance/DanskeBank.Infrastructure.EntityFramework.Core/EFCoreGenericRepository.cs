using DanskeBank.Domain.Core.Entity;
using DanskeBank.Domain.Core.Repository;
using DanskeBank.Infrastructure.EntityFramework.Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DanskeBank.Infrastructure.EntityFramework.Core
{
    public class EFCoreGenericRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
       where TPrimaryKey : struct
    {
        //protected EFCoreDbContext _dbContext => EFCoreUnitOfWork.Current.Context;

        protected readonly EFCoreDbContext _dbContext;

        public EFCoreGenericRepository(EFCoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public TPrimaryKey Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return entity.Id;
        }

        public Task<TPrimaryKey> AddAsnyc(TEntity entity)
        {
            return Task.Run(() => { return Add(entity); });
        }

        public void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Attach(entity);
            }
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() => { Delete(entity); });
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Task.Run(() => { return Get(filter); });
        }

        public TEntity GetById(TPrimaryKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return Task.Run(() => { return GetById(id); });
        }

        public List<TEntity> GetList()
        {
            IQueryable<TEntity> queryable = _dbContext.Set<TEntity>();
            return queryable.ToList();
        }

        public Task<List<TEntity>> GetListAsync()
        {
            return Task.Run(() => { return GetList(); });
        }

        public void Remove(TEntity entity)
        {
            TEntity dataEntity = GetById(entity.Id);
            if (dataEntity == null) throw new SqlNullValueException("Record Not Found For Remove");
            _dbContext.Set<TEntity>().Remove(dataEntity);
        }

        public Task RemoveAsnyc(TEntity entity)
        {
            return Task.Run(() => { Remove(entity); });
        }

        public TEntity Update(TEntity entity)
        {
            TEntity entityDb = GetById(entity.Id);
            _dbContext.Entry(entityDb).CurrentValues.SetValues(entity);
            return entity;
        }

        public Task<TEntity> UpdateAsnyc(TEntity entity)
        {
            return Task.Run(() => { return Update(entity); });
        }

        public IQueryable<TEntity> Queryable()
        {
            IQueryable<TEntity> queryable = _dbContext.Set<TEntity>();
            return queryable;
        }
    }
}
