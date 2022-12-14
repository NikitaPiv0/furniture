using System.Data.SqlClient;

namespace Мебель
{
    public class SQLHelper
    {
        SqlConnection connection;

        public SQLHelper(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                return true;
            }
        }
    }
}
