using Domain.Contracts.Repositories;
using Domain.Models;

namespace Data.Repositories
{
    public class SkillRepository : EntityRepository<Skill>, ISkillRepository
    {
    }
}
