using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Infrastructure.Query;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace Common.Infrastructure.Query
{
    public abstract class AbstractQueryService
    {
        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["PaaSystem"].ConnectionString);
            }
        }

        public AbstractQueryService(string connectionString, string providerName)
        {
            this.providerFactory = DbProviderFactories.GetFactory(providerName);
            this.connectionString = connectionString;
        }

        readonly DbProviderFactory providerFactory;
        readonly string connectionString;

        protected T QueryObject<T>(string query, JoinOn joinOn, params object[] arguments)
        {
            using (var conn = CreateOpenConnection())
            using (var selectStatement = CreateCommand(conn, query, arguments))
            using (var dataReader = selectStatement.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    return new ResultSetObjectMapper<T>(dataReader, joinOn).MapResultToType();
                }
                else
                {
                    return default(T);
                }
            }
        }

        protected IList<T> QueryObjects<T>(string query, JoinOn joinOn, params object[] arguments)
        {
            using (var conn = CreateOpenConnection())
            using (var selectStatement = CreateCommand(conn, query, arguments))
            using (var dataReader = selectStatement.ExecuteReader())
            {
                var objects = new List<T>();
                while (dataReader.Read())
                {
                    var obj = new ResultSetObjectMapper<T>(dataReader, joinOn).MapResultToType();
                    objects.Add(obj);
                }
                return objects;
            }
        }

        protected string QueryString(string query, params object[] arguments)
        {
            using (var conn = CreateOpenConnection())
            using (var selectStatement = CreateCommand(conn, query, arguments))
            using (var dataReader = selectStatement.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    return dataReader.GetString(0);
                }
                else
                {
                    return null;
                }
            }
        }

        DbCommand CreateCommand(DbConnection conn, string query, object[] args)
        {
            var command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            for (var i = 0; i < args.Length; i++)
            {
                var argument = args[i];
                var argumentType = argument.GetType();

                var parameter = command.CreateParameter();
                parameter.Value = argument;

                command.Parameters.Add(parameter);
            }

            return command;
        }

        DbConnection CreateOpenConnection()
        {
            var conn = this.providerFactory.CreateConnection();
            conn.ConnectionString = this.connectionString;
            conn.Open();
            return conn;
        }
    }
}
