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
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Diagnostics;

namespace CCR
{
    public partial class BuyReportForm : Form
    {
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        string location = string.Empty;

        public BuyReportForm()
        {
            InitializeComponent();
        }

        public void BuyReportForm_Load(object sender, EventArgs e)
        {
            
        }


        private void runReportButton_Click_1(object sender, EventArgs e)
        {
            System.Data.DataTable buyReportDT = new System.Data.DataTable();
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "CSV | *.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = Path.GetFullPath(fileDialog.FileName);

                progressLabel.BeginInvoke(
                            new Action(() =>
                            {
                                progressLabel.Visible = true;
                                progressLabel.Text = "Creating BuyReport";
                            }));
                progressBar1.BeginInvoke(
                            new Action(() =>
                            {
                                progressBar1.Style = ProgressBarStyle.Marquee;
                                progressBar1.Visible = true;
                            }));

                Thread backgroundThread = new Thread(
                    new ThreadStart(() =>
                {
                        // get location number for report
                        if (radioButton800.Checked == true)
                        {
                            location = "800";
                        }
                        else if (radioButton900.Checked == true)
                        {
                            location = "900";
                        }
                        // doesnt work yet. 
                        //else if (radioButtonBoth.Checked == true)
                        //{
                        //    location = "'900','800'";
                        //}

                        // check if user ran report with any filters
                        ReportFilters.ItemFilter(ItemFilter.Text, location);
                        ReportFilters.VendorFilter(vendorFilters.Text, location);
                        ReportFilters.CatFilter(catFilters.Text, location);

                        // start building containers on the report
                        try
                        {
                            //containerDT = GetData.ExecuteQuery("select * from CM_Details where Delivered is null order by Supplier, ETADate", connectionString);
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("BuyReportTest", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@location", location);
                                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                                adapt.Fill(buyReportDT);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to retrive Buy Report Data system is busy or sync is down. \r\n Please wait and try again soon. " + ex.ToString(), "Error!", MessageBoxButtons.OK);
                            ErrorLogger.LogError("Failed Getting Data for buy Report", ex.ToString());
                            return;
                        }

                        if (expediteCB.Checked == true)
                        {
                            buyReportDT.Columns.Remove("Minimum Order Quantity");
                            buyReportDT.Columns.Remove("itemNotes");
                            buyReportDT.Columns.Remove("Buy Notes");
                            buyReportDT.Columns.Remove("Approver Notes");
                            buyReportDT.Columns.Remove("Total OTW");
                            buyReportDT.Columns.Add("Item Notes");
                            buyReportDT.Columns.Add("Total Weekly Need");
                            buyReportDT.Columns.Add("Additional amount needed to cover additional forecasted need rollout & back up");
                            buyReportDT.Columns.Add("WOS OH (Net)");
                            buyReportDT.Columns.Add("WOS OH (Net) - Additional amount needed");
                            buyReportDT.Columns.Add("WOS OH (Net) & OTW");
                            buyReportDT.Columns.Add("WOS OH (Net) & OTW - Additional amount needed");
                            buyReportDT.Columns.Add("Quantities Already on FedEx Request");
                            buyReportDT.Columns.Add("FedEx Need");
                            buyReportDT.Columns.Add("Rounded");
                            buyReportDT.Columns.Add("Suggested FedEx Quantity at CCAs Expense");
                            buyReportDT.Columns.Add("Suggested FedEx Quantity at Vendor's Expense");
                            buyReportDT.Columns.Add("FedEx Cheat Sheet Check - Does it make sense to fly?");
                            buyReportDT.Columns.Add("Number of Cases");
                            buyReportDT.Columns.Add("FedEx Notes");
                            buyReportDT.Columns.Add("Approver Notes");
                            buyReportDT.Columns.Add("Number of Weeks to Expedite");
                            buyReportDT.Columns.Add("Priority ");
                            buyReportDT.Columns.Add("Rounded ");
                            buyReportDT.Columns.Add("Check");
                            buyReportDT.Columns.Add("FINAL PRIORITY");
                            buyReportDT.Columns.Add("Priority for next container");
                            buyReportDT.Columns.Add("Rounded   ");
                            buyReportDT.Columns.Add("Check ");
                            buyReportDT.Columns.Add("Quantity Needed on next container");
                            buyReportDT.Columns.Add("Next PO Due to ship");
                            buyReportDT.Columns.Add("Required Ship Date");
                            buyReportDT.Columns.Add("Date Ordered");
                            buyReportDT.Columns.Add("Balance Due");
                            buyReportDT.Columns.Add("Number of Days on Order (not including CNY)");
                            buyReportDT.Columns.Add("Notes for Vendor");
                            buyReportDT.Columns.Add("Container Notes");
                            buyReportDT.Columns.Add("Approver Notes ");
                            buyReportDT.Columns.Add("Total OTW");
                        }



                        // fill form with formulas                
                        for (int r = 0; r < buyReportDT.Rows.Count; r++)
                        {
                            progressLabel.BeginInvoke(
                                new Action(() =>
                                {
                                    progressLabel.Text = "Creating and adding formula to row: " + r + " of " + buyReportDT.Rows.Count.ToString();
                                }));
                            for (int c = 0; c < buyReportDT.Columns.Count; c++)
                            {
                                if (c + 1 == 5)
                                {
                                    buyReportDT.Rows[r][c] = "=G" + (r + 2) + "+" + "H" + (r + 2) + "-" + "I" + (r + 2);
                                }
                                if (c + 1 == 6)
                                {
                                    buyReportDT.Rows[r][c] = "=G" + (r + 2) + "-" + "I" + (r + 2);
                                }
                                if (c + 1 == 11)
                                {
                                    double total = 0;
                                    for (int i = 12; i <= 17; i++)
                                    {
                                        if (buyReportDT.Rows[r][i] != DBNull.Value)
                                        {
                                            total += Convert.ToDouble(buyReportDT.Rows[r][i]);
                                        }
                                    }
                                    buyReportDT.Rows[r][c] = Math.Round(total / 6);
                                }
                                if (c + 1 == 31)
                                {
                                    buyReportDT.Rows[r][c] = "\"=W" + (r + 2) + "*IF(V" + (r + 2) + "=\"\"\"\",U" + (r + 2) + ",V" + (r + 2) + ")*CB" + (r + 2) + "\"";
                                }
                                if (c + 1 == 43)
                                {
                                    buyReportDT.Rows[r][c] = "\"=AI" + (r + 2) + "*IF(AH" + (r + 2) + "=\"\"\"\",AG" + (r + 2) + ",AH" + (r + 2) + ")*CB" + (r + 2) + "\"";
                                }
                                if (c + 1 == 55)
                                {
                                    buyReportDT.Rows[r][c] = "\"=AU" + (r + 2) + "*IF(AT" + (r + 2) + "=\"\"\"\",AS" + (r + 2) + ",AT" + (r + 2) + ")*CB" + (r + 2) + "\"";
                                }
                                if (c + 1 == 67)
                                {
                                    buyReportDT.Rows[r][c] = "\"=BG" + (r + 2) + "*IF(BF" + (r + 2) + "=\"\"\"\",BE" + (r + 2) + ",BF" + (r + 2) + ")*CB" + (r + 2) + "\"";
                                }
                                if (c + 1 == 79)
                                {
                                    buyReportDT.Rows[r][c] = "\"=BS" + (r + 2) + "*IF(BR" + (r + 2) + "=\"\"\"\",BQ" + (r + 2) + ",BR" + (r + 2) + ")*CB" + (r + 2) + "\"";
                                }
                                if (c + 1 == 81)
                                {
                                    buyReportDT.Rows[r][c] = "\"= (IF(J" + (r + 2) + "=\"\"\"\",K" + (r + 2) + ",J" + (r + 2) + ")*(CB" + (r + 2) + "/4.3)+IF(Y" + (r + 2) + "<=TODAY(),0,Z" + (r + 2) +
                                        ")+IF(AA" + (r + 2) + "<=TODAY(),0,AB" + (r + 2) + ")+AC" + (r + 2) + "+ X" + (r + 2) + "+IF(AK" + (r + 2) + "<= TODAY(), 0, AL" + (r + 2) + ") + IF(AM" + (r + 2) +
                                        "<= TODAY(), 0, AN" + (r + 2) + ") + AO" + (r + 2) + "+AJ" + (r + 2) + "+IF(AW" + (r + 2) + "<= TODAY(), 0, AX" + (r + 2) + ") + IF(AY" + (r + 2) + " <= TODAY(),0,AZ" + (r + 2) +
                                        ") + BA" + (r + 2) + "+AV" + (r + 2) + "+IF(BI" + (r + 2) + " <= TODAY(), 0, BJ" + (r + 2) + ") + IF(BK" + (r + 2) + " <= TODAY(), 0, BL" + (r + 2) + ") + BM" + (r + 2) + " + BH" + (r + 2) +
                                        "+IF(BU" + (r + 2) + " <= TODAY(),0,BV" + (r + 2) + ") + IF(BW" + (r + 2) + " <= TODAY(),0,BX" + (r + 2) + ")+BY" + (r + 2) + "+BT" + (r + 2) + ")-E" + (r + 2) + "\"";
                                }
                                if (c + 1 == 82)
                                {
                                    buyReportDT.Rows[r][c] = "\"=IF(CC" + (r + 2) + ">0,ROUNDUP((CC" + (r + 2) + "/S" + (r + 2) + "),0)*S" + (r + 2) + ",0)\"";
                                }
                                if (c + 1 == 85)
                                {
                                    buyReportDT.Rows[r][c] = "\"=IFERROR((E" + (r + 2) + "-IF(Y" + (r + 2) + "<=TODAY(),0,Z" + (r + 2) + ")-IF(AA" + (r + 2) + "<=TODAY(),0,AB" + (r + 2) + ")-AC" + (r + 2) +
                                        "-IF(AK" + (r + 2) + "<=TODAY(),0,AL" + (r + 2) + ")-IF(AM" + (r + 2) + "<=TODAY(),0,AN" + (r + 2) + ")-AO" + (r + 2) + "-IF(AW" + (r + 2) + "<=TODAY(),0,AX" + (r + 2) +
                                        ")-IF(AY" + (r + 2) + "<=TODAY(),0,AZ" + (r + 2) + ")-BA" + (r + 2) + "-IF(BI" + (r + 2) + "<=TODAY(),0,BJ" + (r + 2) + ")-IF(BK" + (r + 2) + "<=TODAY(),0,BL" + (r + 2) +
                                        ")-BM" + (r + 2) + "-IF(BU" + (r + 2) + "<=TODAY(),0,BV" + (r + 2) + ")-IF(BW" + (r + 2) + "<=TODAY(),0,BX" + (r + 2) + ")-BY" + (r + 2) + ")/(IF(J" + (r + 2) +
                                        "=0,K" + (r + 2) + ",J" + (r + 2) + ")/4.3),\"\"\"\")\"";
                                }
                                if (c + 1 == 86)
                                {
                                    buyReportDT.Rows[r][c] = "\"=IFERROR((E" + (r + 2) + "+ IF(CF" + (r + 2) + "=\"\"\"\", CE" + (r + 2) + ",CF" + (r + 2) + ")-IF(Y" + (r + 2) + "<=TODAY(),0,Z" + (r + 2) +
                                        ")-IF(AA" + (r + 2) + "<= TODAY(),0,AB" + (r + 2) + ")-AC" + (r + 2) + "-IF(AK" + (r + 2) + "<=TODAY(),0,AL" + (r + 2) + ")-IF(AM" + (r + 2) + "<=TODAY(),0,AN" + (r + 2) +
                                        ")-AO" + (r + 2) + "-IF(AW" + (r + 2) + "<=TODAY(), 0, AX" + (r + 2) + ")-IF(AY" + (r + 2) + "<= TODAY(),0,AZ" + (r + 2) + ")-BA" + (r + 2) + "-IF(BI" + (r + 2) + "<= TODAY(), 0, BJ" + (r + 2) +
                                        ")-IF(BK" + (r + 2) + "<= TODAY(), 0, BL" + (r + 2) + ") - BM" + (r + 2) + "-IF(BU" + (r + 2) + " <= TODAY(),0,BV" + (r + 2) + ")-IF(BW" + (r + 2) + "<=TODAY(),0,BX" + (r + 2) +
                                        ")-BY" + (r + 2) + ")/(IF(J" + (r + 2) + "=0,K" + (r + 2) + ",J" + (r + 2) + ")/4.3),\"\"\"\")\"";
                                }
                                if (c + 1 == 87)
                                {
                                    buyReportDT.Rows[r][c] = "\"=IFERROR((E" + (r + 2) + "+IF(CF" + (r + 2) + "=\"\"\"\",CE" + (r + 2) + ",CF" + (r + 2) + ")-IF(Y" + (r + 2) + "<=TODAY(),0,Z" + (r + 2) +
                                        ")-IF(AA" + (r + 2) + "<=TODAY(),0,AB" + (r + 2) + ")-IF(AK" + (r + 2) + "<=TODAY(),0,AL" + (r + 2) + ")-IF(AM" + (r + 2) + "<=TODAY(),0,AN" + (r + 2) + ")-IF(AW" + (r + 2) + "<=TODAY(),0,AX" + (r + 2) +
                                        ")-IF(AY" + (r + 2) + "<=TODAY(),0,AZ" + (r + 2) + ")-IF(BI" + (r + 2) + "<=TODAY(),0,BJ" + (r + 2) + ")-IF(BK" + (r + 2) + "<=TODAY(),0,BL" + (r + 2) + ")-IF(BU" + (r + 2) + "<=TODAY(),0,BV" + (r + 2) +
                                        ")-IF(BW" + (r + 2) + "<=TODAY(),0,BX" + (r + 2) + "))/(IF(J" + (r + 2) + "=0,K" + (r + 2) + ",J" + (r + 2) + ")/4.3),\"\"\"\")\"";
                                }
                                if (c + 1 == 88)
                                {
                                    buyReportDT.Rows[r][c] = "\"=IFERROR((E" + (r + 2) + "+IF(CF" + (r + 2) + "=\"\"\"\",CE" + (r + 2) + ",CF" + (r + 2) + ")-IF(Y" + (r + 2) + "<=TODAY(),0,Z" + (r + 2) +
                                        ")-IF(AA" + (r + 2) + "<=TODAY(),0,AB" + (r + 2) + ")-AC" + (r + 2) + "-IF(AK" + (r + 2) + "<=TODAY(),0,AL" + (r + 2) + ")-IF(AM" + (r + 2) + "<=TODAY(),0,AN" + (r + 2) +
                                        ")-AO" + (r + 2) + "-IF(AW" + (r + 2) + "<=TODAY(),0,AX" + (r + 2) + ")-IF(AY" + (r + 2) + "<=TODAY(),0,AZ" + (r + 2) + ")-BA" + (r + 2) + "-IF(BI" + (r + 2) + "<=TODAY(),0,BJ" + (r + 2) +
                                        ")-IF(BK" + (r + 2) + "<=TODAY(),0,BL" + (r + 2) + ")-BM" + (r + 2) + "-IF(BU" + (r + 2) + "<=TODAY(),0,BV" + (r + 2) + ")-IF(BW" + (r + 2) + "<=TODAY(),0,BX" + (r + 2) +
                                        ")-BY" + (r + 2) + ")/(IF(V" + (r + 2) + "=\"\"\"\",U" + (r + 2) + ",V" + (r + 2) + ")*W" + (r + 2) + "+IF(AH" + (r + 2) + "=\"\"\"\",AG" + (r + 2) + ",AH" + (r + 2) +
                                        ")*AI" + (r + 2) + "+IF(AT" + (r + 2) + "=\"\"\"\",AS" + (r + 2) + ",AT" + (r + 2) + ")*AU" + (r + 2) + "+IF(BF" + (r + 2) + "=\"\"\"\",BE" + (r + 2) + ",BF" + (r + 2) +
                                        ")*BG" + (r + 2) + "+IF(BR" + (r + 2) + "=\"\"\"\",BQ" + (r + 2) + ",BR" + (r + 2) + ")*BS" + (r + 2) + "),\"\"\"\")\"";
                                }
                                if (c + 1 == 89)
                                {
                                    buyReportDT.Rows[r][c] = "\"=IFERROR((E" + (r + 2) + "+IF(CF" + (r + 2) + "=\"\"\"\",CE" + (r + 2) + ",CF" + (r + 2) + ")-IF(Y" + (r + 2) + "<=TODAY(),0,Z" + (r + 2) +
                                        ")-IF(AA" + (r + 2) + "<=TODAY(),0,AB" + (r + 2) + ")-IF(AK" + (r + 2) + "<=TODAY(),0,AL" + (r + 2) + ")-IF(AM" + (r + 2) + "<=TODAY(),0,AN" + (r + 2) + ")-IF(AW" + (r + 2) +
                                        "<=TODAY(),0,AX" + (r + 2) + ")-IF(AY" + (r + 2) + "<=TODAY(),0,AZ" + (r + 2) + ")-IF(BI" + (r + 2) + "<=TODAY(),0,BJ" + (r + 2) + ")-IF(BK" + (r + 2) + "<=TODAY(),0,BL" + (r + 2) +
                                        ")-IF(BU" + (r + 2) + "<=TODAY(),0,BV" + (r + 2) + ")-IF(BW" + (r + 2) + "<=TODAY(),0,BX" + (r + 2) + "))/(IF(V" + (r + 2) + "=\"\"\"\",U" + (r + 2) + ",V" + (r + 2) + ")*W" + (r + 2) +
                                        "+IF(AH" + (r + 2) + "=\"\"\"\",AG" + (r + 2) + ",AH" + (r + 2) + ")*AI" + (r + 2) + "+IF(AT" + (r + 2) + "=\"\"\"\",AS" + (r + 2) + ",AT" + (r + 2) + ")*AU" + (r + 2) + "+IF(BF" + (r + 2)
                                        + "=\"\"\"\",BE" + (r + 2) + ",BF" + (r + 2) + ")*BG" + (r + 2) + "+IF(BR" + (r + 2) + "=\"\"\"\",BQ" + (r + 2) + ",BR" + (r + 2) + ")*BS" + (r + 2) + "),\"\"\"\")\"";
                                }
                                // this column moves to this left 1 over if expedite report is ran
                                if (expediteCB.Checked ? c + 1 == 90 : c + 1 == 91)
                                {
                                    string crazyFormula = "\"=IFERROR(IF(CF" + (r + 2) + "=\"\"\"\",CE" + (r + 2) + ",CF" + (r + 2) + ")/(IF(J" + (r + 2) + "=0,K" + (r + 2) + ",J" + (r + 2) +
                                        ")/4.3),IF(CF" + (r + 2) + "=\"\"\"\",CE" + (r + 2) + ",CF" + (r + 2) + ")/(IF(V" + (r + 2) + "=\"\"\"\",U" + (r + 2) + ",V" + (r + 2) + ")*W" + (r + 2) + "+IF(AH" + (r + 2) +
                                        "=\"\"\"\",AG" + (r + 2) + ",AH" + (r + 2) + ")*AI" + (r + 2) + "+IF(AT" + (r + 2) + "=\"\"\"\",AS" + (r + 2) + ",AT" + (r + 2) + ")*AU" + (r + 2) + "+IF(BF" + (r + 2) +
                                        "=\"\"\"\",BE" + (r + 2) + ",BF" + (r + 2) + ")*BG" + (r + 2) + "+IF(BR" + (r + 2) + "=\"\"\"\",BQ" + (r + 2) + ",BR" + (r + 2) + ")*BS" + (r + 2) + "))\"";
                                    buyReportDT.Rows[r][c] = crazyFormula;
                                }

                                // populate expedite formulas
                                if (expediteCB.Checked == true)
                                {
                                    if (c + 1 == 92)
                                    {
                                        buyReportDT.Rows[r][c] = "=J" + (r + 2) + "/4.3";
                                    }
                                    if (c + 1 == 93)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(Y" + (r + 2) + "<=TODAY(),0,Z" + (r + 2) + ")+IF(AA" + (r + 2) + "<=TODAY(),0,AB" + (r + 2) + ")+AC" + (r + 2) + "+X" + (r + 2) + "+IF(AK" + (r + 2) +
                                            "<=TODAY(),0,AL" + (r + 2) + ")+IF(AM" + (r + 2) + "<=TODAY(),0,AN" + (r + 2) + ")+AO" + (r + 2) + "+AJ" + (r + 2) + "+IF(AW" + (r + 2) + "<=TODAY(),0,AX" + (r + 2) + ")+IF(AY" + (r + 2) +
                                            "<=TODAY(),0,AZ" + (r + 2) + ")+BA" + (r + 2) + "+AV" + (r + 2) + "+IF(BI" + (r + 2) + "<=TODAY(),0,BJ" + (r + 2) + ")+IF(BK" + (r + 2) + "<=TODAY(),0,BL" + (r + 2) + ")+BM" + (r + 2) +
                                            "+BH" + (r + 2) + "+IF(BU" + (r + 2) + "<=TODAY(),0,BV" + (r + 2) + ")+IF(BW" + (r + 2) + "<=TODAY(),0,BX" + (r + 2) + ")+BY" + (r + 2) + "+BT" + (r + 2) + "\"";
                                    }
                                    if (c + 1 == 94)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IFERROR(F" + (r + 2) + " / CN" + (r + 2) + ", \"\"\"\")\"";
                                    }
                                    if (c + 1 == 95)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IFERROR((F" + (r + 2) + " - CO" + (r + 2) + ") / CN" + (r + 2) + ", \"\"\"\")\"";
                                    }
                                    if (c + 1 == 96)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IFERROR((F" + (r + 2) + "+DT" + (r + 2) + ")/CN" + (r + 2) + ",\"\"\"\")\"";
                                    }
                                    if (c + 1 == 97)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IFERROR((F" + (r + 2) + "-CO" + (r + 2) + "+DT" + (r + 2) + ")/CN" + (r + 2) + ",\"\"\"\")\"";
                                    }
                                    if (c + 1 == 99)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(J" + (r + 2) + ">0,IF(CS" + (r + 2) + "<6,IF((6-CS" + (r + 2) + ")*CN" + (r + 2) + "-CT" + (r + 2) + ">0,(6-CS" + (r + 2) + ")*CN" + (r + 2) + "-CT" + (r + 2) +
                                        ",0),0),IF(OR(AND(Y" + (r + 2) + "-TODAY()>0,Y" + (r + 2) + "-TODAY()<42), AND(AA" + (r + 2) + "-TODAY()>0,AA" + (r + 2) + "-TODAY()<42), AND(AK" + (r + 2) + "-TODAY()>0,AK" + (r + 2) + "-TODAY()<42), AND(AM" + (r + 2) +
                                        "-TODAY()>0,AM" + (r + 2) + "-TODAY()<42), AND(AW" + (r + 2) + "-TODAY()>0,AW" + (r + 2) + "-TODAY()<42), AND(AY" + (r + 2) + "-TODAY()>0,AY" + (r + 2) + "-TODAY()<42), AND(BI" + (r + 2) + "-TODAY()>0,BI" + (r + 2) +
                                        "-TODAY()<42),AND(BK" + (r + 2) + "-TODAY()>0,BK" + (r + 2) + "-TODAY()<42),AND(BU" + (r + 2) + "-TODAY()>0,BU" + (r + 2) + "-TODAY()<42),AND(BW" + (r + 2) + "-TODAY()>0,BW" + (r + 2) + "-TODAY()<42)),CO" + (r + 2) +
                                        "-F" + (r + 2) + "-DT" + (r + 2) + "-CT" + (r + 2) + ",0))\"";
                                    }
                                    if (c + 1 == 100)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(CU" + (r + 2) + ">0,ROUNDUP(CU" + (r + 2) + "/S" + (r + 2) + ",0)*S" + (r + 2) + ",0)\"";
                                    }
                                    if (c + 1 == 103)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(FF" + (r + 2) + "=TRUE,IF(FC" + (r + 2) + ">0,\"\"YES\"\",IF(FE" + (r + 2) + ">0,\"\"YES\"\",\"\"NO\"\")),\"\"MISSING INFO\"\")\"";
                                    }
                                    if (c + 1 == 104)
                                    {
                                        buyReportDT.Rows[r][c] = "=(CW" + (r + 2) + "+CX" + (r + 2) + ")/S" + (r + 2);
                                    }
                                    if (c + 1 == 108)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(J" + (r + 2) + ">0,(DC" + (r + 2) + "-CS" + (r + 2) + ")*CN" + (r + 2) + "-CT" + (r + 2) + "-CW" + (r + 2) + "-CX" + (r + 2) + ",CO" + (r + 2) + "-F" + (r + 2) + "-DT" + (r + 2) + "-CW" + (r + 2) + "-CX" + (r + 2) + "-CT" + (r + 2) + ")\"";
                                    }
                                    if (c + 1 == 109)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(DD" + (r + 2) + ">0,ROUNDUP(DD" + (r + 2) + "/S" + (r + 2) + ",0)*S" + (r + 2) + ",0)\"";
                                    }
                                    if (c + 1 == 110)
                                    {
                                        buyReportDT.Rows[r][c] = "=H" + (r + 2) + "-DT" + (r + 2) + "-DE" + (r + 2) + "";
                                    }
                                    if (c + 1 == 111)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(DF" + (r + 2) + ">0,DE" + (r + 2) + ",DF" + (r + 2) + "+DE" + (r + 2) + ")\"";
                                    }
                                    if (c + 1 == 112)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(CS" + (r + 2) + "=\"\"\"\",IF(OR(AND(Y" + (r + 2) + "-TODAY()>0,Y" + (r + 2) + "-TODAY()<56),AND(AA" + (r + 2) + "-TODAY()>0,AA" + (r + 2) + "-TODAY()<56), AND(AK" + (r + 2) + "-TODAY()>0,AK" + (r + 2) + "-TODAY()<56),AND(AM" + (r + 2) +
                                        "-TODAY()>0,AM" + (r + 2) + "-TODAY()<56),AND(AW" + (r + 2) + "-TODAY()>0,AW" + (r + 2) + "-TODAY()<56),AND(AY" + (r + 2) + "-TODAY()>0,AY" + (r + 2) + "-TODAY()<56), AND(BI" + (r + 2) + "-TODAY()>0,BI" + (r + 2) + "-TODAY()<56),AND(BK" + (r + 2) + "-TODAY()>0,BK" + (r + 2) +
                                        "-TODAY()<56),AND(BU" + (r + 2) + "-TODAY()>0,BU" + (r + 2) + "-TODAY()<56),AND(BW" + (r + 2) + "-TODAY()>0,BW" + (r + 2) + "-TODAY()<56)),CO" + (r + 2) + "-F" + (r + 2) + "-DT" + (r + 2) + "-CT" + (r + 2) + "-CW" + (r + 2) + "-CX" + (r + 2) + ",0),(8-CS" + (r + 2) + ")*CN" + (r + 2) +
                                        "-CT" + (r + 2) + "-CW" + (r + 2) + "-CX" + (r + 2) + ")\"";
                                    }
                                    if (c + 1 == 113)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(DH" + (r + 2) + ">0,ROUNDUP(DH" + (r + 2) + "/S" + (r + 2) + ",0)*S" + (r + 2) + ",0)\"";
                                    }
                                    if (c + 1 == 114)
                                    {
                                        buyReportDT.Rows[r][c] = "=H" + (r + 2) + "-DT" + (r + 2) + "-DI" + (r + 2) + "";
                                    }
                                    if (c + 1 == 115)
                                    {
                                        buyReportDT.Rows[r][c] = "\"=IF(DJ" + (r + 2) + ">0,DI" + (r + 2) + ",DJ" + (r + 2) + "+DI" + (r + 2) + ")\"";
                                    }
                                    if (c + 1 == 120)
                                    {
                                        buyReportDT.Rows[r][c] = "=TODAY()-DN" + (r + 2) + "";
                                    }
                                }
                            }
                        }

                        progressLabel.BeginInvoke(
                                    new Action(() =>
                                    {
                                        progressLabel.Visible = true;
                                        progressLabel.Text = "Creating Containers";
                                    }));

                        CreateContainer containers = new CreateContainer();
                        containers.AddToDataTable(buyReportDT, buyReportDT.Columns.Count);
                        List<Container> containerList = new List<Container>();
                        containerList = containers.GetContainerList();
                    //AddContainer.ToDataTable(buyReportDT);

                    int rowIndex = 2;
                    foreach(DataRow row in buyReportDT.Rows)
                    {
                        if (expediteCB.Checked == false)
                        {
                            row[94] = "=SUM(CR" + rowIndex + ":" + GetColumnName(buyReportDT.Columns.Count - 1) + rowIndex + ")";
                        }
                        rowIndex++;
                    }

                    // write data to csv
                    StringBuilder sb = new StringBuilder();

                    IEnumerable<string> columnNames = buyReportDT.Columns.Cast<DataColumn>().
                                                      Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(",", columnNames));

                    foreach (DataRow row in buyReportDT.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                        sb.AppendLine(string.Join(",", fields));
                    }

                    progressLabel.BeginInvoke(
                        new Action(() =>
                        {
                            progressLabel.Text = "Creating Excel file";
                        }));
                    
                    File.WriteAllText(filepath, sb.ToString());
                    // open csv in Excel
                    Excel.Application excelApp = new Excel.Application();
                    Object missing = System.Reflection.Missing.Value;
                    excelApp.Workbooks.OpenText(filepath,
                                                missing, 3,
                                                Excel.XlTextParsingType.xlDelimited,
                                                Excel.XlTextQualifier.xlTextQualifierNone,
                                                missing, missing, missing, true, missing, missing, missing,
                                                missing, missing, missing, missing, missing, missing);

                    Excel._Worksheet workSheet = excelApp.ActiveSheet;
                    excelApp.ReferenceStyle = Excel.XlReferenceStyle.xlA1;
                    //excelApp.Visible = true;

                    // format work sheet
                    workSheet.Range["1:1"].Orientation = 90;
                    workSheet.Range["1:1"].RowHeight = 150;
                    workSheet.Range["1:1"].WrapText = true;
                    workSheet.Range["G1:I" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(186, 220, 232));
                    workSheet.Range["J1:J" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(146, 208, 80));
                    workSheet.Range["K1:K" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(184, 204, 228));
                    workSheet.Range["T1:AE" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(235, 241, 222));
                    workSheet.Range["AF1:AQ" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(184, 204, 228));
                    workSheet.Range["AR1:BC" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(228, 223, 236));
                    workSheet.Range["BD1:BO" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(218, 238, 243));
                    workSheet.Range["BP1:CA" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(242, 220, 219));
                    workSheet.Range["CB1:CB" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(146, 208, 80));
                    workSheet.Range["CE1:CE" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(146, 208, 80));
                    workSheet.Range["CF1:CF" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(255, 255, 0));
                    workSheet.Range["W:W"].NumberFormat = "0.00";
                    workSheet.Range["Y:Y"].NumberFormat = "MM/DD/YYYY";
                    //workSheet.Range["A:A"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["AD:AD"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["AI:AI"].NumberFormat = "0.00";
                    workSheet.Range["AK:AK"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["AM:AM"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["AP:AP"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["AU:AU"].NumberFormat = "0.00";
                    workSheet.Range["AW:AW"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["AY:AY"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["BB:BB"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["BG:BG"].NumberFormat = "0.00";
                    workSheet.Range["BI:BI"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["BK:BK"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["BN:BN"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["BS:BS"].NumberFormat = "0.00";
                    workSheet.Range["BU:BU"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["BW:BW"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["BZ:BZ"].NumberFormat = "MM/DD/YYYY";
                    workSheet.Range["CG:CG"].NumberFormat = "0";
                    workSheet.Range["CH:CH"].NumberFormat = "0";
                    workSheet.Range["CI:CI"].NumberFormat = "0";
                    workSheet.Range["CJ:CJ"].NumberFormat = "0";
                    workSheet.Range["CK:CK"].NumberFormat = "0";
                    workSheet.Range["CL:CL"].NumberFormat = "0";
                    workSheet.Range["CM:CM"].NumberFormat = "0.0";

                    int columnToColor = 95;
                    foreach(Container container in containerList)
                    {
                        workSheet.Range[GetColumnName(columnToColor) + "1"].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(container.RGBcolor[0], container.RGBcolor[1], container.RGBcolor[2]));
                        columnToColor++;
                    }

                    if (expediteCB.Checked == true)
                    {
                        workSheet.Range["CW1:CX" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(255, 192, 0));
                        workSheet.Range["DG1:DG" + (buyReportDT.Rows.Count + 1)].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(0, 176, 240));
                    }

                    // TODO get font type and bold to work the following code does not work.
                    excelApp.StandardFont = "Arial";
                    excelApp.StandardFontSize = 8;
                    workSheet.Columns.AutoFit();
                    //Path.ChangeExtension(filepath, ".xlsx");
                    string replace = Path.GetFileName(fileDialog.FileName).Replace(".csv", ".xlsx");
                    string path = Path.GetDirectoryName(fileDialog.FileName) + "\\" + replace;
                    workSheet.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    excelApp.Workbooks.Open(path);
                    excelApp.Visible = true;
                    //excelApp.Quit();
                    File.Delete(filepath);
                    progressLabel.BeginInvoke(
                            new Action(() =>
                            {
                                progressLabel.Visible = false;
                            }));
                    progressBar1.BeginInvoke(
                            new Action(() =>
                            {
                                progressBar1.Visible = false;
                            }));
                }));
                backgroundThread.Start();
            }
        }

        public string GetColumnName(int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }


        private void updateCustomerCodesButtons_Click_1(object sender, EventArgs e)
        {
            System.Data.DataTable csvTable = new System.Data.DataTable("BuyReportData");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath);

                // Create Data table to hold buyreportdata
                System.Data.DataTable buyData = new System.Data.DataTable("buyData");
                buyData.Columns.Add("stocknumber", typeof(string));
                // Michaels
                buyData.Columns.Add("michaelsCode", typeof(string));
                buyData.Columns.Add("michaelsCurrentStoreCount", typeof(float));
                buyData.Columns.Add("michaelsFutureStoreCount", typeof(float));
                buyData.Columns.Add("michaelsROS", typeof(float));
                buyData.Columns.Add("michaelsROSoverride", typeof(float));
                buyData.Columns.Add("michaelsRolloutDate", typeof(DateTime));
                buyData.Columns.Add("michaelsRolloutAmount", typeof(float));
                buyData.Columns.Add("michaelsRolloutDate2", typeof(DateTime));
                buyData.Columns.Add("michaelsRolloutAmount2", typeof(float));
                buyData.Columns.Add("michaelsBackUp", typeof(string));
                buyData.Columns.Add("michaelsDropDate", typeof(DateTime));
                // Joann
                buyData.Columns.Add("joannCode", typeof(string));
                buyData.Columns.Add("joannCurrentStoreCount", typeof(float));
                buyData.Columns.Add("joannFutureStoreCount", typeof(float));
                buyData.Columns.Add("joannROS", typeof(float));
                buyData.Columns.Add("joannROSoverride", typeof(float));
                buyData.Columns.Add("joannRolloutDate", typeof(DateTime));
                buyData.Columns.Add("joannRolloutAmount", typeof(string));
                buyData.Columns.Add("joannRolloutDate2", typeof(DateTime));
                buyData.Columns.Add("joannRolloutAmount2", typeof(string));
                buyData.Columns.Add("joannBackup", typeof(string));
                buyData.Columns.Add("joannDropDate", typeof(DateTime));
                // Michaels
                buyData.Columns.Add("acCode", typeof(string));
                buyData.Columns.Add("acCurrentStoreCount", typeof(float));
                buyData.Columns.Add("acFutureStoreCount", typeof(float));
                buyData.Columns.Add("acROS", typeof(float));
                buyData.Columns.Add("acROSoverride", typeof(float));
                buyData.Columns.Add("acRolloutDate", typeof(DateTime));
                buyData.Columns.Add("acRolloutAmount", typeof(float));
                buyData.Columns.Add("acRolloutDate2", typeof(DateTime));
                buyData.Columns.Add("acRolloutAmount2", typeof(float));
                buyData.Columns.Add("acBackUp", typeof(string));
                buyData.Columns.Add("acDropDate", typeof(DateTime));
                // Meijer
                buyData.Columns.Add("meijerCode", typeof(string));
                buyData.Columns.Add("meijerCurrentStoreCount", typeof(float));
                buyData.Columns.Add("meijerFutureStoreCount", typeof(float));
                buyData.Columns.Add("meijerROS", typeof(float));
                buyData.Columns.Add("meijerROSoverride", typeof(float));
                buyData.Columns.Add("meijerRolloutDate", typeof(DateTime));
                buyData.Columns.Add("meijerRolloutAmount", typeof(float));
                buyData.Columns.Add("meijerRolloutDate2", typeof(DateTime));
                buyData.Columns.Add("meijerRolloutAmount2", typeof(float));
                buyData.Columns.Add("meijerBackUp", typeof(string));
                buyData.Columns.Add("meijerDropDate", typeof(DateTime));
                // Meijer
                buyData.Columns.Add("wmcaCode", typeof(string));
                buyData.Columns.Add("wmcaCurrentStoreCount", typeof(float));
                buyData.Columns.Add("wmcaFutureStoreCount", typeof(float));
                buyData.Columns.Add("wmcaROS", typeof(float));
                buyData.Columns.Add("wmcaROSoverride", typeof(float));
                buyData.Columns.Add("wmcaRolloutDate", typeof(DateTime));
                buyData.Columns.Add("wmcaRolloutAmount", typeof(float));
                buyData.Columns.Add("wmcaRolloutDate2", typeof(DateTime));
                buyData.Columns.Add("wmcaRolloutAmount2", typeof(float));
                buyData.Columns.Add("wmcaBackup", typeof(string));
                buyData.Columns.Add("wmcaDropDate", typeof(DateTime));
                // Notes
                buyData.Columns.Add("itemNotes", typeof(string));
                // Override
                buyData.Columns.Add("override", typeof(int));
                using (CsvReader csv = new CsvReader(
                       new StreamReader(filePath), true))
                {
                    buyData.Load(csv);
                }

                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connectionString))
                {
                    bulkcopy.DestinationTableName = "BuyReportDataTMP";
                    bulkcopy.ColumnMappings.Add("stocknumber", "stocknumber");
                    bulkcopy.ColumnMappings.Add("michaelsCode", "michaelsCode");
                    bulkcopy.ColumnMappings.Add("michaelsCurrentStoreCount", "michaelsCurrentStoreCount");
                    bulkcopy.ColumnMappings.Add("michaelsFutureStoreCount", "michaelsFutureStoreCount");
                    bulkcopy.ColumnMappings.Add("michaelsROS", "michaelsROS");
                    bulkcopy.ColumnMappings.Add("michaelsROSoverride", "michaelsROSoverride");
                    bulkcopy.ColumnMappings.Add("michaelsRolloutDate", "michaelsRolloutDate");
                    bulkcopy.ColumnMappings.Add("michaelsRolloutAmount", "michaelsRolloutAmount");
                    bulkcopy.ColumnMappings.Add("michaelsRolloutDate2", "michaelsRolloutDate2");
                    bulkcopy.ColumnMappings.Add("michaelsRolloutAmount2", "michaelsRolloutAmount2");
                    bulkcopy.ColumnMappings.Add("michaelsBackUp", "michaelsBackUp");
                    bulkcopy.ColumnMappings.Add("michaelsDropDate", "michaelsDropDate");
                    bulkcopy.ColumnMappings.Add("joannCode", "joannCode");
                    bulkcopy.ColumnMappings.Add("joannCurrentStoreCount", "joannCurrentStoreCount");
                    bulkcopy.ColumnMappings.Add("joannFutureStoreCount", "joannFutureStoreCount");
                    bulkcopy.ColumnMappings.Add("joannROS", "joannROS");
                    bulkcopy.ColumnMappings.Add("joannROSoverride", "joannROSoverride");
                    bulkcopy.ColumnMappings.Add("joannRolloutDate", "joannRolloutDate");
                    bulkcopy.ColumnMappings.Add("joannRolloutAmount", "joannRolloutAmount");
                    bulkcopy.ColumnMappings.Add("joannRolloutDate2", "joannRolloutDate2");
                    bulkcopy.ColumnMappings.Add("joannRolloutAmount2", "joannRolloutAmount2");
                    bulkcopy.ColumnMappings.Add("joannBackup", "joannBackup");
                    bulkcopy.ColumnMappings.Add("joannDropDate", "joannDropDate");
                    bulkcopy.ColumnMappings.Add("acCode", "acCode");
                    bulkcopy.ColumnMappings.Add("acCurrentStoreCount", "acCurrentStoreCount");
                    bulkcopy.ColumnMappings.Add("acFutureStoreCount", "acFutureStoreCount");
                    bulkcopy.ColumnMappings.Add("acROS", "acROS");
                    bulkcopy.ColumnMappings.Add("acROSoverride", "acROSoverride");
                    bulkcopy.ColumnMappings.Add("acRolloutDate", "acRolloutDate");
                    bulkcopy.ColumnMappings.Add("acRolloutAmount", "acRolloutAmount");
                    bulkcopy.ColumnMappings.Add("acRolloutDate2", "acRolloutDate2");
                    bulkcopy.ColumnMappings.Add("acRolloutAmount2", "acRolloutAmount2");
                    bulkcopy.ColumnMappings.Add("acBackUp", "acBackUp");
                    bulkcopy.ColumnMappings.Add("acDropDate", "acDropDate");
                    bulkcopy.ColumnMappings.Add("meijerCode", "meijerCode");
                    bulkcopy.ColumnMappings.Add("meijerCurrentStoreCount", "meijerCurrentStoreCount");
                    bulkcopy.ColumnMappings.Add("meijerFutureStoreCount", "meijerFutureStoreCount");
                    bulkcopy.ColumnMappings.Add("meijerROS", "meijerROS");
                    bulkcopy.ColumnMappings.Add("meijerROSoverride", "meijerROSoverride");
                    bulkcopy.ColumnMappings.Add("meijerRolloutDate", "meijerRolloutDate");
                    bulkcopy.ColumnMappings.Add("meijerRolloutAmount", "meijerRolloutAmount");
                    bulkcopy.ColumnMappings.Add("meijerRolloutDate2", "meijerRolloutDate2");
                    bulkcopy.ColumnMappings.Add("meijerRolloutAmount2", "meijerRolloutAmount2");
                    bulkcopy.ColumnMappings.Add("meijerBackUp", "meijerBackUp");
                    bulkcopy.ColumnMappings.Add("meijerDropDate", "meijerDropDate");
                    bulkcopy.ColumnMappings.Add("wmcaCode", "wmcaCode");
                    bulkcopy.ColumnMappings.Add("wmcaCurrentStoreCount", "wmcaCurrentStoreCount");
                    bulkcopy.ColumnMappings.Add("wmcaFutureStoreCount", "wmcaFutureStoreCount");
                    bulkcopy.ColumnMappings.Add("wmcaROS", "wmcaROS");
                    bulkcopy.ColumnMappings.Add("wmcaROSoverride", "wmcaROSoverride");
                    bulkcopy.ColumnMappings.Add("wmcaRolloutDate", "wmcaRolloutDate");
                    bulkcopy.ColumnMappings.Add("wmcaRolloutAmount", "wmcaRolloutAmount");
                    bulkcopy.ColumnMappings.Add("wmcaRolloutDate2", "wmcaRolloutDate2");
                    bulkcopy.ColumnMappings.Add("wmcaRolloutAmount2", "wmcaRolloutAmount2");
                    bulkcopy.ColumnMappings.Add("wmcaBackup", "wmcaBackup");
                    bulkcopy.ColumnMappings.Add("wmcaDropDate", "wmcaDropDate");
                    bulkcopy.ColumnMappings.Add("itemNotes", "itemNotes");
                    bulkcopy.ColumnMappings.Add("override", "override");
                    bulkcopy.WriteToServer(buyData);
                }
                // run stored procedure to update customer codes from temp table. 
                using (var conn = new SqlConnection(connectionString))
                using (var command = new SqlCommand("updateCustCodes", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Customer Codes updated!");
                }
            }
        }
    }
}
