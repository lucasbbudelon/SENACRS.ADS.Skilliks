using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.ComponentModel;

namespace Domain.Models
{
    public class JobApplicant : Entity, IEntity
    {

        [Category(EntityPropertyCategory.ForeignKey)]
        public int IdJob { get; set; }

        [Category(EntityPropertyCategory.ForeignKey)]
        public int IdApplicant { get; set; }
               

        [Category(EntityPropertyCategory.Model)]
        public decimal SalaryClaim { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public decimal LastSalary { get; set; }

        
        [Category(EntityPropertyCategory.Relacional)]
        public User Applicant { get; set; }
                
        [Category(EntityPropertyCategory.Relacional)]
        public Job Job { get; set; }


        [Category(EntityPropertyCategory.LoadRunTime)]
        public decimal Ranking { get; set; }
    }
}
