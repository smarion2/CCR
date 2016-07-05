using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace CCR
{
    public partial class ContainerMasterReportForm : Form
    {
        public ContainerMasterReportForm()
        {
            InitializeComponent();
        }

        private void ContainerMasterReportForm_Load(object sender, EventArgs e)
        {
            ContainerMaster cm = new ContainerMaster();
            cm.CreateReport();

            //CreateReport();


            // TODO: This line of code loads data into the 'ContainerMasterDS.DataTable1' table. You can move, or remove it, as needed.
            //ContainerMasterDS.EnforceConstraints = false;
            //this.DataTable1TableAdapter.Fill(this.ContainerMasterDS.DataTable1);
            //DataTable dt = new DataTable();
            //dt = ContainerMasterDS.DataTable1;
            //Microsoft.Reporting.WinForms.ReportDataSource reportData = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt);

            //this.reportViewer1.LocalReport.DataSources.Add(reportData);
            //this.reportViewer1.RefreshReport();
        }

        private DataTable poTable;
        private DataTable cmDetailsTable;
        private DataTable balanceDueTable;
        private string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        //private Form prompt = new Form()
        //{
        //    Width = 500,
        //    Height = 150,
        //    FormBorderStyle = FormBorderStyle.FixedDialog,
        //    Text = "Creating Container Master",
        //    StartPosition = FormStartPosition.CenterScreen
        //};
        //private Label reportStatus = new Label() { Left = 50, Top = 20, Text = "Retriving Data from SQL server", Width = 200, AutoSize = true };
        //private ProgressBar progBar = new ProgressBar() { Left = 50, Top = 50, Width = 400 };

        public void CreateReport()
        {
            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    progressBar1.BeginInvoke(
                                new Action(() =>
                                {
                                    progressBar1.Style = ProgressBarStyle.Marquee;
                                }));

                    label1.BeginInvoke(
                                new Action(() =>
                                {
                                    label1.Text = "Creating Container Master";
                                }));

                    poTable = GetData.ExecuteQuery("EXEC ContainerMaster", connectionString);
                    cmDetailsTable = GetData.ExecuteQuery("select * from CM_Details where Delivered is null order by Supplier DESC, ETADate DESC", connectionString);
                    balanceDueTable = GetData.ExecuteQuery("select PONumber, ItemNumber, sum(ItemQty) from CM_Data a join CM_Details b on a.CMID = b.CMID where Delivered is null group by ItemNumber, PONumber", connectionString);


                    poTable.Columns.Add("Balance Due", typeof(int)).SetOrdinal(8);
                    int orderQuantity = 0;
                    int receivedQty = 0;
                    int canceledQty = 0;
                    int onWaterQty = 0;
                    int balanceDue = 0;
                    bool isOnWater = false;
                    for (int p = poTable.Rows.Count - 1; p > -1; p--)
                    {
                        string poKey = poTable.Rows[p][0].ToString() + poTable.Rows[p][1].ToString();
                        for (int c = 0; c < balanceDueTable.Rows.Count; c++)
                        {
                            string balanceKey = balanceDueTable.Rows[c][0].ToString() + balanceDueTable.Rows[c][1].ToString();

                            orderQuantity = Convert.ToInt32(poTable.Rows[p]["orderquantity"]);
                            receivedQty = Convert.ToInt32(poTable.Rows[p]["receivedtodateqty"]);
                            canceledQty = Convert.ToInt32(poTable.Rows[p]["cancelledqty"]);

                            if (poKey == balanceKey)
                            {
                                onWaterQty = Convert.ToInt32(balanceDueTable.Rows[c][2]);
                                balanceDue = orderQuantity - receivedQty - canceledQty - onWaterQty;
                                poTable.Rows[p][8] = balanceDue;
                                isOnWater = true;

                                label1.BeginInvoke(
                                    new Action(() =>
                                    {
                                        label1.Text = "Calculating Balance Due: " + orderQuantity + " - " + receivedQty + " - " + canceledQty + " - " + onWaterQty + " = " + balanceDue;
                                    }));

                                break;
                            }
                        }
                        if (isOnWater == false)
                        {
                            balanceDue = orderQuantity - receivedQty - canceledQty;
                            if (balanceDue > 0)
                                poTable.Rows[p][8] = balanceDue;
                            else
                            {
                                label1.BeginInvoke(
                                        new Action(() =>
                                        {
                                            label1.Text = "Deleting row, line completely recieved";
                                        }));
                                poTable.Rows.Remove(poTable.Rows[p]);
                            }
                        }
                        else
                            isOnWater = false;
                    }
                    poTable.Columns.Remove("orderquantity");
                    poTable.Columns.Remove("receivedtodateqty");
                    poTable.Columns.Remove("cancelledqty");

                    int containerCount = 0;
                    foreach (DataRow row in cmDetailsTable.Rows)
                    {
                        containerCount++;
                        label1.BeginInvoke(
                            new Action(() =>
                            {
                                label1.Text = "Creating Container: " + containerCount + " of " + cmDetailsTable.Rows.Count;
                            }));

                        int columnPos = 9;
                        // create container
                        string cmID = row["CMID"].ToString();
                        poTable.Columns.Add("\"Supplier: " + row["Supplier"] + "\r\n" +
                                                "ETA: " + row["ETADate"] + "\r\n" +
                                                "Shipped: " + row["ShipDate"] + "\r\n" +
                                                "Cartons: " + row["ContainerQty"] + "\r\n" +
                                                "Delivery Mode: " + row["ShipType"] + "\r\n" +
                                                "Container number: " + row["ContainerNumber"] + "\"").SetOrdinal(columnPos);
                        System.Data.DataTable containerDeets = GetData.ExecuteQuery("select PONumber, ItemNumber, sum(itemqty) as ItemQty from CM_Data a join CM_Details b on a.CMID = b.CMID where b.CMID = @0 group by PONumber, ItemNumber", connectionString, cmID);
                        // fill container with data                    
                        for (int c = 0; c < containerDeets.Rows.Count; c++)
                        {
                            for (int b = 0; b < poTable.Rows.Count; b++)
                            {
                                string containerItem = containerDeets.Rows[c][0].ToString() + containerDeets.Rows[c][1].ToString();
                                string poItem = poTable.Rows[b][0].ToString() + poTable.Rows[b][1];
                                if (containerItem == poItem)
                                {
                                    poTable.Rows[b][columnPos] = containerDeets.Rows[c][2];
                                }
                            }
                        }
                        columnPos++;
                    }
                    label1.BeginInvoke(
                        new Action(() =>
                        {
                            label1.Text = "Creating Excel Document";
                        }));
                    DataTableToExcel.ExportToExcel(poTable);
                    this.Invoke((MethodInvoker)delegate
                    {
                       this.Close();
                    });             
                }));
            backgroundThread.Start();
        }

    }


}

