using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLayer
{
    public class DBConfig:DbConnection
    {
        public static DataTable ExecuteSpDataTable(string SPName)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter(SPName, ConnectionString.CName);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            return dataTable;
        }

        public static DataSet ExecuteSpDataSet(string SPName, ArrayList sqlParamters)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter(SPName, ConnectionString.CName);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in sqlParamters)
            {
                sqlData.SelectCommand.Parameters.Add(parameter);
            }
            DataSet dataTable = new DataSet();
            sqlData.Fill(dataTable);
            return dataTable;
        }
        public static DataTable ExecuteSpDataTable(string SPName, ArrayList sqlParamters)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter(SPName, ConnectionString.CName);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in sqlParamters)
            {
                sqlData.SelectCommand.Parameters.Add(parameter);
            }
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            return dataTable;
        }

        public static void ExecuteSpExecuteNonQuery(string SPName, ArrayList sqlParameters)
        {
            SqlCommand cmd = new SqlCommand(SPName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                cmd.Parameters.Add(sqlParameter);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            cmd.ExecuteNonQuery();
            connection.Close();
        }
       
        public static int ExecuteSpExecuteScalar(string SPName, ArrayList sqlParameters)
        {
            SqlCommand cmd = new SqlCommand(SPName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                cmd.Parameters.Add(sqlParameter);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            int result = (int)cmd.ExecuteScalar();
            connection.Close();
            return result;
        }

        public int ExecuteSpExecuteScalar(string v)
        {
            throw new NotImplementedException();
        }
    }
}
