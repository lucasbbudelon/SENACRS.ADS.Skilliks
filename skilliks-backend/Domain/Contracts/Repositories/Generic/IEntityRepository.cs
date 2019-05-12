using System.Collections.Generic;
using Domain.Contracts.Models;

namespace Domain.Contracts.Repositories.Generic
{
    public interface IEntityRepository<T> where T : IEntity
    {
        T Get(long id);

        List<T> GetAll();

        List<T> GetAllByRelacionalKey(long relacionalKey);

        T Insert(T entity);

        void Update(long id, T entity);

        void DeleteLogical(long id);

        void DeletePhysical(long id);

        void DeleteLogicalByRelacionalKey(long relacionalKey);

        void DeletePhysicalByRelacionalKey(long relacionalKey);
    }
}
