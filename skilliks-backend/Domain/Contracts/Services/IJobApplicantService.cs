using Domain.Models;
using Domain.Contracts.Services.Generic;
using System.Collections.Generic;

namespace Domain.Contracts.Services
{
    public interface IJobApplicantService : IEntityService<JobApplicant>
    {
        List<JobApplicant> GetAll(User user);
    }
}
