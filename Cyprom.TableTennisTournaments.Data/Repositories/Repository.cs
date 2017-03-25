using System;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model;
using Cyprom.TableTennisTournaments.Data.Interfaces;
using Cyprom.TableTennisTournaments.Data.Properties;

namespace Cyprom.TableTennisTournaments.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Identifiable 
    {
        private const string SEPARATOR = "|";

        protected abstract string TableName
        {
            get;
        }

        protected abstract Dictionary<string, object> ObjectToDictionary(T obj);
        protected abstract T DictionaryToObject(Dictionary<string, object> dict);

        public bool Exists(Guid id)
        {
            var query = new StringBuilder();
            query.Append("SELECT TOP 1 * FROM [");
            query.Append(TableName);
            query.Append("] WHERE ID = @id");
            var result = false;
            using (var connection = new SqlCeConnection(Settings.Default.DatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }

        public List<T> SelectAll()
        {
            var columns = ObjectToDictionary(null).Keys;
            var query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(string.Join(", ", columns));
            query.Append(" FROM [");
            query.Append(TableName);
            query.Append("]");

            var results = new List<T>();
            using (var connection = new SqlCeConnection(Settings.Default.DatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand(query.ToString(), connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var result = new Dictionary<string, object>();
                    foreach (var column in columns)
                    {
                        result[column] = reader[column];
                    }
                    results.Add(DictionaryToObject(result));
                }
                connection.Close();
            }
            return results;
        }

        public T Select(Guid id)
        {
            var columns = ObjectToDictionary(null).Keys;
            var query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(string.Join(", ", columns));
            query.Append(" FROM [");
            query.Append(TableName);
            query.Append("] WHERE ID = @id");
            T selection = null;
            
            using (var connection = new SqlCeConnection(Settings.Default.DatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var result = new Dictionary<string, object>();
                    foreach (var column in columns)
                    {
                        result[column] = reader[column];
                    }
                    selection = DictionaryToObject(result);
                }
                connection.Close();
            }
            return selection;
        }

        public void Insert(T obj)
        {
            var parameters = ObjectToDictionary(obj);
            var query = new StringBuilder();
            query.Append("INSERT INTO [");
            query.Append(TableName);
            query.Append("] (");
            query.Append(string.Join(", ", parameters.Keys));
            query.Append(") VALUES (");
            query.Append(string.Join(", ", parameters.Keys.Select(p => string.Format("@{0}", p.ToLowerInvariant()))));
            query.Append(")");
            using (var connection = new SqlCeConnection(Settings.Default.DatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand(query.ToString(), connection);
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key.ToLowerInvariant(), parameter.Value);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(T obj)
        {
            var parameters = ObjectToDictionary(obj);
            var query = new StringBuilder();
            query.Append("UPDATE [");
            query.Append(TableName);
            query.Append("] SET ");
            query.Append(string.Join(", ", parameters.Select(p => string.Format("{0} = @{1}", p.Key, p.Key.ToLowerInvariant()))));
            query.Append(" WHERE ID = @id");
            using (var connection = new SqlCeConnection(Settings.Default.DatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand(query.ToString(), connection);
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key.ToLowerInvariant(), parameter.Value);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(Guid id)
        {
            var query = new StringBuilder();
            query.Append("DELETE FROM [");
            query.Append(TableName);
            query.Append("] WHERE ID = @id");
            using (var connection = new SqlCeConnection(Settings.Default.DatabaseConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand(query.ToString(), connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        protected string ListJoin(string[] list)
        {
            return string.Join(SEPARATOR, list);
        }

        protected string[] ListSplit(string list)
        {
            return list.Split(new string[] {SEPARATOR}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
