using Domain.Constants;
using System;
using System.ComponentModel;

namespace Domain.Models.Generic
{
   public class Entity
    {
        [Category(EntityPropertyCategory.Key)]
        public long Id { get; set; }


        [Category(EntityPropertyCategory.InternalControl)]
        public DateTime? ExclusionDate { get; set; }

        [Category(EntityPropertyCategory.InternalControl)]
        public DateTime? DisabledDate { get; set; }

        [Category(EntityPropertyCategory.InternalControl)]
        public DateTime? RegistryDate { get; set; }
    }
}
