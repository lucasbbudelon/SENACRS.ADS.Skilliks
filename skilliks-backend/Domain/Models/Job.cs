
using System.Collections.Generic;
using System.ComponentModel;
using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;

namespace Domain.Models
{
    public class Job : Entity, IEntity
    {
        [Category(EntityPropertyCategory.Model)]
        public string Name { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Description { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public Level Level { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public double Remuneration { get; set; }


        [Category(EntityPropertyCategory.Relacional)]
        public List<JobSkill> Skills { get; set; }
    }

    public enum Level
    {
        Trainee = 0,
        Junior = 1,
        Full = 2,
        Senior = 3
    }
}
