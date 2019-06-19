using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.ComponentModel;

namespace Domain.Models
{
   public class Skill : Entity, IEntity
    {
        [Category(EntityPropertyCategory.Model)]
        public string Name { get; set; }
    }
}
