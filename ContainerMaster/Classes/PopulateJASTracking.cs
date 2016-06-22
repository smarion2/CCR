using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCR
{
    public static class PopulateJASTracking
    {
        public static void GetTrackingNumbers()
        {            
            DataSet ds = new DataSet();
            DataTable poTable = new DataTable();
            DataTable ediTable = new DataTable();

            string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";

            poTable = GetData.ExecuteQuery("SELECT externalnumber as SHPID, trackingnumber as PRONO, trackingnumber as LOADNO FROM SWCCSSBOX where datecreated >= DATEADD(month, DATEDIFF(month, 0, getdate()), 0) - 31 and trackingnumber != '' and customernumber = '    224590'", connectionString); //ds.Tables["po_Details"];

            SqlConnection ediCon = new SqlConnection();
            string ediConnectionString = "Data Source=srv-edi;Initial Catalog=ediengine;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
            ediCon.ConnectionString = ediConnectionString;
            ediCon.Open();

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(ediConnectionString))
            {
                try
                {
                    bulkcopy.DestinationTableName = "[856tmp]";

                    bulkcopy.ColumnMappings.Add("SHPID", "SHPID");
                    bulkcopy.ColumnMappings.Add("PRONO", "PRONO");
                    bulkcopy.ColumnMappings.Add("LOADNO", "LOADNO");
                    bulkcopy.WriteToServer(poTable);
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Failed to populate tracking numbers into EDI engine", ex.ToString());
                }

            }
            using (var conn = new SqlConnection(ediConnectionString))
            using (var command = new SqlCommand("UpdateTrackingNumbers", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            ediCon.Close();

            MessageBox.Show("Order numbers populated", "Complete", MessageBoxButtons.OK);
        }
    }
}
