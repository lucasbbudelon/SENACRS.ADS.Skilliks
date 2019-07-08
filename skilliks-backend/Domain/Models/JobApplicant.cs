using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.ComponentModel;

namespace Domain.Models
{
    public class JobApplicant : Entity, IEntity
    {

        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdJob { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public Job Job { get; set; }


        [Category(EntityPropertyCategory.ForeignKey)]
        public long IdApplicant { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public User Applicant { get; set; }


        [Category(EntityPropertyCategory.Model)]
        public double SalaryClaim { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public JobApplicantStatus Status { get; set; }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public double Score { get; set; }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public bool Star { get; set; }
    }

    public enum JobApplicantStatus
    {
        InProcess = 1,
        Approved = 2,
        Rejected = 3    
    }
}
