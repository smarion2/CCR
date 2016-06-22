using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CCR
{
    public class GetData
    {
        /// <summary>
        /// Returns datatable based on the query and connection string provided. Takes any number of parameters
        /// </summary>
        /// <param name="query">SQL query in string format</param>
        /// <param name="connString">Connection string to specify server to connect to</param>
        /// <param name="parameters">Optional Parameters for the query</param>
        /// <returns>Filled DataTable from SQL Server</returns>
        public static DataTable ExecuteQuery(String query, String connString, params String[] parameters) 
        {
            DataTable results = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        AddSqlParams(cmd, parameters);
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        adapt.Fill(results);
                        return results;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError("Failed to connect or execute query", ex.ToString());
                throw new Exception(ex.ToString());
            }
            
        }

        private static void AddSqlParams(SqlCommand cmd, params String[] sqlParams)
        {
            for (int i = 0; i < sqlParams.Length; i++)
            {
                // ?? returns null value for a parameter if it is not provided in the ExecuteQuery() method call
                cmd.Parameters.AddWithValue("@" + i, (object)sqlParams[i] ?? DBNull.Value);
            }
        }
    }
}
