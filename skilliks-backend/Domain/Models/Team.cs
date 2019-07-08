using Domain.Constants;
using Domain.Contracts.Models;
using Domain.Models.Generic;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Models
{
   public class Team : Entity, IEntity
    {
        [Category(EntityPropertyCategory.Model)]
        public string Image { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Name { get; set; }

        [Category(EntityPropertyCategory.Model)]
        public string Description { get; set; }

        [Category(EntityPropertyCategory.Relacional)]
        public List<User> Users { get; set; }

        [Category(EntityPropertyCategory.LoadRunTime)]
        public int Jobs { get; set; }
    }
}
