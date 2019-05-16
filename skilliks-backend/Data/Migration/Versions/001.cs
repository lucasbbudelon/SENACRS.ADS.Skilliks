using Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Migration.Versions
{
    public class _001 : IMigration
    {
        public string Up()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"create table User
                          (
                             Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             Name           TEXT,
                             Email          TEXT,
                             Type           NUMERIC,
                             Category       NUMERIC
                          );");

            sql.AppendLine(@"create table Skill
                          (
                             Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             Name           TEXT
                          );");

            sql.AppendLine(@"create table UserSkill
                          (
                             Id             INTEGER,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             IdUser         INTEGER,
                             IdSkill        INTEGER,
                             Ranking        INTEGER
                          );");

            sql.AppendLine(@"create table Job
                          (
                             Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             Name           TEXT,
                             Description    TEXT,
                             Level          NUMERIC,
                             Remuneration   DECIMAL
                          );");

            sql.AppendLine(@"create table JobSkill
                          (
                             Id             INTEGER,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             IdJob         INTEGER,
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
            sql.AppendLine(@"drop table Job;");
            sql.AppendLine(@"drop table JobSkill;");

            return sql.ToString();
        }
    }
}
