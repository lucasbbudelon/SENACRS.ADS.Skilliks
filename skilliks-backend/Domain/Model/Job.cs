using Domain.Contracts.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Job: IEntity
    {
        public Job()
        {

        }

        public long Id { get; set; }
        public bool? IsExcluded { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? RegistryDate { get; set; }

        public string Nome { get; set; }
        public Level Ranking { get; set; }
        public List<Skill> Skills { get; set; }
    }

    public enum Level
    {
        Trainee = 0,
        Junior = 1,
        Pleno = 2,
        Senior = 3
    }
}
