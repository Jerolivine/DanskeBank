using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Core.Abstract;
using DanskeBank.Domain.Core.Entity;
using DanskeBank.Domain.Core.Repository;
using DanskeBank.Mapper;
using System.Collections.Generic;

namespace DanskeBank.Application.Core.Concrete
{
    public class GenericService<TEntity, TDto, TPrimaryKey> : IGenericService<TEntity, TDto, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDto : class
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IMap _map;

        public GenericService(
            IRepository<TEntity, TPrimaryKey> repository,
            IMap map)
        {
            _repository = repository;
            _map = map;
        }

        public ValueResult<TPrimaryKey> Add(TDto dto)
        {
            TEntity entity = _map.Map<TEntity>(dto);
            TPrimaryKey id = _repository.Add(entity);
            return new ValueResult<TPrimaryKey>() { Value = id };
        }

        public BaseResult Delete(TPrimaryKey primaryKey)
        {
            TEntity entity = _repository.GetById(primaryKey);

            _repository.Delete(entity);
            return new BaseResult();
        }

        public ValueResult<TDto> Get(TPrimaryKey primaryKey)
        {
            TEntity entity = _repository.GetById(primaryKey);
            var value = _map.Map<TDto>(entity);

            return new ValueResult<TDto>() { Value = value };
        }

        public ValueResult<List<TDto>> GetAll()
        {
            var entities = _repository.GetList();
            var dtos = _map.Map<List<TDto>>(entities);
            return new ValueResult<List<TDto>>() { Value = dtos };
        }

        public ValueResult<TDto> Update(TDto dto)
        {
            TEntity entity = _map.Map<TEntity>(dto);
            TEntity result = _repository.Update(entity);
            var value = _map.Map<TDto>(result);
            return new ValueResult<TDto>() { Value = value };
        }
    }
}
