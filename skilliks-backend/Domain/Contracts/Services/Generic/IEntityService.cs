using Domain.Contracts.Models;
using System.Collections.Generic;

namespace Domain.Contracts.Services.Generic
{
    public interface IEntityService<T> where T : IEntity
    {
        T Get(long id);
        List<T> GetAll();
        T Insert(T entity);
        void Update(long id, T entity);
        void Delete(long id);
    }
}
