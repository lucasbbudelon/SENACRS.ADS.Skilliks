using System;
using Domain.Contracts.Entity;

namespace Domain.Model
{
    public class Skill : IEntity
    {
        public Skill()
        {

        }

        public long Id { get; set; }
        public bool? IsExcluded { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? RegistryDate { get; set; }

        public string Name { get; set; }

    }
}