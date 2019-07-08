using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.ComponentModel;

namespace Domain.Models
{
    public class JobFeedBackSkill : Entity, IEntity
    {
        [Category(EntityPropertyCategory.RelacionalKey)]
        public long IdJobFeedBack { get; set; }

        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdSkill { get; set; }

        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdApplicant { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public long jobSkillRanking { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public int SelfEvaluation { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public int TechnicalEvaluation { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Comment { get; set; }
        
        [Category(EntityPropertyCategory.Relacional)]
        public Skill Skill { get; set; }

    }
}
