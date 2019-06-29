using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System;
using System.ComponentModel;

namespace Domain.Models
{
    public class JobInterview : Entity, IEntity
    {
        [Category(EntityPropertyCategory.ForeignKey)]
        public int? IdJobFeedBack { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public JobFeedBack JobFeedBack { get; set; }


        [Category(EntityPropertyCategory.ForeignKey)]
        public int IdJobApplicant { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public JobApplicant JobApplicant { get; set; }


        [Category(EntityPropertyCategory.ForeignKey)]
        public int IdUserTechnical { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public User UserTechnical { get; set; }


        [Category(EntityPropertyCategory.ForeignKey)]
        public int IdUserRecruiter { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public User UserRecruiter { get; set; }


        [Category(EntityPropertyCategory.Model)]
        public DateTime? Date { get; set; }
    }
}
