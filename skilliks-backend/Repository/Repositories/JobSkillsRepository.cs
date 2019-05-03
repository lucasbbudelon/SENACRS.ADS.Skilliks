using Domain.Contracts.Repository;
using Domain.Model;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class JobSkillsRepository : EntityRepository<JobSkills>, IRepository<JobSkills>
    {
        public JobSkillsRepository()
        {

        }
    }
}
