using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace CCR
{
    public static class InputRetailData
    {
        public static void WriteToDatabase()
        {
            DataTable csvTable = new DataTable("retailData");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            int lineCounter = 0;
            int storesWithItems = 0;
            int highestStoreCount;
            double totalPOS = 0;
            string week;
            string year;
            string weekOfYear;
            float ROS;
            float averageROS = 0;
            float stores;
            float units;
            string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
            if (dialogResult == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath);


                using (CsvReader csv = new CsvReader(
                                       new StreamReader(filePath), true))
                {
                    csvTable.Load(csv);
                    csvTable.Columns.Add("convertedDate", typeof(DateTime));
                    csvTable.Columns.Add("ROS", typeof(float));
                    // count records and insert unique key to each row
                    foreach (DataRow row in csvTable.Rows)
                    {
                        lineCounter++;
                        week = row["weekNumber"].ToString();
                        year = week.Substring(0, 4);
                        weekOfYear = week.Substring(4);
                        stores = Convert.ToInt32(row["storeCount"]);
                        units = Convert.ToInt32(row["posUnits"]);
                        totalPOS += Convert.ToDouble(row["posAmount"]);
                        if (stores > 0)
                        {
                            storesWithItems++;
                            ROS = units / stores;
                            averageROS += ROS;
                        }
                        else
                            ROS = 0;

                        row["convertedDate"] = FirstDateOfWeek(Convert.ToInt32(year), Convert.ToInt32(weekOfYear));
                        row["ROS"] = ROS;
                    }
                }
                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connectionString))
                {
                    bulkcopy.DestinationTableName = "RetailCustomerData";

                    bulkcopy.ColumnMappings.Add("ccaStockNumber", "ccaStockNumber");
                    bulkcopy.ColumnMappings.Add("customerNumber", "customerNumber");
                    bulkcopy.ColumnMappings.Add("weekNumber", "weekNumber");
                    bulkcopy.ColumnMappings.Add("storeCount", "storeCount");
                    bulkcopy.ColumnMappings.Add("posUnits", "posUnits");
                    bulkcopy.ColumnMappings.Add("posAmount", "posAmount");
                    // bulkcopy.ColumnMappings.Add("posSales", "posSales");
                    // bulkcopy.ColumnMappings.Add("posMargin", "posMargin");
                    //bulkcopy.ColumnMappings.Add("cost", "cost");
                    // bulkcopy.ColumnMappings.Add("retailPrice", "retailPrice");
                    bulkcopy.ColumnMappings.Add("ROS", "ROS");
                    bulkcopy.ColumnMappings.Add("convertedDate", "convertedDate");

                    bulkcopy.WriteToServer(csvTable);
                }
                using (var conn = new SqlConnection(connectionString))
                using (var command = new SqlCommand("updateROS", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                //MessageBox.Show(counter + " sales records added and ROS calculated", "Complete", MessageBoxButtons.OK);
            }
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }
    }

}
