using Domain.Contracts.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class UserSkills: IEntity
    {
        public UserSkills()
        {

        }

        public long Id { get; set; }
        public bool? IsExcluded { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? RegistryDate { get; set; }

        public User User { get; set; }
        public Skill Skill { get; set; }
        public int Ranking { get; set; }
    }
        
}
