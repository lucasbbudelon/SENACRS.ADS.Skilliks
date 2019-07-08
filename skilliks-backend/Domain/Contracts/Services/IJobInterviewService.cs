using Domain.Models;
using Domain.Contracts.Services.Generic;
using System.Collections.Generic;

namespace Domain.Contracts.Services
{
    public interface IJobInterviewService : IEntityService<JobInterview>
    {
        List<JobInterview> GetAll(User user);
    }
}
