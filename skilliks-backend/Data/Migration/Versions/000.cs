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
                             Id                 INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate      DATETIME,
                             DisabledDate       DATETIME,
                             RegistryDate       DATETIME,
                             Image              TEXT,
                             Background         TEXT,
                             Name               TEXT,
                             Description        TEXT,
                             Birthday           TEXT,
                             Email              TEXT,
                             Phone              TEXT,
                             Address            TEXT,
                             Type               NUMERIC,
                             Category           NUMERIC,
                             CurrentPosition    TEXT,
                             CurrentCompany     TEXT,
                             CurrentWage        DECIMAL
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
                             Remuneration   DECIMAL,
                             MinScore       DECIMAL,
                             IdTeam         INTEGER
                          );");

            sql.AppendLine(@"create table JobSkill
                          (
                             Id             INTEGER,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             IdJob          INTEGER,
                             IdSkill        INTEGER,
                             Ranking        INTEGER,
                             Weight         INTEGER
                          );");

            sql.AppendLine(@"create table JobApplicant
                          (
                             Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             IdJob          INTEGER,
                             IdApplicant    INTEGER,
                             SalaryClaim    DECIMAL,
                             Status         NUMERIC
                          );");

            sql.AppendLine(@"create table JobFeedBack
                          (
                             Id                 INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate      DATETIME,
                             DisabledDate       DATETIME,
                             RegistryDate       DATETIME,
                             IdJob              INTEGER,
                             IdApplicant        INTEGER,
                             IdUserTecnical     INTEGER,
                             Technical          TEXT,
                             Recruiter          TEXT
                          );");

            sql.AppendLine(@"create table JobFeedBackSkill
                          (
                             Id                     INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate          DATETIME,
                             DisabledDate           DATETIME,
                             RegistryDate           DATETIME,
                             IdJobFeedBack          INTEGER,
                             IdSkill                INTEGER,
                             jobSkillRanking        INTEGER,
                             SelfEvaluation         INTEGER,
                             TechnicalEvaluation    INTEGER,
                             Comment                TEXT
                          );");

            sql.AppendLine(@"create table JobInterview
                          (
                             Id                 INTEGER PRIMARY KEY AUTOINCREMENT,
                             ExclusionDate      DATETIME,
                             DisabledDate       DATETIME,
                             RegistryDate       DATETIME,
                             IdJobFeedBack      INTEGER,
                             IdJobApplicant     INTEGER,
                             IdUserTechnical    INTEGER,
                             IdUserRecruiter    INTEGER,
                             Date               DATETIME
                          );");

            sql.AppendLine(@"create table Team
                          (
                             Id             INTEGER,
                             ExclusionDate  DATETIME,
                             DisabledDate   DATETIME,
                             RegistryDate   DATETIME,
                             Image          TEXT,
                             Description    TEXT
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
            sql.AppendLine(@"drop table JobApplicant;");
            sql.AppendLine(@"drop table JobFeedBack;");
            sql.AppendLine(@"drop table JobFeedBackSkill;");
            sql.AppendLine(@"drop table JobInterview;");
            sql.AppendLine(@"drop table Team;");

            return sql.ToString();
        }
    }
}
