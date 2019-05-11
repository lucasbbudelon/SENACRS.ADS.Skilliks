using Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Migration.Versions
{
   public class _000 : IMigration
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
                             Category       NUMERIC
                          );");

            sql.AppendLine(@"create table Skill
                          (
                             Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                             IsExcluded     BOLEAN,
                             IsEnabled      BOLEAN,
                             RegistryDate   DATETIME,
                             Name           TEXT
                          );");

            sql.AppendLine(@"create table UserSkill
                          (
                             Id             INTEGER,
                             IsExcluded     BOLEAN,
                             IsEnabled      BOLEAN,
                             RegistryDate   DATETIME,
                             IdUser         INTEGER,
                             IdSkill        INTEGER,
                             Ranking        INTEGER
                          );");

            return sql.ToString();
        }

        public string Down()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"drop table User;");
            sql.AppendLine(@"drop table Skill;");
            sql.AppendLine(@"drop table UserSkill;");

            return sql.ToString();
        }
    }
}
