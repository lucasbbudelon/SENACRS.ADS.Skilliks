using Dapper;
using Data.Infrastructure;
using Data.Migration.Versions;
using Domain.Contracts.Models;
using Domain.Infra;
using System;

namespace Data.Migration
{
    public class MigrationRun : SqLiteBaseRepository
    {
        public Domain.Infra.Migration Migration { get; set; }

        public IMigration Version
        {
            get
            {
                switch (Migration.Version)
                {
                    case 000: return new _000();
                    default: throw new Exception("Migration version is not valid");
                }
            }
        }

        public string Sql
        {
            get
            {
                switch (Migration.Action)
                {
                    case MigrationAction.Up: return Version.Up();
                    case MigrationAction.Down: return Version.Down();
                    case MigrationAction.Reset:  return string.Concat(Version.Down(), Version.Up());
                    default: throw new Exception("Migration action is not valid");
                }
            }
        }

        public MigrationRun(Domain.Infra.Migration migration)
        {
            Migration = migration;
        }

        public void Execute()
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    connection.Open();
                    connection.Execute(Sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
