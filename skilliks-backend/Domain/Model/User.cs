using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public UserEmployee Employee { get; set; }

        public User()
        {

        }

        public bool IsTechnical()
        {
            return Type.Equals(UserType.Employee) && Employee.Equals(UserEmployee.Technical);

        }
    }

    public enum UserType
    {
        Employee = 1,
        Applicant = 2
    }

    public enum UserEmployee
    {
        Technical = 1,
        HumanResources = 2
    }
}



