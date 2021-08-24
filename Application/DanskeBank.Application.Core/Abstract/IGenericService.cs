using DanskeBank.Application.Contract.Core;
using DanskeBank.Domain.Core.Entity;
using System.Collections.Generic;

namespace DanskeBank.Application.Core.Abstract
{
    public interface IGenericService<TEntity, TDto, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey> 
        where TDto : class
    {
        ValueResult<TPrimaryKey> Add(TDto dto);
        BaseResult Delete(TPrimaryKey primaryKey);
        ValueResult<TDto> Get(TPrimaryKey primaryKey);
        ValueResult<List<TDto>> GetAll();
        ValueResult<TDto> Update(TDto dto);
    }
}
