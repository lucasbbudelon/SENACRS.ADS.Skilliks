﻿using Domain.Contracts.Repositories;
using Domain.Models;

namespace Data.Repositories
{
    public class JobApplicantRepository : EntityRepository<JobApplicant>, IJobApplicantRepository
    {
    }
}
