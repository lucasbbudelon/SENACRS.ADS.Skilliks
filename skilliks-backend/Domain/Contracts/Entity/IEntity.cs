using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Entity
{
    public interface IEntity
    {
        long Id { get; set; }
        bool? IsExcluded { get; set; }
        bool? IsEnabled { get; set; }
        DateTime? RegistryDate { get; set; }
    }
}
