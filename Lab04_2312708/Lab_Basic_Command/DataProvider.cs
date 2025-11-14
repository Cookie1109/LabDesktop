using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Basic_Command
{
    public class DataProvider
    {
        private static DataProvider _instance;
        private readonly string connectionSTR;

        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataProvider();
                return _instance;
            }
        }

        private DataProvider()
        {
            connectionSTR = "Server=.;Initial Catalog=RLab04Desktop;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.Text;

                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }

        public DataTable ExecuteStoredProcedure(string procName, params SqlParameter[] procParams)
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
                int numOfRowsEffectted = command.ExecuteNonQuery();
                return numOfRowsEffectted;
            }
        }
    }
}
