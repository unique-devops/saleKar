using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Data.Db
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _config;

        public DbConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection CreateConnection()
        {
            string provider = _config["DatabaseProvider"];
            if (provider == "SqlServer")
            {
                string cs = _config.GetConnectionString("SqlServer");
                return new SqlConnection(cs);
            }
            else if (provider == "SQLite")
            {
                string cs = _config.GetConnectionString("SQLite");
                return new SqliteConnection(cs);
            }
            else
            {
                throw new NotSupportedException($"Database provider '{provider}' is not supported.");
            }
        }
    }
}
