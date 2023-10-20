using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common.Domain.Model;
using System.Configuration;

namespace Common.Infrastructure.Repository
{
    public abstract class Repository<TEntity, TID>
    //IRepository<TEntity, TID> where TEntity : IAggregateRoot
    {
        protected IDbConnection Connection
        {
            get
            {
                ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["PaaSystem"];
                return new SqlConnection(connectionStringSettings.ConnectionString);
            }
        }

        internal virtual dynamic Mapping(TEntity item)
        {
            return item;
        }

        public abstract void Add(TEntity item);
        public abstract void Remove(TEntity item);
        public abstract void Update(TEntity item);
        public abstract TEntity Find(TID id);
    }
}
