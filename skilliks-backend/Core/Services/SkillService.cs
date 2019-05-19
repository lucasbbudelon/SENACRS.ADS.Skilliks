using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class SkillService : ISkillService
    {
        public readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
        {
            _repository = repository;
        }
        
        public Skill Get(long id)
        {
            return _repository.Get(id);
        }

        public List<Skill> GetAll()
        {
            return _repository.GetAll();
        }

        public Skill Insert(Skill entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(long id, Skill entity)
        {
            _repository.Update(id, entity);
        }

        public void Delete(long id)
        {
            _repository.DeleteLogical(id);
        }
    }
}
