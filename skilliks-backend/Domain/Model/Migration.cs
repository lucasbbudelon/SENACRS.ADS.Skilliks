using Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public enum MigrationAction
    {
        Up,
        Down,
        Reset
    }

    public class Migration
    {
        public string Name { get; set; }
        public MigrationAction Action { get; set; }

        public Migration(string name, MigrationAction action)
        {
            Name = name;
            Action = action;
        }

        public string GetSql()
        {
            string sql;
            IMigration migration;

            switch (Name)
            {
                case "InitialStructure":
                    migration = new InitialStructure();
                    break;

                default:
                    throw new Exception("Migration name is not valid");
            }

            switch (Action)
            {
                case MigrationAction.Up:
                    sql = migration.Up();
                    break;

                case MigrationAction.Down:
                    sql = migration.Down();
                    break;

                case MigrationAction.Reset:
                    sql = string.Concat(migration.Down(), migration.Up());
                    break;

                default:
                    throw new Exception("Migration action is not valid");
            }

            return sql;
        }
    }

    public class InitialStructure : IMigration
    {
        public string Up()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"create table User
                          (
                             Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                             IsExcluded     BOLEAN,
                             IsEnabled      BOLEAN,
                             RegistryDate   DATETIME,
                             Name           TEXT,
                             Email          TEXT,
                             Type           NUMERIC,
                             Employee       NUMERIC
                          );");

            return sql.ToString();
        }

        public string Down()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"drop table User;");

            return sql.ToString();
        }
    }
}
