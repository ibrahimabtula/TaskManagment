using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Task.DAL
{
    public class ConnectionBuilder
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get { return _connectionString; }
        }

        public static void SetConnectionString(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public static SqlConnection GetOpenedConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

    }
}
