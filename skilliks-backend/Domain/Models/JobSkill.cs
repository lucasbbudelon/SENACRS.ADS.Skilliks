using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.ComponentModel;

namespace Domain.Models
{
    public class JobSkill : Entity, IEntity
    {
        [Category(EntityPropertyCategory.RelacionalKey)]
        public long IdJob { get; set; }

        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdSkill { get; set; }


        [Category(EntityPropertyCategory.Model)]
        public int Ranking { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public int Weight { get; set; }


        [Category(EntityPropertyCategory.Relacional)]
        public Skill Skill { get; set; }
    }
}
