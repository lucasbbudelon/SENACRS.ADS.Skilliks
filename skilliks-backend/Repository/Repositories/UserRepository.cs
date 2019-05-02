using Domain.Contracts.Repository;
using Domain.Model;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class UserRepository : EntityRepository<User>, IRepository<User>
    {
        public UserRepository()
        {

        }
    }
}
