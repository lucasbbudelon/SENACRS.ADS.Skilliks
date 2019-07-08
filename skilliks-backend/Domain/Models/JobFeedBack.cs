using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Models
{
    public class JobFeedBack : Entity, IEntity
    {
        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdJob { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public Job Job { get; set; }

        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdApplicant { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public User Applicant { get; set; }

        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdUserTecnical { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public User UserTechnical { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Technical { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Recruiter { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public List<JobFeedBackSkill> Skills { get; set; }
    }
}
