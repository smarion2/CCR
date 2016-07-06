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
        DataTable poDT = new DataTable();
        SqlCommand cmd;
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        private void International_PO_log_Load(object sender, EventArgs e)
        {
            poDT = GetData.ExecuteQuery(@"select distinct d.ponumber, d.vendornumber, dateordered, shipdate, comments, totalamount, i.confirmed, i.dateconfirmed, i.posent, i.notes
                                        from SWCCSPO1 d
                                        --join SWCCSPO2 l on d.ponumber = l.ponumber
                                        left join InternationalPOlog i on i.ponumber = d.ponumber
                                        order by 1
                                        ", connectionString);
            

            dataGridView1.DataSource = poDT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("ponumber");
            temp.Columns.Add("confirmed");
            temp.Columns.Add("dateconfirmed");
            temp.Columns.Add("posent");
            temp.Columns.Add("notes");


            foreach (DataRow row in poDT.Rows)
            {
                int confirmed = 0;
                string dateConfirmed = string.Empty;
                bool boolConfirmed = false;
                if (row["confirmed"] != DBNull.Value)
                {
                    confirmed = Convert.ToInt32(row["confirmed"]);
                    boolConfirmed = Convert.ToBoolean(confirmed);                    
                }
                                
                if (row["dateconfirmed"] == DBNull.Value)
                    dateConfirmed = null;

                temp.Rows.Add(row["ponumber"], boolConfirmed, row["dateConfirmed"], row["posent"], row["notes"]);
            }

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
    }
}
