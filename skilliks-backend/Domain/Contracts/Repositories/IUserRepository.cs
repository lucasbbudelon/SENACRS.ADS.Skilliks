using Domain.Contracts.Repositories.Generic;
using Domain.Models;

namespace Domain.Contracts.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}
