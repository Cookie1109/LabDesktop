using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhaHang.DAO
{
    public class DataProvider
    {
        private static DataProvider _instance;
        private readonly string connectionSTR;
        public static DataProvider Instance
        {
            get { if (_instance == null) _instance = new DataProvider(); return _instance; }
        }
        private DataProvider()
        {
            connectionSTR = "Data Source=.;Initial Catalog=QuanLyNhaHang;Integrated Security=True";
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters )
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.Text;
                if(parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }

        public DataTable ExcuteStoredProcedure(string procName, params SqlParameter[] procParams)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            using (SqlCommand command = new SqlCommand(procName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (procParams != null && procParams.Length > 0)
                {
                    command.Parameters.AddRange(procParams);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }
        
        public int ExecuteNonQueryStoredProcedure(string procName, params SqlParameter[] procParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            using (SqlCommand command = new SqlCommand(procName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (procParams != null && procParams.Length > 0)
                {
                    command.Parameters.AddRange(procParams);
                }
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int ExecuteScalarStoredProcedure(string procName, params SqlParameter[] procParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            using (SqlCommand command = new SqlCommand(procName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (procParams != null && procParams.Length > 0)
                {
                    command.Parameters.AddRange(procParams);
                }
                connection.Open();
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}
