using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UtilityLayer
{
    public class DbConnection
    {
        internal static SqlConnection connection;
        static DbConnection()
        {
            connection = new SqlConnection(ConnectionString.CName);
            OpenConnection();
        }
        public static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
    }
}
