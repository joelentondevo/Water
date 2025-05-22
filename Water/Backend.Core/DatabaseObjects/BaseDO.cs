using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.ConfigurationObjects;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Backend.Core.DatabaseObjects
{
    internal class BaseDO
    {
        private readonly string connectionString;

        internal BaseDO()
        {
            connectionString = new BackendCoreConfiguration().GetConfig().GetConnectionString("Backend");
        }
        public DataSet RunSP_DS(string storedProcedure, params (string, object)[] parameters)
        {
            ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach ((string parameterKey, object parameterValue) in parameters)
                    {
                        command.Parameters.AddWithValue(parameterKey, parameterValue);
                    }
                }

                connection.Open();
                DataSet dataSet = new DataSet();
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public bool RUNSP_Bool(string storedProcedure, params (string, object)[] parameters)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach ((string parameterKey, object parameterValue) in parameters)
                    {
                        command.Parameters.AddWithValue(parameterKey, parameterValue);
                    }
                }

                connection.Open();
                bool result = false;
                try
                {
                    command.ExecuteNonQuery();
                    result = true;
                    return result;
                }
                catch
                {
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

