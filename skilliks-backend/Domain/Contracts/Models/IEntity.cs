
using System;

namespace Domain.Contracts.Models
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime? ExclusionDate { get; set; }
        DateTime? DisabledDate { get; set; }
        DateTime? RegistryDate { get; set; }
    }
}
