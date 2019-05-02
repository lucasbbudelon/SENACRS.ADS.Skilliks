using Dapper;
using Domain.Contracts.Entity;
using Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Infrastructure
{
    public class EntityRepository<T> : SqLiteBaseRepository, IRepository<T> where T : class, IEntity
    {
        public T Get(long id)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var sql = string.Format("SELECT * FROM {0} WHERE Id = @id;", EntityName);

                    connection.Open();
                    var result = connection.Query<T>(sql, new { id });
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<T> GetAll()
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var sql = string.Format("SELECT * FROM {0} WHERE IsExcluded=FALSE AND IsEnabled=TRUE;",
                        EntityName);

                    connection.Open();
                    var result = connection.Query<T>(sql);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Insert(T entity)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    entity.IsEnabled = true;
                    entity.IsExcluded = false;
                    entity.RegistryDate = DateTime.Now;

                    var properties = GetProperties(entity, "Id");

                    var columns = string.Join(", ", properties);
                    var values = string.Concat("@", string.Join(", @", properties));

                    var sql = string.Format("INSERT INTO {0} ({1}) VALUES({2}); select last_insert_rowid();",
                        EntityName, columns, values);

                    connection.Open();
                    entity.Id = connection.Query<long>(sql, entity).First();
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(long Id, T entity)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var properties = GetProperties(entity, "Id,IsExcluded,RegistryDate");

                    var values = properties.Select(p => string.Concat(p, "=@", p));
                    var set = string.Join(",", values);

                    var sql = string.Format("UPDATE {0} SET {1} WHERE Id = @Id;",
                        EntityName, set);

                    entity.Id = Id;
                    connection.Open();
                    connection.Query<T>(sql, entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long Id)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var sql = string.Format("UPDATE {0} SET IsExcluded=TRUE WHERE Id = @Id;", EntityName);

                    connection.Open();
                    connection.Query<T>(sql, new { Id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region private

        private string EntityName
        {
            get
            {
                return typeof(T).Name;
            }
        }

        private List<string> GetProperties(T entity, string ignore)
        {
            var ignoreProperties = ignore.Split(',');
            var properties = typeof(T).GetProperties()
                .Where(p => !ignoreProperties.Contains(p.Name) && typeof(T).GetProperty(p.Name).GetValue(entity, null) != null)
                .Select(p => p.Name);

            return properties.ToList();
        }
        #endregion
    }
}
