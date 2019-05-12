using System;
using System.ComponentModel;
using System.Collections.Generic;
using Domain.Contracts.Models;
using Domain.Constants;
using Domain.Models.Generic;

namespace Domain.Models
{
    public class User : Entity, IEntity
    {
        [Category(EntityPropertyCategory.Model)]
        public string Name { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Email { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public UserType Type { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public UserCategory Category { get; set; }


        [Category(EntityPropertyCategory.Relacional)]
        public List<UserSkill> Skills { get; set; }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public bool IsEnable
        {
            get
            {
                return DisabledDate == null;
            }
        }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public bool IsEmployee
        {
            get
            {
                return Type.Equals(UserType.Employee);
            }
        }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public bool IsTechnical
        {
            get
            {
                return Category.Equals(UserCategory.Technical);
            }
        }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public bool IsTechnicalEmployee
        {
            get
            {
                return IsTechnical && IsEmployee;
            }
        }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public bool IsTechnicalApplicant
        {
            get
            {
                return IsTechnical && !IsEmployee;
            }
        }
    }

    public class UserDashboard
    {
        public int Total { get; set; }
        public int New { get; set; }
        public int Active { get; set; }
        public int Inactive { get; set; }
    }

    public enum UserType
    {
        Employee = 1,
        Applicant = 2
    }

    public enum UserCategory
    {
        Technical = 1,
        HumanResources = 2
    }
}
