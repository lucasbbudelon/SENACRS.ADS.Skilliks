using Dapper;
using Domain.Model;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class MigrationRepository : SqLiteBaseRepository
    {
        public void Execute(Migration migration)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var sql = migration.GetSql();
                    connection.Open();
                    connection.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
