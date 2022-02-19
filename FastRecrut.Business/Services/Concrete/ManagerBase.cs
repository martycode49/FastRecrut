﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.DataAccess.Abstract;
using FastRecrut.Core.Services.Abstract;
using FastRecrut.DataAccess.Abstract;

namespace FastRecrut.Business.Services.Concrete
{
    public class ManagerBase<TEntity> : IService<TEntity> where TEntity: class
    {
        public readonly IUnitOfWork _UnitOfWork;
        private readonly IEntityRepository<TEntity> _repository;

        public ManagerBase(IUnitOfWork unitOfWork, IEntityRepository<TEntity> repository)
        {
            _UnitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _UnitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _UnitOfWork.CommitAsync();
            return entities;
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _UnitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _UnitOfWork.Commit();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            _UnitOfWork.Commit();
        }

    }
}
