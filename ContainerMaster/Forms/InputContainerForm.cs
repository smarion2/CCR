using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using LumenWorks.Framework.IO.Csv;



namespace CCR
{
    public partial class InputContainerForm : Form
    {
        public InputContainerForm()
        {
            InitializeComponent();
        }

        private void ContainerEditorForm_Load(object sender, EventArgs e)
        {

        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            DataTable csvTable = new DataTable("cmdata");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath);
                var cmid = Guid.NewGuid().ToString();
                
                // Create Data table for container header details
                DataTable cmDetails = new DataTable("cmDetails");
                cmDetails.Columns.Add("CMID", typeof(string));
                cmDetails.Columns.Add("Supplier", typeof(string));
                cmDetails.Columns.Add("ShipDate", typeof(DateTime));
                cmDetails.Columns.Add("ETADate", typeof(DateTime));
                cmDetails.Columns.Add("ShipType", typeof(string));
                cmDetails.Columns.Add("ContainerQty", typeof(float));
                cmDetails.Columns.Add("ContainerNumber", typeof(string));
                cmDetails.Columns.Add("Notes", typeof(string));
                // insert values from the form into the datatable as a row
                DataRow cmDetailsRow = cmDetails.NewRow();
                cmDetailsRow["CMID"] = cmid;
                cmDetailsRow["Supplier"] = SupplierText.Text;
                cmDetailsRow["ShipDate"] = ShippedCalander.SelectionRange.Start;
                cmDetailsRow["ETADate"] = EtaCalander.SelectionRange.Start;
                cmDetailsRow["ShipType"] = MODlistBox.Text;
                cmDetailsRow["ContainerQty"] = NumberOfCartons.Value;
                cmDetailsRow["ContainerNumber"] = TrackingText.Text;
                cmDetailsRow["Notes"] = notesTextBox.Text;
                cmDetails.Rows.Add(cmDetailsRow);
                int counter = 0;

                using (CsvReader csv = new CsvReader(
                                       new StreamReader(filePath), true))
                {
                    csvTable.Load(csv);
                    csvTable.Columns.Add("CMID", typeof(string));
                        // count records and insert unique key to each row
                        foreach (DataRow row in csvTable.Rows)
                        {
                            counter++;
                            row["CMID"] = cmid;
                        }
                }

                // check the CSV to make sure PO and item combo exist in the data base. 
                string result = "";
                string error = "";
                SqlDataAdapter adap;
                DataSet ds = new DataSet();
                DataTable poTable = new DataTable();

                SqlConnection con = new SqlConnection();
                string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
                con.ConnectionString = connectionString;
                con.Open();

                    // cm_Details
                    adap = new SqlDataAdapter("SELECT SWCCspo2.ponumber, stocknumber, orderquantity, ItemQty, Delivered from SWCCSPO2 left outer join CM_Data on CM_Data.PONumber = LTRIM(SWCCSPO2.ponumber) and CM_Data.ItemNumber = SWCCSPO2.stocknumber left outer join CM_Details on CM_Details.CMID = CM_Data.CMID", con);
                    adap.Fill(ds, "po_Details");
                
                poTable = ds.Tables["po_Details"];
                string match;
                foreach (DataRow csvRow in csvTable.Rows)
                {
                    var csvItemQty = int.Parse(csvRow[2].ToString());                   
                    string keyPair = csvRow[0].ToString() + csvRow[1].ToString();
                    result = "";                              
                    foreach (DataRow poRows in poTable.Rows)
                    {
                        var poItemQty = Convert.ToInt32(poRows["orderquantity"]);
                        var delivered = poRows["Delivered"].ToString();
                        var onwaterQty = poRows["ItemQty"].ToString();
                        int subOnWaterQty;
                        if (delivered != "")
                        {
                            if (onwaterQty != "")
                            {
                                subOnWaterQty = Convert.ToInt32(poRows["ItemQty"]);
                            }
                            else
                            {
                                subOnWaterQty = 0;
                            }
                        }
                        else
                        {
                            subOnWaterQty = 0;
                        }
                        
                        match = poRows["ponumber"].ToString() + poRows["stocknumber"].ToString();
                        match = match.Replace(" ", string.Empty);
                        if (keyPair == match)
                        {
                            // check if item quanity shipped on the CSV is greater than the purchace order in Southware. 
                            if (csvItemQty > poItemQty + subOnWaterQty)
                            {
                                DialogResult messageboxResult = MessageBox.Show("CSV PO: " + csvRow[0] + "\nItem:" + csvRow[1] + "\n\nCSV qty: " + csvItemQty +"\nPO Quantity: " + poItemQty + ". \n\nWould you like to continue?", "Overshipment Found", MessageBoxButtons.YesNo);
                                if (messageboxResult == DialogResult.Yes)
                                {
                                    result = "found";
                                    break;
                                }
                                else if (messageboxResult == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            result = "found";
                            break;
                        }
                    }

                    if (result == "")
                    {
                        MessageBox.Show("Error: No PO / Item combo found in database for record: \nPO#" + csvRow[0] + "\nItem Number: " + csvRow[1]);
                        error = "found";
                        break;
                    }
                }

                if (error != "found")
                {
                    // declare sqlbulk copy object which will do the work of brining in data from csvdata reader object will update container details (cmdata)
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connectionString))
                    {
                        bulkcopy.DestinationTableName = "CM_Data";

                        bulkcopy.ColumnMappings.Add("CMID", "CMID");
                        bulkcopy.ColumnMappings.Add("PONumber", "PONumber");
                        bulkcopy.ColumnMappings.Add("ItemNumber", "ItemNumber");
                        bulkcopy.ColumnMappings.Add("ItemQty", "ItemQty");

                        bulkcopy.WriteToServer(csvTable);
                    }
                    // same thing but for CM details
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connectionString))
                    {
                        bulkcopy.DestinationTableName = "CM_Details";

                        bulkcopy.ColumnMappings.Add("CMID", "CMID");
                        bulkcopy.ColumnMappings.Add("Supplier", "Supplier");
                        bulkcopy.ColumnMappings.Add("ShipDate", "ShipDate");
                        bulkcopy.ColumnMappings.Add("ETADate", "ETADate");
                        bulkcopy.ColumnMappings.Add("ShipType", "ShipType");
                        bulkcopy.ColumnMappings.Add("ContainerQty", "ContainerQty");
                        bulkcopy.ColumnMappings.Add("ContainerNumber", "ContainerNumber");
                        bulkcopy.ColumnMappings.Add("Notes", "Notes");

                        bulkcopy.WriteToServer(cmDetails);
                    }
                    MessageBox.Show("New container added with " + counter + " records");
                    counter = 0;
                }                
            }
        }
    }
}
