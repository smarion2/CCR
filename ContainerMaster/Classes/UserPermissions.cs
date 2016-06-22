using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CCR
{
    public class UserPermissions
    {
        private Dictionary<string, int> userPermissions = new Dictionary<string, int>();
        private DataTable userTable;
        private string connectionString = "Data Source = srv-swdb; Initial Catalog = swdb; Persist Security Info=True; User ID = swdb; Password=SouthWare99";
        private string query = "Select Admin, SalesMenu, PurchMenu, AnalysisMenu, AccountingMenu, EDIMenu from CCRlogins where UserName = @0";

        public Dictionary<string, int> GetSecuritySettings(string userName)
        {

           userTable = GetData.ExecuteQuery(query,connectionString, userName);

            foreach (DataRow row in userTable.Rows)
            {
                for (int i = 0; i <= userTable.Columns.Count - 1; i++)
                {
                    userPermissions.Add(userTable.Columns[i].ColumnName, Convert.ToInt32(userTable.Rows[0][i]));
                }
                //foreach (DataColumn column in userTable.Columns)
                //{
                //    if (Convert.ToInt32(row[column]) >= 0)
                //    { 
                //        userPermissions.Add(column.ColumnName, Convert.ToInt32(column));
                //    }
                //}
            }
            return userPermissions;
        }

        private DataTable GetUserTable(string userName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Select Admin, SalesMenu, PurchMenu, AnalysisMenu, AccountingMenu, EDIMenu from CCRlogins where UserName = '@userName'");
                command.Parameters.AddWithValue("@userName", userName);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(userTable);
            }

            return userTable;
        }


    }
}
