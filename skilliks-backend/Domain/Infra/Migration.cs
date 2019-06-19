using Domain.Contracts.Models;
using System;
using System.Text;

namespace Domain.Infra
{
    public class Migration
    {
        public int Version { get; set; }
        public MigrationAction Action { get; set; }
    }

    public enum MigrationAction
    {
        Up,
        Down,
        Reset
    }
}
