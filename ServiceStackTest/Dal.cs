using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStackTest
{
    public class Dal
    {
        public static IDbConnection OpenConnection(string database)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[database].ConnectionString;
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}