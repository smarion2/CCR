using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCR
{
    public static class ErrorLogger
    {
        private static string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";

        public static void LogError(string error, string ex)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO CCRErrors VALUES (@Username, @Error, @Exception, @Date)", conn))
                    {
                        command.Parameters.AddWithValue("@Username", System.Environment.MachineName);
                        command.Parameters.AddWithValue("@Error", error);
                        command.Parameters.AddWithValue("@Exception", ex);
                        command.Parameters.AddWithValue("@Date", System.DateTime.Today);
                        command.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Can't Connect to database email computer support to restart the Sync", "Error", MessageBoxButtons.OK);
                }

            }
        }

    }
}
