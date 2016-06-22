using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CCR
{
    public partial class cmEditContainerForm : Form
    {
        SqlConnection con;

        // CM Details
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder updateSQL;

        // CM Data
        SqlDataAdapter cmAdap;
        DataSet cmDS;
        SqlCommandBuilder cmUpdateSql;

        public cmEditContainerForm()
        {
            InitializeComponent();
        }

        private void cmEditContainerForm_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
                con.Open();

                // cm_Details
                adap = new SqlDataAdapter("select Supplier, ShipDate, ETADate, ShipType, Delivered, Notes, ContainerQty, ContainerNumber, CMID from CM_Details", con);
                ds = new DataSet();
                adap.Fill(ds, "cm_Details");
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[8].Visible = false;

                // cm_Data is generated on dataGridView1_CellClick() based on the record selected above       

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            try
            {
                // cm_details
                updateSQL = new SqlCommandBuilder(adap);
                adap.Update(ds, "cm_Details");

                // cm_data
                cmUpdateSql = new SqlCommandBuilder(cmAdap);
                cmAdap.Update(cmDS, "cm_Data");

                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                string a = Convert.ToString(selectedRow.Cells["CMID"].Value);

                cmAdap = new SqlDataAdapter("select PONumber, ItemNumber, ItemQty, ID from CM_Data where CMID = @CMID", con);
                cmAdap.SelectCommand.Parameters.AddWithValue("@CMID", a);
                cmDS = new DataSet();
                cmAdap.Fill(cmDS, "cm_Data");
                cmDataGridView.DataSource = cmDS.Tables[0];
                cmDataGridView.Columns[3].Visible = false;
            }


        }

        private void createImportButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                string a = Convert.ToString(selectedRow.Cells["CMID"].Value);

                cmAdap = new SqlDataAdapter("select PONumber, ItemNumber, sum(ItemQty) as 'ItemQty' from CM_Data where CMID = @CMID group by PONumber, ItemNumber", con);
                cmAdap.SelectCommand.Parameters.AddWithValue("@CMID", a);
                string poRef = "";
                string importFile = "";
                var cmDT = new DataTable();
                cmAdap.Fill(cmDT);
                cmDT.Columns.Add("header");

                foreach (DataRow row in cmDT.Rows)
                {
                    if ((string)row["PONumber"] != poRef)
                    {
                        poRef = (string)row["PONumber"];
                        row["header"] = "H";
                    }
                    else
                        row["header"] = "I";
                }

                foreach (DataRow row in cmDT.Rows)
                {
                    if ((string)row["header"] == "H")
                    {
                        importFile += (string)row["header"] + "\t" + (string)row["PONumber"] + "\t" + "MAIN\r\n" +
                                    "I\t" + (string)row["PONumber"] + "\t" + (string)row["ItemNumber"] + "\t" + row["ItemQty"].ToString() + "\r\n";
                    }
                    else
                        importFile += (string)row["header"] + "\t" + (string)row["PONumber"] + "\t" + (string)row["ItemNumber"] + "\t" + row["ItemQty"].ToString() + "\r\n";
                }
                System.IO.File.WriteAllText(@"\\srv-sw\public\CM_RECIMPORT.TXT", importFile);
                //int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                (selectedRow.DataBoundItem as DataRowView).Row["Delivered"] = 1;
                UpdateDataBase();

            }
            else
            {
                MessageBox.Show("No container selected, Please select a container and try again", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
