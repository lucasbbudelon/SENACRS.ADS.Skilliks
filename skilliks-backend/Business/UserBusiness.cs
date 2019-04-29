using System;
using System.Collections.Generic;
using Domain.Model;
using Repository;

namespace Business
{
    public class UserBusiness
    {
        private UserRepository _repository;

        public UserBusiness()
        {
            _repository = new UserRepository();
        }

        public bool Save(User user)
        {
            var currentUser = _repository.GetById(user.Id);

            if (currentUser == null)
            {
                return _repository.Insert(user) != null;
            }
            else
            {
                return _repository.Update(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
