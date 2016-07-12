using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCR
{
    public partial class International_PO_log : Form
    {
        public International_PO_log()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        private void International_PO_log_Load(object sender, EventArgs e)
        {
            RefreshData();
            //dataGridView1.DataSource = poDT;
        }

        DataTable poDT = new DataTable();
        private void RefreshData()
        {
            poDT = GetData.ExecuteQuery(@"select distinct d.ponumber, d.vendornumber, dateordered, shipdate, comments, totalamount, i.confirmed, i.dateconfirmed, i.posent, i.notes
                                        from SWCCSPO1 d
                                        --join SWCCSPO2 l on d.ponumber = l.ponumber
                                        left join InternationalPOlog i on i.ponumber = d.ponumber
                                        where d.location = @0
                                        order by 1", connectionString, locationNumber);

            foreach (DataRow row in poDT.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("ponumber");
            temp.Columns.Add("confirmed");
            temp.Columns.Add("dateconfirmed");
            temp.Columns.Add("posent");
            temp.Columns.Add("notes");


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int confirmed = 0;
                string dateConfirmed = string.Empty;
                bool boolConfirmed = false;
                if (row.Cells["confirmed"].Value != DBNull.Value)
                {
                    confirmed = Convert.ToInt32(row.Cells["confirmed"].Value);
                    boolConfirmed = Convert.ToBoolean(confirmed);                    
                }
                                
                if (row.Cells["dateconfirmed"].Value == DBNull.Value)
                    dateConfirmed = null;

                temp.Rows.Add(row.Cells["ponumber"].Value, boolConfirmed, row.Cells["dateconfirmed"].Value, row.Cells["posent"].Value, row.Cells["notes"].Value);
            }

            temp.Rows.RemoveAt(temp.Rows.Count - 1);


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter("SELECT ponumber, confirmed, dateconfirmed, posent, notes from InternationalPOlog", con);
                SqlCommand cmd = new SqlCommand("Delete from InternationalPOlog", con);
                cmd.ExecuteNonQuery();

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adap);
                adap.InsertCommand = commandBuilder.GetInsertCommand(true);
                adap.Fill(temp);
                try
                {
                    adap.Update(temp);
                    poDT = temp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTableToExcel.ExportToExcel(poDT);
        }

        string locationNumber = "900";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton800.Checked == true)
            {
                locationNumber = "800";
            }
            else
            {
                locationNumber = "900";
            }
            poDT = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            RefreshData();
        }
    }
}
