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
        public bool IsExcluded { get; set; }

        [Category(EntityPropertyCategory.InternalControl)]
        public bool IsEnabled { get; set; }

        [Category(EntityPropertyCategory.InternalControl)]
        public DateTime RegistryDate { get; set; }
    }
}
