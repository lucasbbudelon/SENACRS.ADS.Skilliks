
using System;

namespace Domain.Contracts.Models
{
    public interface IEntity
    {
        long Id { get; set; }
        bool IsExcluded { get; set; }
        bool IsEnabled { get; set; }
        DateTime RegistryDate { get; set; }
    }
}
