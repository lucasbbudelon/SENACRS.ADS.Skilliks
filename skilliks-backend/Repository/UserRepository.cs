using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class UserRepository
    {
        public UserRepository()
        {

        }

        public Guid Insert(User user)
        {
            user.Id = new Guid();

            //Salvar no banco de dados
            return user.Id;
        }

        public bool Update(User user)
        {
            //update no banco
            return true;
        }

        public User GetById(Guid id)
        {
            //select * from user where id = id
            return new User()
            {
                Id = new Guid(),
                Name = "Usuário Default",
                Email = "usuario@google.com",
                Employee = UserEmployee.Technical,
                Type = UserType.Employee
            };
        }

        public IEnumerable<User> GetAll()
        {
            var list = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new User()
                {
                    Id = new Guid(),
                    Name = "Usuário " + i.ToString(),
                    Email = "usuario@google.com",
                    Employee = UserEmployee.Technical,
                    Type = UserType.Employee
                });
            }

            return list;
        }
    }
}
