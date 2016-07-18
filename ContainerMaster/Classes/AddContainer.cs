using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CCR
{
    public static class AddContainer
    {
        public static void ToDataTable(DataTable dt, int position = 0)
        {
            string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
            DataColumnCollection columns = dt.Columns;
            DataTable cmDetailsTable = GetData.ExecuteQuery("select * from CM_Details where Delivered is null order by Supplier, ETADate", connectionString);
            if (position == 0)
            {
                position = dt.Columns.Count;
            }
            if (columns.Contains("stocknumber") && columns.Contains("ponumber"))
            {
                DataTable cmDataTable = GetData.ExecuteQuery("select PONumber, ItemNumber, sum(ItemQty), data.CMID from CM_Data data join CM_Details details on data.CMID = details.CMID where Delivered is null group by ItemNumber, PONumber, data.CMID", connectionString);
                foreach (DataRow row in cmDetailsTable.Rows)
                {

                    // create container
                    string cmID = row["CMID"].ToString();
                    dt.Columns.Add("\"Supplier: " + row["Supplier"] + "\r\n" +
                                            "ETA: " + row["ETADate"] + "\r\n" +
                                            "Shipped: " + row["ShipDate"] + "\r\n" +
                                            "Cartons: " + row["ContainerQty"] + "\r\n" +
                                            "Delivery Mode: " + row["ShipType"] + "\r\n" +
                                            "Container number: " + row["ContainerNumber"] + "\"").SetOrdinal(position);
                    //System.Data.DataTable containerDeets = GetData.ExecuteQuery("select PONumber, ItemNumber, sum(itemqty) as ItemQty from CM_Data a join CM_Details b on a.CMID = b.CMID where b.CMID = @0 group by PONumber, ItemNumber", connectionString, cmID);
                    // fill container with data                    
                    for (int c = 0; c < cmDataTable.Rows.Count; c++)
                    {
                        for (int b = 0; b < dt.Rows.Count; b++)
                        {
                            string containerItem = cmDataTable.Rows[c]["POnumber"].ToString() + cmDataTable.Rows[c]["ItemNumber"].ToString();
                            string poItem = dt.Rows[b]["ponumber"].ToString() + dt.Rows[b]["stocknumber"];

                            if (containerItem == poItem && cmID == cmDataTable.Rows[c]["CMID"].ToString())
                            {
                                dt.Rows[b][position] = cmDataTable.Rows[c][2];
                                break;
                            }
                        }
                    }
                    position++;
                }
            }
            else if (columns.Contains("stocknumber"))
            {
                DataTable cmDataTable = GetData.ExecuteQuery("select ItemNumber, sum(itemqty) as ItemQty, a.CMID from CM_Data a join CM_Details b on a.CMID = b.CMID group by ItemNumber, a.CMID", connectionString);
                foreach (DataRow row in cmDetailsTable.Rows)
                {
                    // create container
                    string cmID = row["CMID"].ToString();

                    dt.Columns.Add("\"Supplier: " + row["Supplier"] + "\r\n" +
                                            "ETA: " + Convert.ToDateTime(row["ETADate"]).ToShortDateString() + "\r\n" +
                                            "Shipped: " + Convert.ToDateTime(row["ShipDate"]).ToShortDateString() + "\r\n" +
                                            "Cartons: " + row["ContainerQty"] + "\r\n" +
                                            "Delivery Mode: " + row["ShipType"] + "\r\n" +
                                            "Container number: " + row["ContainerNumber"] + "\"").SetOrdinal(position);
                    // fill container with data                    
                    for (int c = 0; c < cmDataTable.Rows.Count; c++)
                    {
                        for (int b = 0; b < dt.Rows.Count; b++)
                        {
                            string containerItem = cmDataTable.Rows[c][0].ToString();
                            string buyItem = dt.Rows[b]["stocknumber"].ToString();
                            if (containerItem == buyItem && cmID == cmDataTable.Rows[c]["CMID"].ToString())
                            {
                                dt.Rows[b][dt.Columns.Count - 1] = cmDataTable.Rows[c][1];
                                break;
                            }
                        }
                    }
                    position++;
                }
            }//return dt;
        }
    }


}
