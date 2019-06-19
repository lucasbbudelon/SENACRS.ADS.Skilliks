﻿using Data.Repositories;
using Domain.Contracts.Repositories;
using Domain.Models;

namespace Data.Repositories
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
    }
}
