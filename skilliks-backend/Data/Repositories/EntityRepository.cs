using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Models;
using Domain.Contracts.Repositories;
using Domain.Contracts.Repositories.Generic;
using Data.Infrastructure;
using Domain.Constants;

namespace Data.Repositories
{
    public class EntityRepository<T> : SqLiteBaseRepository, IEntityRepository<T> where T : class, IEntity
    {
        public EntityInfo<T> EntityInfo { get; private set; }

        public EntityRepository()
        {
            EntityInfo = new EntityInfo<T>();
        }

        public T Get(long id)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var where = string.Concat(EntityInfo.Key, "=@", EntityInfo.Key);
                    var sql = string.Format("SELECT * FROM {0} WHERE {1};", EntityInfo.Name, where);

                    connection.Open();

                    var result = connection.Query<T>(sql, new { id });
                    return result.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.Get", EntityInfo.Name), ex);
            }
        }

        public List<T> GetAll()
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var sql = string.Format("SELECT * FROM {0};", EntityInfo.Name);

                    connection.Open();
                    var result = connection.Query<T>(sql);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.GetAll", EntityInfo.Name), ex);
            }
        }

        public List<T> GetAllByRelacionalKey(long relacionalKey)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var where = string.Concat(EntityInfo.RelacionalKey, "=@relacionalKey");
                    var sql = string.Format("SELECT * FROM {0} WHERE {1};", EntityInfo.Name, where);

                    connection.Open();

                    var result = connection.Query<T>(sql, new { relacionalKey });
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.GetAllByRelacionalKey", EntityInfo.Name), ex);
            }
        }

        public T Insert(T entity)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    entity.RegistryDate = DateTime.Now;

                    var columns = string.Join(", ", EntityInfo.PropertiesForInsert);
                    var values = string.Concat("@", string.Join(", @", EntityInfo.PropertiesForInsert));

                    var sql = string.Format("INSERT INTO {0} ({1}) VALUES({2}); select last_insert_rowid();", EntityInfo.Name, columns, values);

                    connection.Open();
                    var result = connection.Query<long>(sql, entity);
                    entity.Id = result.First();
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.Insert", EntityInfo.Name), ex);
            }
        }

        public void Update(long id, T entity)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    entity.Id = id;

                    var values = EntityInfo.PropertiesorUpdate.Select(p => string.Concat(p, "=@", p));
                    var set = string.Join(",", values);
                    var where = string.Concat(EntityInfo.Key, "=@", EntityInfo.Key);

                    var sql = string.Format("UPDATE {0} SET {1} WHERE {2};", EntityInfo.Name, set, where);

                    connection.Open();
                    connection.Query<T>(sql, entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.Update", EntityInfo.Name), ex);
            }
        }

        public void DeleteLogical(long id)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var exclusionDate = DateTime.Now;

                    var where = string.Concat(EntityInfo.Key, "=@", EntityInfo.Key);

                    var sql = string.Format("UPDATE {0} SET ExclusionDate=@exclusionDate WHERE {1};", EntityInfo.Name, where);

                    connection.Open();
                    connection.Query<T>(sql, new { id, exclusionDate });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.DeleteLogical", EntityInfo.Name), ex);
            }
        }

        public void DeletePhysical(long id)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var where = string.Concat(EntityInfo.Key, "=@", EntityInfo.Key);

                    var sql = string.Format("DELETE FROM {0} WHERE {1};", EntityInfo.Name, where);

                    connection.Open();
                    connection.Query<T>(sql, new { id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.DeletePhysical", EntityInfo.Name), ex);
            }
        }

        public void DeleteLogicalByRelacionalKey(long relacionalKey)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var exclusionDate = DateTime.Now;

                    var where = string.Concat(EntityInfo.RelacionalKey, "=@relacionalKey");

                    var sql = string.Format("UPDATE {0} SET ExclusionDate=@exclusionDate WHERE {1};", EntityInfo.Name, where);

                    connection.Open();
                    connection.Query<T>(sql, new { relacionalKey, exclusionDate });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.DeleteLogicalByRelacionalKey", EntityInfo.Name), ex);
            }
        }

        public void DeletePhysicalByRelacionalKey(long relacionalKey)
        {
            try
            {
                using (var connection = SimpleDbConnection())
                {
                    var where = string.Concat(EntityInfo.RelacionalKey, "=@relacionalKey");

                    var sql = string.Format("DELETE FROM {0} WHERE {1};", EntityInfo.Name, where);

                    connection.Open();
                    connection.Query<T>(sql, new { relacionalKey });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in {0}Repository.DeletePhysicalByRelacionalKey", EntityInfo.Name), ex);
            }
        }
    }
}
