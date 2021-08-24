using DanskeBank.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DanskeBank.Domain.Core.Repository
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        TPrimaryKey Add(TEntity entity);
        Task<TPrimaryKey> AddAsnyc(TEntity entity);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);

        void Remove(TEntity entity);
        Task RemoveAsnyc(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        TEntity GetById(TPrimaryKey id);
        Task<TEntity> GetByIdAsync(TPrimaryKey id);

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsnyc(TEntity entity);

        List<TEntity> GetList();
        Task<List<TEntity>> GetListAsync();

        IQueryable<TEntity> Queryable();
    }
}
