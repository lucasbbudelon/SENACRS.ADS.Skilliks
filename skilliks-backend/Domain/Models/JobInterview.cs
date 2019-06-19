using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.ComponentModel;

namespace Domain.Models
{
    public class JobInterview : Entity, IEntity
    {
        [Category(EntityPropertyCategory.ForeignKey)]
        public int IdFeedBack { get; set; }

        [Category(EntityPropertyCategory.ForeignKey)]
        public int IdApplicant { get; set; }
        

        [Category(EntityPropertyCategory.Relacional)]
        public JobApplicant Applicant { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public JobFeedBack FeedBack { get; set; }
    }
}
