using Domain.Contracts.Entity;
using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class User: IEntity
    {
        public long Id { get; set; }
        public bool? IsExcluded { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? RegistryDate { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public UserType? Type { get; set; }
        public UserEmployee? Employee { get; set; }

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



