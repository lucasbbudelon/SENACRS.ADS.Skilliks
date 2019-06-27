using Domain.Contracts.Repositories;
using Domain.Models;

namespace Data.Repositories
{
    public class JobFeedBackRepository : EntityRepository<JobFeedBack>, IJobFeedBackRepository
    {
    }
}
