using Domain.Contracts.Entity;
using System;
using System.Collections.Generic;

namespace Domain.Contracts.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(long id);
        List<T> GetAll();
        T Insert(T entity);
        void Update(long Id, T entity);
        void Delete(long Id);
    }
}
